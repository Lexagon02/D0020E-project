using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Highscore : MonoBehaviour
{
    private Transform entryContainer;
    private Transform entryTemplate;
    private List<scoreEntry> entryList;
    private List<Transform> entryTransformList;
    private int selectedDiff;
    private GameObject[] existingScore;

    private void Awake()
    {

        entryContainer = transform.Find("entryContainer");
        entryTemplate = entryContainer.Find("entryTemplate");
        entryTemplate.gameObject.SetActive(false);
        TMP_Text title = GameObject.Find("Title").GetComponent<TextMeshProUGUI>();
        string jsonString;
        switch (selectedDiff)
        {
            default:
                jsonString = PlayerPrefs.GetString("highscoreTableEasy");
                title.text = "Easy";
                break;
            case 1:
                jsonString = PlayerPrefs.GetString("highscoreTableEasy");
                title.text = "Easy";
                break;
            case 2:
                jsonString = PlayerPrefs.GetString("highscoreTableMed");
                title.text = "Medium";
                break;
            case 3:
                jsonString = PlayerPrefs.GetString("highscoreTableHard");
                title.text = "Hard";
                break;
        };
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);
        entryList = highscores.entryList;


        //Sort the list of scores
        for (int i = 0; i < entryList.Count; i++)
        {
            for (int j = i + 1; j < entryList.Count; j++)
            {
                if (entryList[j].score > entryList[i].score)
                {
                    scoreEntry temp = entryList[i];
                    entryList[i] = entryList[j];
                    entryList[j] = temp;
                }
            }
        }


        entryTransformList = new List<Transform>();
        foreach (scoreEntry entry in entryList)
        {
            CreateEntryTransform(entry, entryContainer, entryTransformList);
            
        }

    }
    public void TableDiffculty()
    {
        switch (selectedDiff)
        {
            default:
                selectedDiff = 2;
                break;
            case 1:
                selectedDiff = 2;
                break;
            case 2:
                selectedDiff = 3;
                break;
            case 3:
                selectedDiff = 1;
                break;
        };
        existingScore = GameObject.FindGameObjectsWithTag("score");
        foreach (GameObject score in existingScore)
        {
            GameObject.Destroy(score);
        }
        Awake();
    }

    private void CreateEntryTransform(scoreEntry entry, Transform container, List<Transform> transformList)
    {
        Transform entryTransform = Instantiate(entryTemplate, container);
        entryTransform.tag = "score";
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition = new Vector2(0, -50 * transformList.Count);
        entryTransform.gameObject.SetActive(true);


        int rank = transformList.Count+1;
        entryTransform.Find("posText").GetComponent<TextMeshProUGUI>().text = rank.ToString();
        entryTransform.Find("nameText").GetComponent<TextMeshProUGUI>().text = entry.name;
        entryTransform.Find("scoreText").GetComponent<TextMeshProUGUI>().text = entry.score.ToString();
        transformList.Add(entryTransform);
    }

    public void AddHighscoreEntry(int score, string name, int difficulty)
    {
        string jsonString;
        switch (difficulty)
        {
            default:
                jsonString = PlayerPrefs.GetString("highscoreTableEasy");
                break;
            case 2:
                jsonString = PlayerPrefs.GetString("highscoreTableMed");
                break;
            case 3:
                jsonString = PlayerPrefs.GetString("highscoreTableHard");
                break;
        };
        
        Debug.Log(jsonString);
        if (jsonString == "")
        {
            jsonString = "{\"entryList\":[]}";
        }
        Debug.Log(jsonString);
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);
        scoreEntry entry = new scoreEntry { score = score, name = name};
        for (int i = 0; i < highscores.entryList.Count; i++)
        {
            for (int j = i + 1; j < highscores.entryList.Count; j++)
            {
                if (highscores.entryList[j].score > highscores.entryList[i].score)
                {
                    scoreEntry temp = highscores.entryList[i];
                    highscores.entryList[i] = highscores.entryList[j];
                    highscores.entryList[j] = temp;
                }
            }
        }


        if (highscores.entryList.Count > 10)
        {
            if (highscores.entryList[9].score < score)
            {
                highscores.entryList[9] = entry;
                string jsonTable = JsonUtility.ToJson(highscores);
                Save(difficulty, jsonTable);
            }

        }
        else
        {
            highscores.entryList.Add(entry);
            string jsonTable = JsonUtility.ToJson(highscores);
            Save(difficulty, jsonTable);
        }




    }

    private void Save(int difficulty, string jsonTable)
    {
        switch (difficulty)
        {
            case 1:
                PlayerPrefs.SetString("highscoreTableEasy", jsonTable);
                PlayerPrefs.Save();
                break;
            case 2:
                PlayerPrefs.SetString("highscoreTableMed", jsonTable);
                PlayerPrefs.Save();
                break;
            case 3:
                PlayerPrefs.SetString("highscoreTableHard", jsonTable);
                PlayerPrefs.Save();
                break;
        };

    }

    private class Highscores
    {
        public List<scoreEntry> entryList;
    }

    [System.Serializable]
    private class scoreEntry
    {
        public int score;
        public string name;

    }

    public void SaveFile(int currentScore, string currentName)
    {
        
    }

    public void LoadFile()
    {
        
    }

}

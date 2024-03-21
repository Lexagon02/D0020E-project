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
        switch (selectedDiff)//Check what difficulty is selected and load its table
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
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);//Convert json string to highscore object
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
            CreateEntryTransform(entry, entryContainer, entryTransformList);//Create entry in table for each score

        }

    }
    public void TableDiffculty()//Change difficulty of table
    {
        switch (selectedDiff)//Choose the selected difficulty
        {
            default:
                selectedDiff = 2; // default difficulity normal = 2
                break;
            case 1:
                selectedDiff = 2;   // normal
                break;
            case 2:
                selectedDiff = 3;   // hard
                break;
            case 3:
                selectedDiff = 1; // easy
                break;
        };
        existingScore = GameObject.FindGameObjectsWithTag("score");
        foreach (GameObject score in existingScore)//Remove all the old scores from table
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


        int rank = transformList.Count + 1;
        entryTransform.Find("posText").GetComponent<TextMeshProUGUI>().text = rank.ToString();
        entryTransform.Find("nameText").GetComponent<TextMeshProUGUI>().text = entry.name;
        entryTransform.Find("scoreText").GetComponent<TextMeshProUGUI>().text = entry.score.ToString();
        transformList.Add(entryTransform);
    }

    public void AddHighscoreEntry(int score, string name, int difficulty)
    {
        string jsonString;
        switch (difficulty)//Get exisiting scores from difficulty
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

        if (jsonString == "")//If there is no scores
        {
            jsonString = "{\"entryList\":[]}";
        }
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);//Convert json to highscores object
        scoreEntry entry = new scoreEntry { score = score, name = name };//create new scoreEntry
        for (int i = 0; i < highscores.entryList.Count; i++)//Loop for sorting highscores
        {
            for (int j = i + 1; j < highscores.entryList.Count; j++)
            {
                if (highscores.entryList[j].score > highscores.entryList[i].score)//If next score is bigger, switch places
                {
                    scoreEntry temp = highscores.entryList[i];
                    highscores.entryList[i] = highscores.entryList[j];
                    highscores.entryList[j] = temp;
                }
            }
        }


        if (highscores.entryList.Count > 10)//If highscore is full
        {
            if (highscores.entryList[9].score < score)//Check if lowest highscore in table is less than new score, If so replace it with new score
            {
                highscores.entryList[9] = entry;
                string jsonTable = JsonUtility.ToJson(highscores);//Convert to json
                Save(difficulty, jsonTable);//save to player prefs
            }

        }
        else//If highscore is not full, simply add new score to table
        {
            highscores.entryList.Add(entry);
            string jsonTable = JsonUtility.ToJson(highscores);//Convert to json
            Save(difficulty, jsonTable);//save to player prefs
        }




    }

    private void Save(int difficulty, string jsonTable)
    {
        switch (difficulty)//Save selected table to PlayerPrefs
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
}


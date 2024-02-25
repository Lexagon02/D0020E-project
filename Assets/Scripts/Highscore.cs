using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Highscore : MonoBehaviour
{
    private Transform entryContainer;
    private Transform entryTemplate;
    private List<scoreEntry> entryList;
    private List<Transform> entryTransformList;

    private void Awake()
    {

        entryContainer = transform.Find("entryContainer");
        entryTemplate = entryContainer.Find("entryTemplate");
        entryTemplate.gameObject.SetActive(false);
        /*
        entryList = new List<scoreEntry>()
        {
        };

        string jsonTable = JsonUtility.ToJson(entryList);
        PlayerPrefs.SetString("highscoreTable", jsonTable);
        PlayerPrefs.Save();
        */



        string jsonString = PlayerPrefs.GetString("highscoreTable");
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

    private void CreateEntryTransform(scoreEntry entry, Transform container, List<Transform> transformList)
    {
        Transform entryTransform = Instantiate(entryTemplate, container);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition = new Vector2(0, -50 * transformList.Count);
        entryTransform.gameObject.SetActive(true);


        int rank = transformList.Count+1;
        entryTransform.Find("posText").GetComponent<Text>().text = rank.ToString();
        entryTransform.Find("nameText").GetComponent<Text>().text = entry.name;
        entryTransform.Find("scoreText").GetComponent<Text>().text = entry.score.ToString();
        transformList.Add(entryTransform);
    }

    public void AddHighscoreEntry(int score, string name)
    {

        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Debug.Log(jsonString);
        if (jsonString == "")
        {
            jsonString = "{\"entryList\":[{\"score\":0,\"name\":\"AAA\"}]}";
        }
        Debug.Log(jsonString);
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);
        scoreEntry entry = new scoreEntry { score = score, name = name };
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
                PlayerPrefs.SetString("highscoreTable", jsonTable);
                PlayerPrefs.Save();
            }

        }
        else
        {
            highscores.entryList.Add(entry);
            string jsonTable = JsonUtility.ToJson(highscores);
            PlayerPrefs.SetString("highscoreTable", jsonTable);
            PlayerPrefs.Save();
        }




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

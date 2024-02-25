using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{


    public TextMeshProUGUI mainText;
    public static int ScoreCount = 0;
    public static int ScoreBonus = 0;
    public static int ScoreSum = 0;



    // Update is called once per frame
    void Update()
    {
        if (ScoreBonus <= 1)
        {
            ScoreSum = ScoreCount;
            mainText.text = "Score: " + ScoreSum + "\n x " + ScoreBonus;
        }
        else if(ScoreBonus > 1 &&  ScoreBonus <= 4)
        {
            ScoreSum = ScoreCount + ScoreBonus * 2;
            mainText.text = "Score: " + ScoreSum + "\n x " + ScoreBonus*2;
        }
        else if(ScoreBonus > 4)
        {
            ScoreSum = ScoreCount + 4 * 2;
            mainText.text = "Score: " +ScoreSum + "\n x " + ScoreBonus*2;
        }

    }
}

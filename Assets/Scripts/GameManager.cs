using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{


    public TextMeshProUGUI mainText;
    public static int ScoreCount = 0;
    public static int ScoreBonus = 0;



    // Update is called once per frame
    void Update()
    {
        if (ScoreBonus <= 1)
        {
            mainText.text = "Score: " + ScoreCount;
        }
        else if(ScoreBonus > 1 &&  ScoreBonus <= 4)
        {
            mainText.text = "Score: " + ScoreCount + ScoreBonus*2;
        }
        else if(ScoreBonus > 4)
        { 
            mainText.text = "Score: " + ScoreCount + 4 * 2;
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

   
    public static int ScoreSum = 0;
    public static int ScoreBonus = 0;



    // Update is called once per frame
    public static void Score()
    {
        if (ScoreBonus <= 1)
        {
            ScoreSum += ScoreBonus;
        }
       if (ScoreBonus > 1 && ScoreBonus < 5)
        {
            ScoreSum += ScoreBonus;

        }
       if (ScoreBonus >= 5)
       {
            ScoreBonus = 4;
            ScoreSum += ScoreBonus;
       }
       
    }

    void Update()
    {
        Script_show.ScoreShow_ = ScoreBonus+ 1;
        Script_Sum.ScoreSum_ = ScoreSum;



    }
       

    
}

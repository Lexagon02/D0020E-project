using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Script_Sum : MonoBehaviour
{

    private TextMeshProUGUI Test;
    public static int ScoreSum_ = 0;

   




    void Start()
    {
        Test = GetComponent<TextMeshProUGUI>(); //finds the textmesh component
    }

    public void Update()
    {
        
        Test.text = "Score: " + ScoreSum_; // shows the score on the screen
    }




}
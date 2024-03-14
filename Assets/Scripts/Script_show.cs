using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Script_show : MonoBehaviour
{

  
    private TextMeshProUGUI Text;
    Animator anim;
    public static int ScoreShow_ = 0;
    public static Boolean showBonus = false;
   





    void Start()
    {
        Text = GetComponent<TextMeshProUGUI>(); //finds the textmesh component
        anim = GetComponent<Animator>(); //finds the animation component
    }




    void Update()
    { 
        Text.text = "x" + ScoreShow_; // shows the score on the screen
        if (showBonus == true) // if true show the animation
        {
            anim.SetTrigger("FadeTrigger"); //triggers the animation
            showBonus = false; //after the animation dont show it again
        }
        
    }

    


}

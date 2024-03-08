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
        Text = GetComponent<TextMeshProUGUI>();
        anim = GetComponent<Animator>();
    }




    void Update()
    { 
        Text.text = "x" + ScoreShow_;
        if (showBonus == true)
        {
            anim.SetTrigger("FadeTrigger");
            showBonus = false;
        }
        
    }

    


}

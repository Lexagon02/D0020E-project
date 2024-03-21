using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuLighting : MonoBehaviour
{

    // For random light effect in main menu
    public Light myLight;

    float interval = 1;
    float timer;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > interval)
        {
            myLight.enabled = !myLight.enabled;//Turn off/on light
            interval = UnityEngine.Random.Range(0f, 1f);//Set new interval to random number
            timer = 0;
        }
    }
}

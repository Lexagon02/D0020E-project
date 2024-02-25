using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuLighting : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public Light myLight;

    float interval = 1;
    float timer;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > interval)
        {
            myLight.enabled = !myLight.enabled;
            interval = UnityEngine.Random.Range(0f, 1f);
            timer = 0;
        }
    }
}

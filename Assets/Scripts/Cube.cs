using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Security.Cryptography;
using UnityEngine;

public class CubeScript : MonoBehaviour
{
    public int speed;
    private float delay;
    // Start is called before the first frame update
    void Start()
    {
        int diff = PlayerPrefs.GetInt("Difficulty");
        speed = 5 + 3*diff; // speed = 8 if easy, 11 if medium, 14 if hard 


                            // delay = 6; for easy
                            // delay = 4.2; for medium
                            // delay = 3.3; for hard
        if(diff == 1)
        {
            delay = 5.8F;
        }
        else if(diff == 2)
        {
            delay = 4.2F;
        }
        else if (diff == 3)
        {
            delay = 3.3F;
        }
        else
        {
            delay = 6.0F;
        }
        Destroy(this.gameObject,delay);
        GameManager.ScoreBonus = 0;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Time.deltaTime * transform.forward * speed;
    }
}

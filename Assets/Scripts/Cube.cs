using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Security.Cryptography;
using UnityEngine;

public class CubeScript : MonoBehaviour
{
    public int speed;
    private int delay = 15;
    // Start is called before the first frame update
    void Start()
    {
        int diff = PlayerPrefs.GetInt("Difficulty");
        speed = 5 + 3*diff; // speed = 8 if easy, 11 if medium, 14 if hard 
        Destroy(this.gameObject,delay);
        GameManager.ScoreBonus = 0;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Time.deltaTime * transform.forward * speed;
    }
}

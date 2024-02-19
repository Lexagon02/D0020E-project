using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Security.Cryptography;
using UnityEngine;

public class CubeScript : MonoBehaviour
{
    public int speed;
    private int delay = 30;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject,delay);
        GameManager.ScoreBonus = 0;
 
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Time.deltaTime * transform.forward * speed;
    }
}

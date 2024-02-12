using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Security.Cryptography;
using UnityEngine;

public class CubeScript : MonoBehaviour
{
    public GameObject Explosion;

    public void OnCollisionEnter(Collision collision){
        if (collision.gameObject.layer == this.gameObject.layer) {
            //UnityEngine.Debug.Log("1");
            //Instantiate(Explosion, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
            
        }
        else if (collision.gameObject.layer == this.gameObject.layer) {
            //Instantiate(Explosion, transform.position, Quaternion.identity);
            //UnityEngine.Debug.Log("2");
            Destroy(this.gameObject);
            
            
        }
        //Instantiate(Explosion, transform.position, Quaternion.identity);
        //UnityEngine.Debug.Log("3");


    }

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

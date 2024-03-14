using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
//using System.Diagnostics;

//using System.Media;
using UnityEngine;

public class collision : MonoBehaviour

{

    AudioManager audioManager;
    public GameObject Explosion;
    public CubeScript cube;

    private Rigidbody rb;
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    public void OnCollisionEnter(Collision collision){
        if (collision.gameObject.layer == this.gameObject.layer) {
            Debug.Log(gameObject.layer);
            GameManager.ScoreSum++; //add 1 to scoreSum
            GameManager.ScoreBonus++; // add 1 to bonus
            GameManager.Score(); //calcukates the bonus
            Script_show.showBonus = true; //fade animation is on
            UnityEngine.Debug.Log(this.gameObject);
            cube = transform.parent.GetComponent<CubeScript>();
            cube.speed = 8;
            rb=cube.gameObject.AddComponent<Rigidbody>();
            transform.parent.gameObject.layer=9;
            rb.velocity = new Vector3(3, -15, 0);
            rb.mass = 2000;
            Destroy(transform.parent.gameObject,3);
            GameObject exp = Instantiate(Explosion, transform.position, Quaternion.identity);
            exp.transform.parent = cube.transform;
            Destroy(exp, 1);
            audioManager.PlaySFX(audioManager.BoxDestroyed);

        }
    }

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == this.gameObject.tag)
        {
          
            GameManager.ScoreBonus = 0; //resets scorebonus to zero
            GameManager.Score();    //calcukates the bonus
            Script_show.showBonus = true; //fade animation is on
            cube = transform.parent.GetComponent<CubeScript>();
            cube.speed = 1;
            cube = transform.parent.GetComponent<CubeScript>();
            rb = cube.gameObject.AddComponent<Rigidbody>();
            rb.velocity = new Vector3(-1, 0, 0);
            Destroy(transform.parent.gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collision : MonoBehaviour
{
    
    public void OnCollisionEnter(Collision collision){
        if (collision.gameObject.layer == this.gameObject.layer) {
            Destroy(transform.parent.gameObject);
            GameManager.ScoreCount++;
            GameManager.ScoreBonus++; 

        }
        else if (collision.gameObject.layer == this.gameObject.layer) {
            Destroy(transform.parent.gameObject);
            GameManager.ScoreCount++;
            GameManager.ScoreBonus++; 
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

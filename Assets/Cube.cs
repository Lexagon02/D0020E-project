using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeScript : MonoBehaviour
{
    

    public void OnCollisionEnter(Collision collision){
        if (collision.gameObject.layer == this.gameObject.layer) {
            Destroy(this.gameObject);
        }
        else if (collision.gameObject.layer == this.gameObject.layer) {
            Destroy(this.gameObject);
        }
        
    }

    public int speed;
    private int delay = 30;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject,delay);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Time.deltaTime * transform.forward * speed;
    }
}

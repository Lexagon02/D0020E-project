using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collision : MonoBehaviour

{
    public GameObject Explosion;

    public void OnCollisionEnter(Collision collision){
        if (collision.gameObject.layer == this.gameObject.layer) {
            Destroy(transform.parent.gameObject);
            GameObject exp = Instantiate(Explosion, transform.position, Quaternion.identity);
            Destroy(exp, 3);
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

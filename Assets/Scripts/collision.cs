using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collision : MonoBehaviour

{
    AudioManager audioManager;
    public GameObject Explosion;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    public void OnCollisionEnter(Collision collision){
        if (collision.gameObject.layer == this.gameObject.layer) {
            Destroy(transform.parent.gameObject);
            GameObject exp = Instantiate(Explosion, transform.position, Quaternion.identity);
            Destroy(exp, 3);
            GameManager.ScoreCount++;
            GameManager.ScoreBonus++;
            audioManager.PlaySFX(audioManager.BoxDestroyed);

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

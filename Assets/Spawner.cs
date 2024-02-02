using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject[] cubes;
    public Transform[] points;
    public float beat; // beat of the song
    private float timer;

    private int[] color = {0,0,0,1,1,1,0,0,1,1,0,0,0,0,1,1,1,1}; // 0 for blue 1 for red
    private int[] pos = {}; // 0, 1, 2, 3
    private int[] rot = {}; // 0, 1, 2, 3

    //private arr[] arr = [[1,1,4,0], []]; possible array to spawn boxes
    // Start is called before the first frame update
    void Start()
    {
        
        // Create a temporary reference to the current scene.
		

		// Retrieve the name of this scene.
		

		if (gameObject.tag == "Main Easy") 
		{
			beat = (60/130)*2;
            Debug.Log("ok");
		}
		else if (gameObject.tag == "Main Medium")
		{
			beat = (60/130)*2;
		}
        else if (gameObject.tag == "Main Hard")
		{
			beat = (60/130)*2;
		}
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timer>beat){
            GameObject cube = Instantiate(cubes[Random.Range(0,2)], points[Random.Range(0,4)]); // Spawn cube at random spawn location
            cube.transform.localPosition = Vector3.zero;
            cube.transform.Rotate(transform.forward, 90 * Random.Range(0, 4));                  // Rotate around its axel
            timer -= beat;
        }

        timer += Time.deltaTime;
        
    }
}

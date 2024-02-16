using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] cubes;
    public Transform[] points;
    private double beat; // beat of the song
    private double timer;
    private int i = 0;

    int[] color = new int[400];
    int[] pos = new int[400];

    // Start is called before the first frame update
    void Start()
    {
        //int[] color = {};
        //int[] pos = {};
        int diff = PlayerPrefs.GetInt("Difficulty");
        if (diff == 1) 
		{
           
            beat = 1.142857;
            int[] color = {1,1,1,2,2,2,1,1,2,2,1,1,1,1,2,2,2,2};
            int[] pos = {2,3,2,0,1,0,2,3,0,1,3,2,3,2,1,0,1,0}; // 0 (botRight), 1(TopRight), 2(botLeft), 3(topLeft)
        }
		else if (diff == 2)
		{
            beat = 1.142857;
            int[] color = {0,0,0,1,1,1,0,0,1,1,0,0,0,0,1,1,1,1}; // 0 for blue 1 for red
            int[] pos = {2,3,2,0,1,0,2,3,0,1,3,2,3,2,1,0,1,0}; // 0 (botRight), 1(TopRight), 2(botLeft), 3(topLeft)
        }
        else if (diff == 3)
		{
            
            beat = 1.142857;
            int[] color = {0,0,0,1,1,1,0,0,1,1,0,0,0,0,1,1,1,1}; // 0 for blue 1 for red
            int[] pos = {2,3,2,0,1,0,2,3,0,1,3,2,3,2,1,0,1,0}; // 0 (botRight), 1(TopRight), 2(botLeft), 3(topLeft)
		}
    }
        
    // Update is called once per frame
    void Update()
    {
        
        if(timer>beat){
            if(color[i] != 3){
                GameObject cube = Instantiate(cubes[color[i]], points[pos[i]]); // Spawn cube at random spawn location
                cube.transform.localPosition = Vector3.zero;
                timer -= beat;
                i++;
            }
            else{
                i++;
            }
        }

        timer += Time.deltaTime;
        
    }
}

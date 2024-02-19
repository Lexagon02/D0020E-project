using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] cubes;
    public Transform[] points;
    private double beat; // beat of the song
    private double timer;
    int i;

    public int[] color = {0,0,0,1,1,1,0,0,1,1,0,0,0,0,1,1,1,1};
    public int[] pos = {2,3,2,0,1,0,2,3,0,1,3,2,3,2,1,0,1,0};

    // Start is called before the first frame update
    void Start()
    {
        int diff = PlayerPrefs.GetInt("Difficulty");
        if (diff == 1) 
		{
            int i = 0;
            beat = 1.142857;
        }
		else if (diff == 2)
		{
            int i = 0;
            beat = 1.142857;
        }
        else if (diff == 3)
		{
            int i = 0;
            beat = 1.142857;
		}
    }
    private int[] boxArr(int i){
        int diff = PlayerPrefs.GetInt("Difficulty");
        Debug.Log(diff);
        if (diff == 1) 
		{
            int[] color = {0,0,0,1,1,1,0,0,1,1,0,0,0,0,1,1,1,1};
            int[] pos = {1,1,1,1,1,1,1,1,0,1,3,2,3,2,1,0,1,0}; // 0 (botRight), 1(TopRight), 2(botLeft), 3(topLeft)
            return new[] {color[i], pos[i]}; 
        }
		else if (diff == 2)
		{

            int[] color = {0,0,0,1,1,1,0,0,1,1,0,0,0,0,1,1,1,1}; // 0 for blue 1 for red
            int[] pos = {1,1,1,1,1,1,1,1,0,1,3,2,3,2,1,0,1,0}; // 0 (botRight), 1(TopRight), 2(botLeft), 3(topLeft)
            return new[] {color[i], pos[i]};
        }
        else if (diff == 3)
		{
            int[] color = {0,0,0,1,1,1,0,0,1,1,0,0,0,0,1,1,1,1}; // 0 for blue 1 for red
            int[] pos = {1,1,1,1,1,1,1,1,0,1,3,2,3,2,1,0,1,0}; // 0 (botRight), 1(TopRight), 2(botLeft), 3(topLeft)
            return new[] {color[i], pos[i]};
        }
        
        return new[] {0,0};
    }

        
    // Update is called once per frame
    void Update()
    {
        
        if(timer>beat){
            int[] arr = boxArr(i);
            int c = arr[0];
            int p = arr[1];
            if(c != 2){
                GameObject cube = Instantiate(cubes[c], points[p]); // Spawn cube at random spawn location
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

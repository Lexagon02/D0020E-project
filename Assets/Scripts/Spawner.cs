using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] cubes;
    public Transform[] points;
    private double beat; // beat of the song
    private double timer;
    private double delay;
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
            beat = 1.142857;        // (60/105)*2
            // om speed ändras måste 8 bytas ut mot den nya hastigheten
            // och se till så att delay inte är negativt så ändra *7 till något
            delay = (54-9)/8-beat*4;
        }
		else if (diff == 2)
		{
            int i = 0;
            beat = 0.72289;  // (60/166)*2
            // om speed ändras måste 11 bytas ut mot den nya hastigheten
            // och se till så att delay inte är negativt så ändra *5 till något
            delay = (54-9)/11-beat*5;       
        }
        else if (diff == 3)
		{
            int i = 0;
            beat = 0.75;    // (60/160)*2
            // om speed ändras måste 14 bytas ut mot den nya hastigheten
            // och se till så att delay inte är negativt så ändra *4 till något
            delay = (54-9)/14-beat*4;
		}
    }
    private int[] boxArr(int i){
        int diff = PlayerPrefs.GetInt("Difficulty");
        Debug.Log(diff);
        if (diff == 1) 

		{
            int[] color = {3,3,0,3,1,3,0,3, 1,3,0,3,0,3,1,3,   1,3,0,3,0,3,0,3,   1,3,0,3,1,3,0,3,   1,0,1,3,0,1,3,0,   0,3,1,1,3,0,3,2,   3,3,1,3,0,3,0,3,   1,3,0,3,1,3,0,2,  1,3,0,3,1,3,1,3,  1,3,0,3,1,3,1,3, 0,3,1,3,0,3,0,3, 2,3,2,3,0,3,1,3, 0,3,1,3,1,3,0,2, 3,0,3,2,2,3,1,3, 3,3,0,3,1,3};    //0 for blue, 1 for red, 2 for both, 3 for none 
            int[] pos =   {3,3,3,2,2,1,1,0, 0,3,3,3,1,3,4,3,   5,3,3,3,1,3,2,3,   0,3,3,3,0,3,2,3,   0,0,4,3,2,2,3,5,   3,3,1,1,3,4,3,2,   3,3,5,3,0,3,3,3,   1,3,3,3,0,3,2,1,  0,3,3,3,0,3,2,3,  0,3,5,3,0,3,1,3, 4,3,2,3,3,3,2,3, 0,3,1,3,2,3,0,3, 1,3,3,3,4,3,2,1, 3,1,3,5,3,3,3,3, 3,3,2,3,5,3};      // 0 (botRight), 1(TopRight), 2(botLeft), 3(topLeft)
            return new[] { color[i], pos[i] };
        }
		else if (diff == 2)
		{

            int[] color =   {1,3,3,3,3,3,0,3,1,3,3,3,3,3,3,3,1,3,3,3,3,3,0,3,1,3,3,3,0,3,3,3,1,3,3,3,3,3,0,3,1,3,3,3,0,3,3,3,1,3,3,3,3,3,0,3,1,3,3,3,0,3,3,3,1,3,3,0,1,3,3,1,0,3,3,0,1,3,0,3,1,3,3,0,1,3,3,1,0,3,3,0,1,3,0,3,1,3,0,3,1,3,0,3,1,3,0,3,1,3,0,3,1,0,3,1,1,0,3,1,0,1,3,3,1,3,0,3,2,3,2,3,2,3,3,3,
                            3,3,3,3,2,3,3,3,3,3,3,3,2,3,3,3,3,3,3,3,2,3,3,3,3,3,3,3,2,3,3,3,3,3,3,3,2,3,3,3,3,3,3,3,2,3,3,3,3,3,3,3,2,3,3,3,3,3,3,3,1,3,3,3,3,3,0,3,1,3,3,3,0,3,3,3,1,3,3,3,3,3,0,3,1,3,3,3,0,3,3,3,1,3,0,3,1,3,0,3,1,3,0,3,1,3,0,3,1,0,3,1,1,0,3,1,0,1,3,3,1,3,0,3,2,3,2,3,2};    // 0 for blue, 1 for red, 2 for both, 3 for none 
            int[] pos =     {0,3,3,3,3,3,3,3,0,3,3,3,3,3,3,3,1,3,3,3,3,3,2,3,0,3,3,3,1,3,3,3,0,3,3,3,3,3,3,3,0,3,3,3,2,3,3,3,1,3,3,3,3,3,2,3,0,3,3,3,1,3,3,3,0,3,3,2,1,3,3,1,2,3,3,3,0,3,0,3,0,3,3,2,1,3,3,1,2,3,3,3,0,3,0,3,0,3,2,3,1,3,3,3,0,3,2,3,1,3,3,3,1,2,0,1,0,2,3,0,2,1,3,3,0,3,2,3,1,3,0,3,1,3,3,3,
                            3,3,3,3,2,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,0,3,3,3,3,3,3,3,1,3,3,3,3,3,3,3,2,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,0,3,3,3,3,3,3,3,0,3,3,3,3,3,3,3,0,3,3,3,2,3,3,3,1,3,3,3,3,3,2,3,0,3,3,3,1,3,3,3,0,3,2,3,1,3,3,3,0,3,2,3,1,3,3,3,1,2,0,1,0,2,3,0,2,1,3,3,0,3,2,3,1,3,0,3,1};      // 0 (botRight), 1(TopRight), 2(botLeft), 3(topLeft)
            return new[] {color[i], pos[i]};
        }
        else if (diff == 3)
		{   
            int[] color =   {1,0,2,0,1,2,1,0,2,0,1,2,0,1,2, 3, 2,2,2,2, 3, 1,0,2,2,2,2,1,0,2, 3, 1,0,2,0,1,2,1,0,2,0,1,2,0,1,2, 3,3, 2,2,0,1,2,2,0,1,2, 3, 1,0,2,1,1,2,0,0,2,1,1,2,2,2,2,2, 3, 1,0,2,2,2,2,1,0,2, 3, 1,0,2,1,1,2,0,0,2,1,1,2,2,2,2,2, 3, 1,0,2,2,0,0,1,1,2, 3, 2,2,0,1,2,2,0,1,2, 3, 2,2,0,1,2,2,0,1,2, 2,2,2, 2,2,2,0,2,2,2,2};    // 0 for blue, 1 for red, 2 for both, 3 for none 
            int[] pos =     {1,0,0,2,3,1,1,0,0,2,3,3,4,5,3, 3, 0,1,2,3, 3, 4,5,0,1,3,2,4,5,3, 3, 5,4,0,2,3,1,3,2,0,0,1,3,4,5,3, 3,3, 0,1,4,5,2,3,0,2,2, 3, 5,4,0,2,3,0,0,1,1,3,2,0,1,2,3,2, 3, 4,5,0,1,3,2,4,5,3, 3, 5,4,0,2,3,0,0,1,1,3,2,0,1,2,3,2, 3, 1,0,2,2,0,0,1,1,2, 3, 0,1,4,5,2,3,0,2,2, 3, 0,1,4,5,2,3,0,2,2, 2,3,2, 2,3,2,4,3,0,1,0};      // 0 (botRight), 1(TopRight), 2(botLeft), 3(topLeft)
            return new[] {color[i], pos[i]};
        }
        
        return new[] {0,0};
    }

        
    // Update is called once per frame
    void Update()
    {
        if(timer > delay && delay != 0){
            timer -= delay;     // reset timer
            delay = 0;
        }
        if(timer>beat && delay == 0){
            int[] arr = boxArr(i);
            int c = arr[0];
            int p = arr[1];
            if(c == 0 || c == 1){
                GameObject cube = Instantiate(cubes[c], points[p]); 
                cube.transform.localPosition = Vector3.zero;
            }
            else if (c == 2){
                if(p == 0){   // blue top left, red top right
                    GameObject cube = Instantiate(cubes[1], points[1]);
                    cube.transform.localPosition = Vector3.zero; 
                    GameObject cube2 = Instantiate(cubes[0], points[3]);
                    cube2.transform.localPosition = Vector3.zero; 
                }
                else if (p == 1){ // blue bot left, red bot right
                    GameObject cube = Instantiate(cubes[1], points[0]);
                    cube.transform.localPosition = Vector3.zero;
                    GameObject cube2 = Instantiate(cubes[0], points[2]);
                    cube2.transform.localPosition = Vector3.zero;
                }
                else if (p == 2){ // blue bot left, red top right
                    GameObject cube = Instantiate(cubes[1], points[1]);
                    cube.transform.localPosition = Vector3.zero; 
                    GameObject cube2 = Instantiate(cubes[0], points[2]);
                    cube2.transform.localPosition = Vector3.zero;
                }
                else if (p == 3){ // blue top left, red bot right
                    GameObject cube = Instantiate(cubes[1], points[0]);
                    cube.transform.localPosition = Vector3.zero; 
                    GameObject cube2 = Instantiate(cubes[0], points[3]);
                    cube2.transform.localPosition = Vector3.zero;
                }
                    
            }
	    timer -= beat;
        i++;
        }

        timer += Time.deltaTime;
        
    }
}

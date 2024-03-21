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

    public PauseMenu targetScript;

    public int[] color = {};
    public int[] pos = {};

    // Start is called before the first frame update
    void Start()
    {
        int diff = PlayerPrefs.GetInt("Difficulty");
        if (diff == 1) //easy
		{
            int i = 0;
            beat = 1.142857;        // (60/105)*2   beat of the song
            delay = (54-9)/8-beat*4; // make shure delay >= 0
        }
		else if (diff == 2) // medium
		{
            int i = 0;
            beat = (0.72289)/2;  // (60/166)*2      beat of the song
            delay = (54-9)/11-beat*5;  // make shure delay >= 0
        }
        else if (diff == 3) //hard
		{
            int i = 0;
            beat = 0.75;    // (60/160)*2           beat of the song
            delay = (54-9)/14-beat*4; // make shure delay >= 0
		}
    }
    private int[] boxArr(int i){
        int diff = PlayerPrefs.GetInt("Difficulty");
        if (diff == 1) // easy
		{
            int[] color = {3,3,0,3,1,3,0,3, 1,3,0,3,0,3,1,3,   1,3,0,3,0,3,0,3,   1,3,0,3,1,3,0,3,   1,0,1,3,0,1,3,0,   0,3,1,1,3,0,3,2,   3,3,1,3,0,3,0,3,   1,3,0,3,1,3,0,2,  1,3,0,3,1,3,1,3,  1,3,0,3,1,3,1,3, 0,3,1,3,0,3,0,3, 2,3,2,3,0,3,1,3, 0,3,1,3,1,3,0,2, 3,0,3,2,2,3,1,3, 3,3,0,3,1,3,1,3, 0,1,3,9};    //0 for blue, 1 for red, 2 for both, 3 for none 
            int[] pos =   {3,3,3,2,2,1,1,0, 0,3,3,3,1,3,4,3,   5,3,3,3,1,3,2,3,   0,3,3,3,0,3,2,3,   0,0,4,3,2,2,3,5,   3,3,1,1,3,4,3,2,   3,3,5,3,0,3,3,3,   1,3,3,3,0,3,2,1,  0,3,3,3,0,3,2,3,  0,3,5,3,0,3,1,3, 4,3,2,3,3,3,2,3, 0,3,1,3,2,3,0,3, 1,3,3,3,4,3,2,1, 3,1,3,5,3,3,3,3, 3,3,2,3,5,3,4,3, 5,2,3,9};      // 0 (botRight), 1(TopRight), 2(botLeft), 3(topLeft)
            return new[] { color[i], pos[i] };
        }
		else if (diff == 2) // medium
		{
            int[] color =   {1,3,3,3,3,3,0,3,1,3,3,3,3,3,3,3,1,3,3,3,3,3,0,3,1,3,3,3,0,3,3,3,1,3,3,3,3,3,0,3,1,3,3,3,0,3,3,3,1,3,3,3,3,3,0,3,1,3,3,3,0,3,3,3,1,3,3,0,1,3,3,1,0,3,3,0,1,3,0,3,1,3,3,0,1,3,3,1,0,3,3,0,1,3,0,3,1,3,0,3,1,3,0,3,1,3,0,3,1,3,0,3,1,0,3,1,1,0,3,1,0,1,3,3,2,3,2,3,2,3,3,3,
                            3,3,3,3,2,3,3,3,3,3,3,3,2,3,3,3,3,3,3,3,2,3,3,3,3,3,3,3,2,3,3,3,3,3,3,3,2,3,3,3,3,3,3,3,2,3,3,3,3,3,3,3,2,3,3,3,3,3,3,3,1,3,3,3,3,3,0,3,1,3,3,3,0,3,3,3,1,3,3,3,3,3,0,3,1,3,3,3,0,3,3,3,1,3,0,3,1,3,0,3,1,3,0,3,1,3,0,3,1,0,3,1,1,0,3,1,0,1,3,3,2,3,2,3,2,3,3,3,3,3,3,3,2,
                            3,3,3,3,3,3,3,2,3,3,3,3,3,3,3,2,3,3,3,3,3,3,3,2,3,3,9};    // 0 for blue, 1 for red, 2 for both, 3 for none 
            int[] pos =     {0,3,3,3,3,3,3,3,0,3,3,3,3,3,3,3,1,3,3,3,3,3,2,3,0,3,3,3,1,3,3,3,0,3,3,3,3,3,3,3,0,3,3,3,2,3,3,3,1,3,3,3,3,3,2,3,0,3,3,3,1,3,3,3,0,3,3,2,1,3,3,1,2,3,3,3,0,3,2,3,0,3,3,2,1,3,3,1,2,3,3,3,0,3,2,3,0,3,2,3,1,3,3,3,0,3,2,3,1,3,3,3,1,2,0,1,0,2,3,0,2,1,3,3,1,3,0,3,1,3,3,3,
                            3,3,3,3,2,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,0,3,3,3,3,3,3,3,1,3,3,3,3,3,3,3,2,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,0,3,3,3,3,3,3,3,0,3,3,3,3,3,3,3,0,3,3,3,2,3,3,3,1,3,3,3,3,3,2,3,0,3,3,3,1,3,3,3,0,3,2,3,1,3,3,3,0,3,2,3,1,3,3,3,1,2,0,1,0,2,3,0,2,1,3,3,1,3,0,3,1,3,3,3,3,3,3,3,2,
                            3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,0,3,3,3,3,3,3,3,1,3,3,9};      // 0 (botRight), 1(TopRight), 2(botLeft), 3(topLeft)
            return new[] {color[i], pos[i]};
        }
        else if (diff == 3) // hard
		{   
            int[] color =   {1,0,2,0,1,2,1,0,2,0,1,2,0,1,2, 3, 2,2,2,2, 3, 1,0,2,2,2,2,1,0,2, 3, 1,0,2,0,1,2,1,0,2,0,1,2,0,1,2, 3,3, 2,2,0,1,2,2,0,1,2, 3, 1,0,2,1,1,2,0,0,2,1,1,2,2,2,2,2, 3, 1,0,2,2,2,2,1,0,2, 3, 1,0,2,1,1,2,0,0,2,1,1,2,2,2,2,2, 3, 1,0,2,2,0,0,1,1,2, 3, 2,2,0,1,2,2,0,1,2, 3, 2,2,0,1,2,2,0,1,2, 2,2,2, 2,2,2,0,2,2,2,2,3,9};    // 0 for blue, 1 for red, 2 for both, 3 for none 
            int[] pos =     {1,0,0,2,3,1,1,0,0,2,3,3,4,5,3, 3, 0,1,2,3, 3, 4,5,0,1,3,2,4,5,3, 3, 5,4,0,2,3,1,3,2,0,0,1,3,4,5,3, 3,3, 0,1,4,5,2,3,0,2,2, 3, 5,4,0,2,3,0,0,1,1,3,2,0,1,2,3,2, 3, 4,5,0,1,3,2,4,5,3, 3, 5,4,0,2,3,0,0,1,1,3,2,0,1,2,3,2, 3, 1,0,2,2,0,0,1,1,2, 3, 0,1,4,5,2,3,0,2,2, 3, 0,1,4,5,2,3,0,2,2, 2,3,2, 2,3,2,4,3,0,1,0,3,9};      // 0 (botRight), 1(TopRight), 2(botLeft), 3(topLeft)
            return new[] {color[i], pos[i]};
        }
        
        return new[] {9,9};
    }

        
    // Update is called once per frame
    void Update()
    {
        if(timer > delay && delay != 0){    // delay to match the first box and sword colision with a fitting point in the song 
            timer -= delay;     
            delay = 0;
        }
        if(timer>beat && delay == 0){ // wait for next beat after delay time
            int[] arr = boxArr(i);
            int c = arr[0];
            int p = arr[1];
            if(c == 0 || c == 1){
                GameObject cube = Instantiate(cubes[c], points[p]);     // spawns a cube with a color blue ore read at point p
                cube.transform.localPosition = Vector3.zero;
            }
            else if (c == 2){ // combination of two boxes. Easy to add more cobinations if wanted
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
            else if(c==9){      // Pauses the game if the int in col list is 9
                targetScript.Pause();
            }
	    timer -= beat;      // reset timer
        i++;                // next cube
        }

        timer += Time.deltaTime;
        
    }
}

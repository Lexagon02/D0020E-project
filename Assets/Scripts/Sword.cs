using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;
using UnityEditor;
using System;
using System.IO;
using System.Diagnostics;






public class swordObject : MonoBehaviour
{
    public Rigidbody m_sword;
    int redCoord;
    private void Start()
    {
        m_sword = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        int[] coords = new int[6];
        int i = 0;
        try
        {
            using (var reader = new StreamReader(Application.streamingAssetsPath + "/" + "coordinates.csv"))
            {
                while (!reader.EndOfStream)
                {
                    coords[i] = int.Parse(reader.ReadLine());
                    i++;

                    // do something with line... could even do a yield here if you're reading a large file
                }
            }
            if (gameObject.tag == "redPlayer")
            {
                setCoord(coords[0], coords[1], coords[2]);
            }
            else if (gameObject.tag == "bluePlayer")
            {
                setCoord(coords[3], coords[4], coords[5]);
            }
        }
        catch (Exception e)
        {

        }


    }
    private void setCoord(float x, float y, float angle)
    {
        Vector3 curpos = gameObject.GetComponent<Rigidbody>().position; //Get the current pos from sword
        if (x == 0) { x = curpos.x; }//If x is 0, leave sword at current pos
        else { x = 57 - x / 20; }

        if (y == 0) { y = curpos.y; }//If y is 0, leave sword at current pos
        else { y = 12 - y / 20; }

        Vector3 newAcc = 5.0f * new Vector3(x - curpos.x, y - curpos.y, 0f); //Calculate new vector
        GetComponent<Rigidbody>().velocity = newAcc;  //Set new velocity
        if (angle != 0)//If angle is zero, dont change it
        {
            GetComponent<Rigidbody>().MoveRotation(UnityEngine.Quaternion.Euler(0, 0, angle + 180));//Set new rotation
        }

    }
}


using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;
using UnityEditor.Scripting.Python;
using UnityEditor;
using static System.Net.Mime.MediaTypeNames;


	


public class swordObject : MonoBehaviour
{
    public Rigidbody m_sword;
    int redCoord;
    //redCoord = PythonSettings.createInstance(int);
    private void Start() // load sword component
    {
        m_sword = GetComponent<Rigidbody>();
    }
    private void Update() // get position for the sword from the python script 
    {
         [MenuItem("Python Scripts/get")]
            static void get()
            {
                string path= UnityEngine.Application.dataPath;
                PythonRunner.RunFile(path + "/get.py");
            }
            get(); // run python script get.py each frame
    }
}

using UnityEditor;
using UnityEditor.Scripting.Python;

public class MenuItem_Get_Class//Script for running get.py in unity, which recieves the value from colortracking.py
{
   [MenuItem("Python Scripts/Get")]
   public static void Get()
   {
       PythonRunner.RunFile("Assets/get.py");
       }
};

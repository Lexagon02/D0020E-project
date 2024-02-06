using UnityEditor;
using UnityEditor.Scripting.Python;

public class MenuItem_Get_Class
{
   [MenuItem("Python Scripts/Get")]
   public static void Get()
   {
       PythonRunner.RunFile("Assets/get.py");
       }
};

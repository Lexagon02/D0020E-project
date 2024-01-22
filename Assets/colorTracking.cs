using UnityEditor;
using UnityEditor.Scripting.Python;

public class MenuItem_colorTracking_Class
{
   [MenuItem("Python Scripts/colorTracking")]
   public static void colorTracking()
   {
       PythonRunner.RunFile("Assets/colorTracking.py");
       }
};

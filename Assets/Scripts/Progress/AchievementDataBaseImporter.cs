using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

[CustomEditor(typeof(AchievementDataBase))]
public class AchievementDataBaseImporter : Editor
{
    AchievementDataBase dataBase;

    private void OnEnable()
    {
        dataBase = target as AchievementDataBase;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if(GUILayout.Button("Import Enum to file"))
        {
            ImportAchivement();
        }

    }
    public void ImportAchivement()
    {
        string path = Path.Combine(Application.dataPath, "AchievementsID.cs");
        string codeBody = "public enum Achievement\n{";
        foreach (Achievement item in dataBase.achivements)
        {
            codeBody += item.id + ",";
        }
        codeBody += "\n}";
        File.WriteAllText(path, codeBody);
        AssetDatabase.ImportAsset("Assets/Scripts/Progress/AchievementsID.cs");
    }
}

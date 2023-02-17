using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable , CreateAssetMenu(fileName = "AchievementsDataBase")]
public class AchievementDataBase: ScriptableObject
{
    public Achievement[] achievements = new Achievement[10];
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementLoader : MonoBehaviour
{
    public List<AchievementBehavior> gameAchievements;
    [SerializeField] AchievementDataBase dataBase;

    private void Start()
    {
        SaveAchievements();
    }
    public void SaveAchievements()
    {
        for (int i = 0; i < gameAchievements.Count; i++)
        {
            dataBase.achievements[i] = gameAchievements[i].achievement;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementLoader : MonoBehaviour
{
    public static AchievementLoader instance;
    public List<AchievementBehavior> gameAchievements;
    [SerializeField] AchievementDataBase dataBase;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else instance = this;
    }
    public void SaveAchievements()
    {
        for (int i = 0; i < gameAchievements.Count; i++)
        {
            dataBase.achievements[i] = gameAchievements[i].achievement;
        }
    }
}

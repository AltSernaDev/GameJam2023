using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementBehavior : MonoBehaviour
{
    [Header("UI Properties")]
    public Text titleLabel;
    public Sprite lockedIcon, unlockedIcon;
    public List<GameObject> secondaryObjects;

    [Header("Achievement Config")]
    bool isLocked;
    public Achievement achievement;

    public void Refresh()
    {
        isLocked = achievement.isLocked;
        switch (isLocked)
        {
            case true:
                GetComponent<Image>().sprite = lockedIcon;
                titleLabel.text = "";

                if (secondaryObjects.Count != 0)
                {
                    foreach (GameObject item in secondaryObjects)
                    {
                        item.SetActive(false);
                    }
                }
                break;

            case false:
                GetComponent<Image>().sprite = unlockedIcon;
                titleLabel.text = achievement.title;

                if (secondaryObjects.Count != 0)
                {
                    foreach (GameObject item in secondaryObjects)
                    {
                        item.SetActive(true);
                    }
                }
                break;
        }
    }

    private void OnValidate()
    {
        Refresh();
    }

    public void UnlockedAchievement()
    {
        achievement.isLocked = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementBehavior : MonoBehaviour
{
    [Header("UI Properties")]
    public Text titleLabel;
    public Sprite lockedIcon, unlockedIcon;

    [Header("Achievement Config")]
    public bool isLocked;
    public Achievement achievement;

    public void Refresh()
    {
        titleLabel.text = achievement.title;

        switch (isLocked)
        {
            case true:
                GetComponent<Image>().sprite = lockedIcon;
                break;
            case false:
                GetComponent<Image>().sprite = unlockedIcon;
                break;
        }
    }

    private void OnValidate()
    {
        Refresh();
    }
}

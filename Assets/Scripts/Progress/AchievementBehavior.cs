using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementBehavior : MonoBehaviour
{
    [Header("UI Properties")]
    public Text titleLabel;
    public Text descriptionLabel;
    public Image lockedIcon, unlockedImage;

    public bool isLocked;
    public Achievement achievement;

    public void Refresh()
    {
        titleLabel.text = achievement.title;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Button hudPause;
    [SerializeField] private Button unpauseButton;
    [SerializeField] private GameObject panelMenu;

    public void PauseGame()
    {
        Time.timeScale = 0;
        panelMenu.SetActive(true);
    }

    public void UnPauseGame()
    {
        Time.timeScale = 0;
        panelMenu.SetActive(false);
    }
}

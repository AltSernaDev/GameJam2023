using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject panelMenu;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            PauseGame();
        }
    }
    public void PauseGame()
    {
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        panelMenu.SetActive(true);
    }

    public void UnPauseGame()
    {
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        panelMenu.SetActive(false);
    }

    public void Play()
    {
        ScenesManager.instance.LoadScene(1);
    }
    public void Settings()
    {

    }
    public void ExitGame()
    {
        Application.Quit();
    }
}

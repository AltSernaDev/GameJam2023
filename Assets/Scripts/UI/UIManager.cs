using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu, progressionMap;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            pauseMenu.SetActive(true);
            PauseGame();            
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            progressionMap.SetActive(true);
            ShowProgression();            
        }
    }
    public void PauseGame()
    {
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void UnPauseGame()
    {
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        pauseMenu.SetActive(false);
        progressionMap.SetActive(false);
    }

    public void Play()
    {
        ScenesManager.instance.LoadScene(1);
    }
    public void Settings()
    {

    }
    public void ShowProgression()
    {
        PauseGame();

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}

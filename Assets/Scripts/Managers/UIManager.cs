using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; } = new UIManager();

    public GameObject deathScreen;
    public GameObject pauseMenu;

    void Awake()
    {
        Instance.deathScreen = deathScreen;
        Instance.pauseMenu = pauseMenu;
    }

    public void openUI(GameObject ui)
    {
        ui.SetActive(true);
    }

    public void closeUI(GameObject ui)
    {
        ui.SetActive(false);
    }

    // Death Screen
    public void openDeathScreen()
    {
        Time.timeScale = 0f;
        openUI(deathScreen);
    }

    public void closeDeathScreen()
    {
        Time.timeScale = 1f;
        closeUI(deathScreen);
    }

    public void toggleDeathScreen()
    {
        if(deathScreen.active == false)
            openDeathScreen();
        else
            closeDeathScreen();
    }

    public void respawn()
    {
        foreach(Scene scene in SceneManager.GetAllScenes())
            if(scene.name != "UI")
                SceneManager.LoadScene(scene.buildIndex);
    }

    public void mainMenu()
    {
        SceneManager.LoadScene(0);
    }

        // Pause screen
    public void openPauseMenu()
    {
        closeDeathScreen();
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
    }

    public void closePauseMenu()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
    }

    public void togglePauseMenu()
    {
        if (pauseMenu.active == false)
            openPauseMenu();
        else
            closePauseMenu();
    }
}

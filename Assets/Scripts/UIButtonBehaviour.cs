using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIButtonBehaviour : MonoBehaviour
{
    public void OnReturn()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }

    public void OnPlay()
    {
        // will first check player pref for what level you are on but for now just load tutorial level
        SceneManager.LoadScene("TutorialLevel");
    }

    public void OnCredits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void OnExit()
    {
        Application.Quit();
    }

    public void OnResume()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }
}

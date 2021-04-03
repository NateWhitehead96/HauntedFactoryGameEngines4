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
        Destroy(FindObjectOfType<MenuMusicScript>().gameObject);
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

    public void OnLoad()
    {
        print("Loading");
        Destroy(FindObjectOfType<MenuMusicScript>().gameObject);
        if (PlayerPrefs.HasKey("CurrentLevel"))
        {
            //PlayerController.currentLevel = PlayerPrefs.GetInt("CurrentLevel");
            //PlayerController.levelsComplete = PlayerPrefs.GetInt("LevelsComplete");
            //PlayerController.currentHealth = PlayerPrefs.GetInt("CurrentHealth");
            //PlayerController.Damage = PlayerPrefs.GetInt("Damage");
            //PlayerController.AttackSpeed = PlayerPrefs.GetFloat("AttackSpeed");
            if(PlayerPrefs.GetInt("CurrentLevel") == 1)
            {
                SceneManager.LoadScene("Level1");
            }
            if (PlayerPrefs.GetInt("CurrentLevel") == 2)
            {
                SceneManager.LoadScene("Level2");
            }
            if (PlayerPrefs.GetInt("CurrentLevel") == 3)
            {
                SceneManager.LoadScene("Level3");
            }
            if (PlayerPrefs.GetInt("CurrentLevel") == 4)
            {
                SceneManager.LoadScene("FinalLevel");
            }
        }
        else
            OnPlay();
    }

    public void OnResetSave()
    {
        PlayerPrefs.DeleteAll();
    }

    public void TurnOnPower()
    {
        SceneManager.LoadScene("TurnOnGenerator");
    }

    public void DontTurnPower()
    {
        SceneManager.LoadScene("TurnOffGenerator");
    }
}

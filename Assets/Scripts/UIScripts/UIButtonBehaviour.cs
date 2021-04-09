using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIButtonBehaviour : MonoBehaviour
{
    public Animator Transition;
   
    public void OnReturn()
    {
        Time.timeScale = 1;
        StartCoroutine(Fade());
        SceneManager.LoadScene("MainMenu");
    }

    public void OnPlay()
    {
        // will first check player pref for what level you are on but for now just load tutorial level
        Destroy(FindObjectOfType<MenuMusicScript>().gameObject);
        StartCoroutine(Fade());
        SceneManager.LoadScene("TutorialLevel");
    }

    public void OnCredits()
    {
        StartCoroutine(Fade());
        SceneManager.LoadScene("Credits");
    }

    public void OnExit()
    {
        StartCoroutine(Fade());
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
        StartCoroutine(Fade());
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
        //StartCoroutine(Fade());
        SceneManager.LoadScene("TurnOnGenerator");
    }

    public void DontTurnPower()
    {
        //StartCoroutine(Fade());
        SceneManager.LoadScene("TurnOffGenerator");
    }

    IEnumerator Fade()
    {
        Transition.SetBool("SceneExit", true);
        yield return new WaitForSeconds(10);
    }
}

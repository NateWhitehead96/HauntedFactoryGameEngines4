using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMover : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("TutorialLevel") && other.gameObject.CompareTag("Player"))
        {
            int randomLevel = Random.Range(0, 3);
            if(randomLevel == 0)
            {
                // open level 1
                SceneManager.LoadScene("Level1");
            }
            if(randomLevel == 1)
            {
                //pen level 2
                SceneManager.LoadScene("Level2");
            }
            if(randomLevel == 2)
            {
                //open level 3
                SceneManager.LoadScene("Level3");
            }
            
        }
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Level1") && other.gameObject.CompareTag("Player"))
        {
            int randomLevel = Random.Range(0, 2);
            PlayerController.levelsComplete += 1;
            if(randomLevel == 0)
            {
                //open level 2
                SceneManager.LoadScene("Level2");
            }
            else
                SceneManager.LoadScene("Level3");

        }
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Level2") && other.gameObject.CompareTag("Player"))
        {
            int randomLevel = Random.Range(0, 2);
            PlayerController.levelsComplete += 1;
            if (randomLevel == 0)
            {
                //open level 1
                SceneManager.LoadScene("Level1");
            }
            else
                SceneManager.LoadScene("Level3");
        }
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Level3") && other.gameObject.CompareTag("Player"))
        {
            int randomLevel = Random.Range(0, 2);
            PlayerController.levelsComplete += 1;
            if (randomLevel == 0)
            {
                //open level 1
                SceneManager.LoadScene("Level1");
            }
            else
                SceneManager.LoadScene("Level2");
        }
    }
}

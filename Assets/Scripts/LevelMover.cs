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
            SceneManager.LoadScene("SampleScene");
        }
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("SampleScene") && other.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("Level2");
        }
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Level2") && other.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}

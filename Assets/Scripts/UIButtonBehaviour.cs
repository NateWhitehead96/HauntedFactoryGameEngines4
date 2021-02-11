using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIButtonBehaviour : MonoBehaviour
{
    public void OnReturn()
    {
        SceneManager.LoadScene("TutorialLevel");
    }
}

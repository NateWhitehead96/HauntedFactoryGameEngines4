using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SignInstructionScript : MonoBehaviour
{
    public Text displayText;
    [SerializeField]
    private int signNumber;

    private void Start()
    {
        displayText.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(signNumber == 1 && other.gameObject.CompareTag("Player"))
        {
            displayText.gameObject.SetActive(true);
            displayText.text = "If you are reading this you are the new night watchman. You can move with the WASD keys, or the left stick on gamepad.";
        }
        if (signNumber == 2 && other.gameObject.CompareTag("Player"))
        {
            displayText.gameObject.SetActive(true);
            displayText.text = "Ghosts have taken over, you must find the power generator and turn it back on to eradicate the paranormal entities! Also use left click or the A button to fire.";
        }
        if (signNumber == 3 && other.gameObject.CompareTag("Player"))
        {
            displayText.gameObject.SetActive(true);
            displayText.text = "These are the ghost types, green the average ghost, red the heavy, and white the ranger. Be careful watchman!";
        }
    }

    private void OnTriggerExit(Collider other)
    {
        displayText.gameObject.SetActive(false);
    }
}

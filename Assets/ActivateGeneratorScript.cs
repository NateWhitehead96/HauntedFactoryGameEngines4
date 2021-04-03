using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateGeneratorScript : MonoBehaviour
{
    public Canvas WinCanvas;
    public Canvas PromptCanvas;
    // Start is called before the first frame update
    void Start()
    {
        WinCanvas.gameObject.SetActive(false);
        PromptCanvas.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PromptCanvas.gameObject.SetActive(true);
        }
        if (other.gameObject.CompareTag("Player") && FindObjectOfType<ReactorRoomScript>().LightsGreen == 6)
        {
            // do stuff
            WinCanvas.gameObject.SetActive(true);
            PromptCanvas.gameObject.SetActive(false);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // do stuff
            WinCanvas.gameObject.SetActive(false);
            PromptCanvas.gameObject.SetActive(false);
        }
    }
}

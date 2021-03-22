using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuButtonManager : MonoBehaviour
{
    public Button loadGameButton;
    public Color buttonColor;
    // Start is called before the first frame update
    void Start()
    {
        if(!PlayerPrefs.HasKey("CurrentLevel"))
        {
            loadGameButton.interactable = false;
            gameObject.GetComponent<Image>().color = buttonColor;
            //loadGameButton.colors = Color.clear;
        }
        else
        {
            loadGameButton.interactable = true;
            gameObject.GetComponent<Image>().color = Color.white;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

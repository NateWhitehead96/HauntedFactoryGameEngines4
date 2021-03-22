using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavingScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            // save all the data when player runs into thing
            PlayerPrefs.SetInt("CurrentLevel", PlayerController.currentLevel);
            PlayerPrefs.SetInt("LevelsComplete", PlayerController.levelsComplete);
            PlayerPrefs.SetInt("CurrentHealth", PlayerController.currentHealth);
            PlayerPrefs.SetInt("Damage", PlayerController.Damage);
            PlayerPrefs.SetFloat("AttackSpeed", PlayerController.AttackSpeed);
            print("Saving");
        }
    }
}

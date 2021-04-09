using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpDisplay : MonoBehaviour
{
    public GameObject[] DamageBonus;
    public GameObject[] AttackSpeedBonus;
    

    // Update is called once per frame
    void Update()
    {
        DamageShow();

        AttackSpeedShow();
    }

    private void DamageShow()
    {
        if (PlayerController.Damage >= 2)
        {
            DamageBonus[0].SetActive(true);
        }
        if (PlayerController.Damage >= 3)
        {
            DamageBonus[1].SetActive(true);
        }
        if (PlayerController.Damage >= 4)
        {
            DamageBonus[2].SetActive(true);
        }
    }

    private void AttackSpeedShow()
    {
        if (PlayerController.AttackSpeed <= 0.9)
        {
            AttackSpeedBonus[0].SetActive(true);
        }
        if (PlayerController.AttackSpeed <= 0.7)
        {
            AttackSpeedBonus[1].SetActive(true);
        }
        if (PlayerController.AttackSpeed <= 0.5)
        {
            AttackSpeedBonus[2].SetActive(true);
        }
    }
}

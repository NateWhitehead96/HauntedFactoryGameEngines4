using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PickupType
{
    Health,
    AttackSpeed,
    Damage
}
public class PickupScript : MonoBehaviour
{
    private MeshRenderer mesh;
    public Material[] material;
    public PickupType type;
    // Start is called before the first frame update
    void Start()
    {
        mesh = GetComponent<MeshRenderer>();
        SetType();
        if (type == PickupType.Health)
        {
            mesh.material = material[0];
        }
        if (type == PickupType.AttackSpeed)
        {
            mesh.material = material[1];
        }
        if (type == PickupType.Damage)
        {
            mesh.material = material[2];
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            if (type == PickupType.Health)
            {
                PlayerController.currentHealth = 10; // full heal player
            }
            if (type == PickupType.AttackSpeed)
            {
                PlayerController.AttackSpeed -= 0.2f; // make the cooldown on the fire less
            }
            if (type == PickupType.Damage)
            {
                PlayerController.Damage += 1; // add some DAMAGE
            }
            Destroy(gameObject);
        }
    }

    private void SetType()
    {
        int randType = Random.Range(0, 3);
        if (randType == 0)
        {
            type = PickupType.Health;
        }
        if (randType == 1)
        {
            type = PickupType.AttackSpeed;
        }
        if (randType == 2)
        {
            type = PickupType.Damage;
        }
    }
}

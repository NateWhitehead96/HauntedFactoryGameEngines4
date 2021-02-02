using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomBehaviour : MonoBehaviour
{
    public GameObject[] spawnPoints;
    public GameObject Ghost;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            //int spawnChance = Random.Range(0, 1);
            //if(spawnChance == 1)
            //{
                Instantiate(Ghost, spawnPoints[i].transform.position, Quaternion.Euler(new Vector3(-90, 0, 0)));
            //}
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMaker : MonoBehaviour
{
    const int rows = 5;
    const int cols = 5;

    public float size = 12f;

    public GameObject[] Rooms;

    public Transform Origin;

    // Start is called before the first frame update
    void Start()
    {
        //for (int x = 0; x < rows; x++)
        //{
        //    for (int z = 0; z < cols; z++)
        //    {
        //        int randomRoom = Random.Range(0, Rooms.Length);
        //        Vector3 newPos = new Vector3(x * 30 + 30f, 0, z * 30 - 30f);
        //        Instantiate(Rooms[randomRoom], newPos, Quaternion.identity);
        //    }
        //}
        int randomLevel = Random.Range(0, Rooms.Length);
        Instantiate(Rooms[randomLevel], Origin.position, Quaternion.identity);
    }

    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactorRoomScript : MonoBehaviour
{
    public GameObject[] spawnPoint;
    public GameObject[] Ghost;
    public GameObject[] Lights;
    //public Canvas WinCanvas;

    private float SpawnTime;
    public int LightsGreen;
    private bool SpawnGhosts = true;
    // Start is called before the first frame update
    void Start()
    {
        //WinCanvas.gameObject.SetActive(false);
        SpawnTime = 0f;
        LightsGreen = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (SpawnGhosts)
        {
            if (SpawnTime >= 5)
            {
                for (int i = 0; i < Lights.Length; i++)
                {
                    if (Lights[i].GetComponent<LightController>().turnedOff) // the light was switched to green
                    {
                        int randomGhost = Random.Range(0, Ghost.Length);
                        int randomSpawn = Random.Range(0, spawnPoint.Length);
                        Instantiate(Ghost[randomGhost], spawnPoint[randomSpawn].transform.position, Quaternion.Euler(new Vector3(-90, 0, 0)));
                        LightsGreen++;
                    }
                }
                print(LightsGreen);
                if (LightsGreen != 6)
                {
                    LightsGreen = 0;
                }
                SpawnTime = 0;
            }
            if (SpawnGhosts)
            {
                SpawnTime += Time.deltaTime;
            }
            if (LightsGreen == 6)
            {
                SpawnGhosts = false;
            }
        }
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if(other.gameObject.CompareTag("Player") && LightsGreen == 6)
    //    {
    //        // do stuff
    //        WinCanvas.gameObject.SetActive(true);
    //    }
    //}
    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.gameObject.CompareTag("Player"))
    //    {
    //        // do stuff
    //        WinCanvas.gameObject.SetActive(false);
    //    }
    //}
}

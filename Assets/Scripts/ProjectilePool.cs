using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilePool : MonoBehaviour
{
    public static ProjectilePool Instance;
    public List<GameObject> bullets;
    [SerializeField]
    public GameObject bulletToPool;
    public int bulletAmount = 25;

    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        bullets = new List<GameObject>();
        GameObject temp;
        for (int i = 0; i < bulletAmount; i++)
        {
            temp = Instantiate(bulletToPool);
            temp.SetActive(false);
            bullets.Add(temp);
        }
    }

    public GameObject GetBullet()
    {
        for (int i = 0; i < bulletAmount; i++)
        {
            if(!bullets[i].activeInHierarchy)
            {
                return bullets[i];
            }
        }
        return null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

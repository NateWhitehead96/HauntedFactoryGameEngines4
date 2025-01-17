using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{

    public Rigidbody rigidbody;
    public int maxSpeed = 5;

    private float lifetimeCounter = 0f;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        transform.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        rigidbody.AddForce((transform.forward * maxSpeed));
        //if(lifetimeCounter >= 5f)
        //{
        //    gameObject.SetActive(false);
        //}
        //if (gameObject.activeInHierarchy)
        //{
        //    lifetimeCounter += Time.deltaTime;

        //}
        //else
        //    lifetimeCounter = 0;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("enemy") || collision.gameObject.CompareTag("Button"))
        {
            //gameObject.transform.position = Vector3.zero;
            //gameObject.transform.rotation = Quaternion.Euler(0,0,0);
            //maxSpeed = 0;
            rigidbody.velocity = Vector3.zero;
            gameObject.SetActive(false);
        }
    }
}

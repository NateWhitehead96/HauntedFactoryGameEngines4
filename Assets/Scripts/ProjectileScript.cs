using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{

    public Rigidbody rigidbody;
    public int maxSpeed = 10;

    

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
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GhostType
{
    REGULAR,
    RANGED,
    HEAVY,
    COUNT
}
public class GhostController : MonoBehaviour
{

    public Transform Player;

    private float turnSpeed;
    private Vector3 direction;
    private Rigidbody rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        transform.parent = null;
        rigidbody = GetComponent<Rigidbody>();
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        direction = Player.position - rigidbody.position;
        direction.Normalize();
        transform.rotation = Quaternion.LookRotation(new Vector3(direction.x, direction.y + 90f, direction.z));
        float xDistance = Mathf.Abs(transform.position.x - Player.position.x);
        float zDistance = Mathf.Abs(transform.position.z - Player.position.z);
        if (xDistance < 8f || zDistance < 8f)
        {
            transform.position = Vector3.MoveTowards(transform.position, Player.position, 1 * Time.deltaTime);
        }
        
        //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), turnSpeed * Time.deltaTime);
        //transform.rotation = Quaternion.Euler(targetDirection.x, targetDirection.y, targetDirection.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Enemy hit");
        if (other.gameObject.CompareTag("Projectile"))
        {
            Destroy(gameObject);
        }
    }
}

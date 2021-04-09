using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

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

    private NavMeshAgent meshAgent;

    private Animator animator;
    public bool inAction;

    [SerializeField] private int Health;
    [SerializeField] private float DistanceToPlayer = 10f;

    public GameObject DeathEffect;
    public AudioSource DeathSound;

    // Start is called before the first frame update
    void Start()
    {
        transform.parent = null;
        inAction = false;
        rigidbody = GetComponent<Rigidbody>();
        meshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        if (SceneManager.GetSceneByName("FinalLevel") == SceneManager.GetActiveScene())
        {
            DistanceToPlayer = 200f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        direction = Player.position - rigidbody.position;
        direction.Normalize();
        transform.rotation = Quaternion.LookRotation(new Vector3(direction.x, direction.y, direction.z));
        float xDistance = Mathf.Abs(transform.position.x - Player.position.x);
        float zDistance = Mathf.Abs(transform.position.z - Player.position.z);
        //print(xDistance);
        if (xDistance < DistanceToPlayer && zDistance < DistanceToPlayer && inAction == false)
        {
            //transform.position = Vector3.MoveTowards(transform.position, Player.position, 1 * Time.deltaTime);
            meshAgent.SetDestination(Player.transform.position);
            animator.SetBool("Moving", true);
        }
        else
            animator.SetBool("Moving", false);
        
        //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), turnSpeed * Time.deltaTime);
        //transform.rotation = Quaternion.Euler(targetDirection.x, targetDirection.y, targetDirection.z);
        if(Health <= 0)
        {
            DeathSound.Play();
            Instantiate(DeathEffect, transform.position, Quaternion.identity);
            StartCoroutine(Death());
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Enemy hit");
        if (other.gameObject.CompareTag("Projectile"))
        {
            //Destroy(gameObject);
            Health -= PlayerController.Damage;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            inAction = true;
            animator.SetBool("Moving", false);
            animator.SetBool("Attacking", true);
            collision.gameObject.GetComponent<PlayerController>().GetHurt();
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //animator.SetBool("Moving", false);
            inAction = false;
            animator.SetBool("Attacking", false);
        }
    }

    IEnumerator Death()
    {
        inAction = true;
        yield return new WaitForSeconds(1);
        
        Destroy(gameObject);
    }
}

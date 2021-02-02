using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public bool isFiring;

    [SerializeField]
    private float moveSpeed = 5f;
    private Transform playerTransform;

    public float VerticalSensitivity = 20f;
    public float HorizontalSensitivity = 20f;

    private Vector2 moveVector = Vector2.zero;
    private Vector2 lookVector = Vector2.zero;
    private Vector3 moveDirection = Vector3.zero;

    private Rigidbody playerRigidbody;
    public Light flashlight;

    public Transform playerSpawn;

    public InputAction fireInput;
    public Transform bulletSpot;
    public GameObject projectile;

    private void Awake()
    {
        playerTransform = transform;
        playerRigidbody = GetComponent<Rigidbody>();
        //fireInput = GetComponent<InputAction>();
    }

    public void OnMove(InputValue value)
    {
        moveVector = value.Get<Vector2>();
    }

    public void OnLook(InputValue value)
    {
        lookVector = value.Get<Vector2>();
    }
    
    //public void OnFire(InputValue value)
    //{
    //    PlayerInputs.performed += value;
    //    if (value.performed)
    //    {
    //        isFiring = true;
    //    }
    //    else if(value.canceled)
    //    {
    //        isFiring = false;
    //    }
    //}

    private void Update()
    {
        moveDirection = playerTransform.forward * moveVector.y + playerTransform.right * moveVector.x; // get players move direction
        Vector3 movementDirection = moveDirection * (moveSpeed * Time.deltaTime);
        playerTransform.position += movementDirection;
        float RotationX = lookVector.x * HorizontalSensitivity * Time.deltaTime;
        //float RotationY = lookVector.y * VerticalSensitivity * Time.deltaTime;
        Vector3 PlayerRotation = playerTransform.rotation.eulerAngles;
        //PlayerRotation.x -= RotationY;
        PlayerRotation.y += RotationX;
        playerTransform.rotation = Quaternion.Euler(PlayerRotation);

        
        if(fireInput.triggered)
        {
            StartCoroutine(Fire());
        }
        //playerTransform.rotation = lookVector * Time.deltaTime;
    }

    IEnumerator Fire()
    {
        flashlight.intensity = 5;
        yield return new WaitForSeconds(1f);
        projectile = ProjectilePool.Instance.GetBullet();
        if(projectile != null)
        {
            projectile.transform.position = bulletSpot.position;
            projectile.transform.rotation = bulletSpot.rotation;
            //projectile.GetComponent<ProjectileScript>().maxSpeed = 10;
            projectile.SetActive(true);
        }
        flashlight.intensity = 3;
    }

    private void OnEnable()
    {
        fireInput.Enable();
    }

    private void OnDisable()
    {
        fireInput.Disable();
    }

    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("Working");
        if(collision.gameObject.CompareTag("DeathPlane"))
        {
            transform.position = playerSpawn.position;
        }
    }
}

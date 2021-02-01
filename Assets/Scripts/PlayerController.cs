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

    private void Awake()
    {
        playerTransform = transform;
        playerRigidbody = GetComponent<Rigidbody>();

    }

    public void OnMove(InputValue value)
    {
        Debug.Log(value.Get());
        moveVector = value.Get<Vector2>();
    }

    public void OnLook(InputValue value)
    {
        Debug.Log(value.Get());
        lookVector = value.Get<Vector2>();
    }
    
    public void OnFire(InputValue value)
    {
        isFiring = value.Get<bool>();
    }

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

        if(isFiring)
        {
            flashlight.intensity = 5;
        }
        else
        {
            flashlight.intensity = 3;
        }
        //playerTransform.rotation = lookVector * Time.deltaTime;
    }
}

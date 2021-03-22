using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public bool isFiring;
    public bool isHurting;

    private Animator playerAnimator;

    [SerializeField]
    private float moveSpeed = 5f;
    public Transform playerTransform;

    public float VerticalSensitivity = 20f;
    public float HorizontalSensitivity = 20f;
    // Direction variables
    private Vector2 moveVector = Vector2.zero;
    private Vector2 lookVector = Vector2.zero;
    private Vector3 moveDirection = Vector3.zero;

    private Rigidbody playerRigidbody;
    public Light flashlight;
    // Spawn point if player dies or goes out of bounds
    public Transform playerSpawn;
    // Shooting variables
    public InputAction fireInput;
    public Transform bulletSpot;
    public GameObject projectile;
    public static float AttackSpeed = 1f;
    public static int Damage = 1;
    // UI Variables
    public int maxHealth = 10;
    public static int currentHealth = 10;
    public Slider healthBar;
    public Canvas pauseCanvas;

    // Room completion tally
    public static int levelsComplete;
    public static int currentLevel;
    private void Awake()
    {
        playerTransform = transform;
        playerRigidbody = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
        //fireInput = GetComponent<InputAction>();
    }
    private void Start()
    {
        LoadAllSavedData();
        pauseCanvas.gameObject.SetActive(false);
        if(SceneManager.GetSceneByName("TutorialLevel") == SceneManager.GetActiveScene())
        {
            currentHealth = maxHealth;
            levelsComplete = 0;
        }
        healthBar.maxValue = maxHealth;
        healthBar.value = currentHealth;
        print(levelsComplete);
    }
    ///////////////////////// INPUT SYSTEM /////////////////////////////
    public void OnMove(InputValue value)
    {
        moveVector = value.Get<Vector2>();
        playerAnimator.SetBool("IsRunning", true);
        if(value.Get<Vector2>() == Vector2.zero)
        {
            playerAnimator.SetBool("IsRunning", false);
        }
    }

    public void OnLook(InputValue value)
    {
        lookVector = value.Get<Vector2>();
    }

    public void OnFire(InputValue value)
    {
        if (value.isPressed && isFiring == false)
        {
            StartCoroutine(Fire());
        }
       
    }

    public void OnPause(InputValue pressed)
    {
        if(pressed.isPressed)
        {
            pauseCanvas.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
    }
    ///////////////////////// INPUT SYSTEM /////////////////////////////
    private void Update()
    {
        moveDirection = -playerTransform.forward * moveVector.y + -playerTransform.right * moveVector.x; // get players move direction (inverted vectors because blender screws up rotations
        Vector3 movementDirection = moveDirection * (moveSpeed * Time.deltaTime);
        playerTransform.position += movementDirection;
        float RotationX = lookVector.x * HorizontalSensitivity * Time.deltaTime;
        //float RotationY = lookVector.y * VerticalSensitivity * Time.deltaTime;
        Vector3 PlayerRotation = playerTransform.rotation.eulerAngles;
        //PlayerRotation.x -= RotationY;
        PlayerRotation.y += RotationX;
        playerTransform.rotation = Quaternion.Euler(PlayerRotation);

        healthBar.value = currentHealth;

        //if (fireInput.triggered && isFiring == false)
        //{
        //    StartCoroutine(Fire());
        //}

        // Player dies
        if(currentHealth <= 0)
        {
            SceneManager.LoadScene("LoseScreen");
        }
    }
    // --------------- Public Functions ----------------- //
    public void GetHurt()
    {
        if(isHurting == false)
        {
            StartCoroutine(Hurting());
        }
    }
    IEnumerator Fire()
    {
        isFiring = true;
        playerAnimator.SetBool("IsShooting", true);
        flashlight.intensity = 5;
        yield return new WaitForSeconds(AttackSpeed);
        projectile = ProjectilePool.Instance.GetBullet();
        if(projectile != null)
        {
            projectile.transform.position = bulletSpot.position;
            projectile.transform.rotation = bulletSpot.rotation;
            //projectile.GetComponent<ProjectileScript>().maxSpeed = 10;
            projectile.SetActive(true);
        }
        flashlight.intensity = 3;
        isFiring = false;
        playerAnimator.SetBool("IsShooting", false);
    }

    //private void OnEnable()
    //{
    //    fireInput.Enable();
    //}

    //private void OnDisable()
    //{
    //    fireInput.Disable();
    //}

    IEnumerator Hurting()
    {
        isHurting = true;
        currentHealth -= 2;
        Debug.Log("In hurting");
        yield return new WaitForSeconds(1f);
        isHurting = false;
    }

    private void OnTriggerEnter(Collider collision)
    {
        //Debug.Log("Working");
        if(collision.gameObject.CompareTag("DeathPlane"))
        {
            transform.position = playerSpawn.position;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("enemy") && isHurting == false)
        {
            Debug.Log("Enemy hitting messa");
            
        }
    }

    private void LoadAllSavedData()
    {
        if(PlayerPrefs.HasKey("CurrentLevel"))
        {
            currentLevel = PlayerPrefs.GetInt("CurrentLevel");
            levelsComplete = PlayerPrefs.GetInt("LevelsComplete");
            currentHealth = PlayerPrefs.GetInt("CurrentHealth");
            Damage = PlayerPrefs.GetInt("Damage");
            AttackSpeed = PlayerPrefs.GetFloat("AttackSpeed");
        }
        
    }
}

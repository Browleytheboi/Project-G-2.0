using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour, IDamage
{

    //character controller
    [SerializeField] CharacterController controller;

    //mask to ignore player
    [SerializeField] LayerMask ignoreMask;

    //variables that manipulate player--

    //speed the player goes
    [SerializeField] int speed;
    //multiplier for speed
    [SerializeField] int sprintMod;
    //max amount of jumps
    [SerializeField] int max_Amount_Of_Jumps;
    //how high we jump
    [SerializeField] int jumpHeight;
    //gravity to pull us down
    [SerializeField] int gravity;
    // health
    [SerializeField] int healthPoints;

    [SerializeField] GameObject gunViewModel;
    GameObject currentViewModel;
    Animator viewModelAnimator;

    //current amount of jumps
    int jumpCount;
    //direction we're moving
    Vector3 moveDir;
    //our velocity
    Vector3 playerVel;
    // is the player currently shooting?
    private bool isShooting;
    // Player's initial health amount
    private int initHealth;

    int selectedGun;

    public static damage.damageType enemyDamageType;

    // UI prompt to interact
    [SerializeField] GameObject interactPromptUI;
    // Max distance to interact
    [SerializeField] float interactDistance = 2f;

    // to track if an interactable object is within range
    private bool canInteract = false;
    // The interactable object in focus
    private GameObject currentInteractable = null;

    public int Health { get { return healthPoints; } set { healthPoints = value; } }

    public bool Shooting { get { return isShooting; } }


    [SerializeField] List<gunStats> gunList = new List<gunStats>();
    [SerializeField] GameObject gunModel;
    [SerializeField] GameObject muzzleFlash;
    int shootDamage;
    float shootRate;
    float shootDist;
    [SerializeField] AudioSource aud;

    [SerializeField] AudioClip[] audSteps;
    [SerializeField][Range(0, 1)] float audStepsVol;

    bool isPlayingSteps;
    bool isSprinting;

    // Start is called before the first frame update
    void Start()
    {
        initHealth = healthPoints;

    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        // If player is grounded
        if (controller.isGrounded)
        {
            // Set player's velocity to -1f to help ground the character and prevent it from floating
            playerVel.y = -1f;
            jumpCount = 0;

            jump();

        }

        // Get player's vertical and horizontal input (WASD or arrow keys)
        float verticalInput = Input.GetAxis("Vertical"); // Forward/backward (W/S)
        float horizontalInput = Input.GetAxis("Horizontal"); // Left/right (A/D)

        // Calculate movement direction based on the player's current orientation (transform.forward and transform.right)
        Vector3 moveDir = (transform.forward * verticalInput) + (transform.right * horizontalInput);

        // Move the player in the calculated direction
        controller.Move(moveDir * speed * Time.deltaTime);

        // Apply gravity if not grounded
        if (!controller.isGrounded)
        {
            playerVel.y -= gravity * Time.deltaTime;
        }

        // Apply vertical velocity (gravity) to the player's movement
        controller.Move(playerVel * Time.deltaTime);
    }

    //how we handle jump
    void jump()
    {
        //check if player is jumping
        if (Input.GetButtonDown("Jump") && jumpCount < max_Amount_Of_Jumps)
        {
            //set player velocity based on jump height
            playerVel.y = jumpHeight;
            jumpCount++;
        }

    }

    void sprint()
    {
        if (Input.GetButtonDown("Sprint"))
        {
            //multiply speed by modifier
            speed *= sprintMod;
            isSprinting = true;


        }
        else if (Input.GetButtonUp("Sprint"))
        {
            speed /= sprintMod;
            isSprinting = false;

        }



    }


    public void TakeDamage(int amount)
    {
        // take damage
        healthPoints -= amount;
    }
}


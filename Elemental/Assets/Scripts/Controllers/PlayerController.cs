using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;
    private float speed = 12; 
    private float sprintSpeed = 20; 
    private float gravity = -29.43f; 
    private float jumpHeight = 4f; 
    private float currentHealth;
    private float maxHealth;
    private float attackStr;
    private float level;
    private float xp;
    public Transform groundCheck; 
    public Transform headCheck; 
    public float groundDistance = 5f; 
    public LayerMask groundMask;
    Vector3 velocity;
    public bool isWalking = false;
    public bool isSprinting = false; 
    public GameObject staminaBar; 
    public GameObject healthBar;
    public GameObject sword;
    public float sprintCooldown; 
    [SerializeField] Footsteps soundGenerator;
    [SerializeField] float footStepTimer;

    void Update()
    {
        checkForMovement();
        checkForGround();
        checkForCeiling();
        checkForJump();
    }

    public void checkForMovement()
    {
        float x = Input.GetAxis("Horizontal"); 
        float z = Input.GetAxis("Vertical"); 
        Vector3 move = transform.right * x + transform.forward * z; 

        if(move.x < 0 || move.x > 0 || move.y < 0 || move.y > 0 || move.z < 0 || move.z > 0)
        {

            if (!isWalking && controller.isGrounded && isSprinting)
            {
                footStepTimer = 0.2f;
                PlayFootstep();
            }
            if (!isWalking && controller.isGrounded && !isSprinting)
            {
                footStepTimer = 0.33f;
                PlayFootstep();
            }
        }

        if (Input.GetButton("Sprint") && controller.isGrounded && staminaBar.GetComponent<Slider>().value > 0)
        {
            if (move.x < 0 || move.x > 0 || move.y < 0 || move.y > 0 || move.z < 0 || move.z > 0)
            {
                isSprinting = true;
                speed = sprintSpeed;
                staminaBar.GetComponent<Slider>().value -= Time.deltaTime * 10;
                sprintCooldown = 5;
            }
        }
        else
        {
            isSprinting = false;
            if (speed > 12)
            {
                speed--;
            }

            if (sprintCooldown > 0)
            {
                sprintCooldown -= Time.deltaTime;
            }
        }

        if (staminaBar.GetComponent<Slider>().value < 100 && sprintCooldown <= 0)
        {
            staminaBar.GetComponent<Slider>().value += Time.deltaTime * 5;
        }

        controller.Move(move * speed * Time.deltaTime);
    }

    public void checkForGround()
    {
        velocity.y += gravity * Time.deltaTime; 
        controller.Move(velocity * Time.deltaTime); 

        if (controller.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
    }

    public void checkForJump()
    {
        if (Input.GetButtonDown("Jump") && controller.isGrounded) 
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }

    //checkForCeiling - uses the collsionFlags on the controller to check if a collision occured at the top of the player.

    public void checkForCeiling()
    {
        if ((controller.collisionFlags & CollisionFlags.Above) != 0)
        {
            velocity.y = 0f;
        }
    }

    public void loseHealth(float damageValue)
    {
        currentHealth -= damageValue;
        if(currentHealth < 0)
        {
            currentHealth = 0;
        }

        healthBar.GetComponent<PlayerHealthManager>().setHealthBar(currentHealth);
    }

    public void gainHealth(float healthValue)
    {
        currentHealth += healthValue;
        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        healthBar.GetComponent<PlayerHealthManager>().setHealthBar(currentHealth);
    }

    private void levelUp()
    {
        attackStr += 5;
        maxHealth += 10;

        sword.GetComponent<SwordAttack>().updateAttackStr(attackStr);
        healthBar.GetComponent<PlayerHealthManager>().updateHealthBar(maxHealth);
    }

    public void obtainStats(float mHP, float cHP, float atkStr, float lv, float exp)
    {
        maxHealth = mHP;
        currentHealth = cHP;
        attackStr = atkStr;
        level = lv;
        xp = exp;
    }

    public void PlayFootstep()
    {
        StartCoroutine("PlayStep", footStepTimer);
    }

    IEnumerator PlayStep(float timer)
    {
        var randomIndex = Random.Range(0, 3);
        soundGenerator.audioSource.clip = soundGenerator.footStepSounds[randomIndex];

        soundGenerator.audioSource.Play();
        isWalking = true;

        yield return new WaitForSeconds(timer);

        isWalking = false;
    }

}

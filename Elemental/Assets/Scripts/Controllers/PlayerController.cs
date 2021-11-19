using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12; 
    public float sprintSpeed = 20; 
    public float gravity = -29.43f; 
    public float jumpHeight = 4f; 
    public Transform groundCheck; 
    public Transform headCheck; 
    public float groundDistance = 5f; 
    public LayerMask groundMask;
    Vector3 velocity;
    public bool isWalking = false;
    public bool isSprinting = false; 
    public GameObject staminaBar; 
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
<<<<<<< HEAD
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
=======
        velocity.y += gravity * Time.deltaTime; 
        controller.Move(velocity * Time.deltaTime); 
>>>>>>> 47a64d2b47aa0aa7b93054d2aea21bb65c2d487e

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

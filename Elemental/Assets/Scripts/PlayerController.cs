using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12; //The players base walk speed
    public float sprintSpeed = 20; //How fast the player can sprint
    public float gravity = -29.43f; //How intense the gravity for the player is
    public float jumpHeight = 4f; //how high the player can jump
    public Transform groundCheck; //This checks if there is ground below the player
    public Transform headCheck; //Check to see if there is something above the head
    public float groundDistance = 5f; //The distance to check before hitting the ground
    public LayerMask groundMask;
    Vector3 velocity;
    public bool isSprinting = false; //This is to check if player sprinting
    public bool hitHead = false; //Checks if player's head is hitting something
    public GameObject staminaBar; //This is the bar for stamina
    public float sprintCooldown; //This is how long it takes before you can sprint again

    void Update()
    {
        checkForMovement();
        checkForGround();
        checkForCeiling();
        checkForJump();
    }

    public void checkForMovement()
    {
        float x = Input.GetAxis("Horizontal"); //Checks if the player moves along the horizontial axis
        float z = Input.GetAxis("Vertical"); //Checks if the player moves along the vertical axis
        Vector3 move = transform.right * x + transform.forward * z; //This alows the player to move around

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
        velocity.y += gravity * Time.deltaTime; //This alows gravity to work
        controller.Move(velocity * Time.deltaTime); //This alows you to speed up in the air

        if (controller.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
    }

    public void checkForJump()
    {
        if (Input.GetButtonDown("Jump") && controller.isGrounded) //This allows the player to jump up into the air
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
}

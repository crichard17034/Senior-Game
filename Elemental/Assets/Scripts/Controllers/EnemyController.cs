using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    Animator anim;
<<<<<<< HEAD
=======
    public float currentHealth;
    public float maxHealth;
>>>>>>> 47a64d2b47aa0aa7b93054d2aea21bb65c2d487e
    NavMeshAgent agent;
    Transform target;
    public Transform groundCheck; 
    public LayerMask groundMask;
<<<<<<< HEAD
    public float gravity = -9.81f; 
    public float jumpHeight = 4f; 
    public float lookRadius = 10f;
    public float groundDistance = 5f; 
    public bool isGrounded;
    public float jumpTimer;
=======
    Vector3 velocity;
    public float lookRadius = 10f;
    public float attackRange= 22f;
    Collider slimeHitbox;

>>>>>>> 47a64d2b47aa0aa7b93054d2aea21bb65c2d487e

    void Start()
    {
        anim = GetComponent<Animator>();
<<<<<<< HEAD
        target = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
=======
        currentHealth = maxHealth;
        target = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        slimeHitbox = GetComponent<Collider>();
        slimeHitbox.isTrigger = false;
>>>>>>> 47a64d2b47aa0aa7b93054d2aea21bb65c2d487e
    }

    void Update()
    {
        checkLookRadius();
<<<<<<< HEAD
        checkForJump();
=======
>>>>>>> 47a64d2b47aa0aa7b93054d2aea21bb65c2d487e
    }

    public void checkLookRadius()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if(distance <= lookRadius)
        {
            agent.SetDestination(target.position);
            faceTarget();
<<<<<<< HEAD
        }
    }

    public void checkForJump()
    {
        jumpTimer += 1f;
        
        if(jumpTimer >= 50f)
        {
            anim.SetBool("jumping", true);
            jumpTimer = 0f;
        }
        else
        {
            anim.SetBool("jumping", false);
=======
            
            if(agent.remainingDistance > 5f)
            {
                anim.SetBool("Chasing", true);
            }
>>>>>>> 47a64d2b47aa0aa7b93054d2aea21bb65c2d487e
        }
    }

    public void faceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

<<<<<<< HEAD
=======
    void OnAnimatorMove ()
    {
        Vector3 position = anim.rootPosition;
        transform.position = position;
    }

>>>>>>> 47a64d2b47aa0aa7b93054d2aea21bb65c2d487e
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
<<<<<<< HEAD
=======
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }

    public void loseHealth(float damageValue)
    {
        currentHealth -= damageValue;
        if(currentHealth <= 0)
        {
            currentHealth = 0;
            die();
        }
    }

    public void die()
    {
        Destroy(gameObject);
>>>>>>> 47a64d2b47aa0aa7b93054d2aea21bb65c2d487e
    }
}

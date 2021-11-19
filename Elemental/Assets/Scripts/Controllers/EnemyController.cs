using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    Animator anim;
    NavMeshAgent agent;
    Transform target;
    public Transform groundCheck; 
    public LayerMask groundMask;
    public float gravity = -9.81f; 
    public float jumpHeight = 4f; 
    public float lookRadius = 10f;
    public float groundDistance = 5f; 
    public bool isGrounded;
    public float jumpTimer;

    void Start()
    {
        anim = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        checkLookRadius();
        checkForJump();
    }

    public void checkLookRadius()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if(distance <= lookRadius)
        {
            agent.SetDestination(target.position);
            faceTarget();
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
        }
    }

    public void faceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}

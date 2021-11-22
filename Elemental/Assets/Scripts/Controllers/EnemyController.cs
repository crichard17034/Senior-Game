using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    Animator anim;
    public float currentHealth;
    public float maxHealth;
    NavMeshAgent agent;
    Transform target;
    public Transform groundCheck;
    public LayerMask groundMask;
    Vector3 velocity;
    public float lookRadius = 10f;
    public float attackRange = 22f;
    Collider slimeHitbox;


    void Start()
    {
        anim = GetComponent<Animator>();
        currentHealth = maxHealth;
        target = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        slimeHitbox = GetComponent<Collider>();
        slimeHitbox.isTrigger = false;
    }

    void Update()
    {
        checkLookRadius();
    }

    public void checkLookRadius()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= lookRadius)
        {
            agent.SetDestination(target.position);
            faceTarget();

            if (agent.remainingDistance > 5f)
            {
                anim.SetBool("Chasing", true);
            }
        }
    }

    public void faceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    void OnAnimatorMove()
    {
        Vector3 position = anim.rootPosition;
        transform.position = position;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }

    public void loseHealth(float damageValue)
    {
        currentHealth -= damageValue;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            die();
        }
    }

    public void die()
    {
        Destroy(gameObject);
    }
}

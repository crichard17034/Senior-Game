using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    Animator anim;
    public int currentHealth;
    public int maxHealth;
    public int xp;
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
        checkAttackRadius();
    }

    public void checkLookRadius()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if(distance <= lookRadius && distance > attackRange)
        {
            agent.SetDestination(target.position);
            anim.SetBool("Chasing", true);
            faceTarget();

            if (agent.remainingDistance > 5f && AttackTimer > 0f)
            {
                anim.SetBool("Chasing", true);
            }
        }
        else
        {
            anim.SetBool("Chasing", false);
            gameObject.GetComponent<NavMeshAgent>().isStopped = true;
        }
    }

    public void checkAttackRadius()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if(distance <= attackRange)
        {
            anim.SetBool("Attacking", true);
            anim.SetBool;
        }
        else
        {
            anim.SetBool("Attacking", false);
        }
    }

    public void faceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }


    public void OnAnimatorMove()
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

    public void loseHealth(int damageValue)
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
        FindObjectOfType<PlayerController>().gainXP(xp);
        Destroy(gameObject);
    }
}

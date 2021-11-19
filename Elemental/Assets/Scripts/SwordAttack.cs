using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    Animator anim;
    Collider swordHitbox;
    public float damageValue;

    private void Start()
    {
        anim = GetComponent<Animator>();
        swordHitbox = GetComponent<Collider>();
        swordHitbox.isTrigger = false;
    }

    private void Update()
    {
        checkForAttack();
    }

    public void checkForAttack()
    {
        if(Input.GetButtonDown("Attack"))
        {
            anim.SetBool("attacking", true);
            swordHitbox.isTrigger = true;

        }
        else if(Input.GetButtonUp("Attack"))
        {
            anim.SetBool("attacking", false);
            swordHitbox.isTrigger = false;
        }
    }

    //checks if the game object that collided with the sword is an enemy
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            other.gameObject.GetComponent<EnemyController>().loseHealth(damageValue);
        }
    }
}

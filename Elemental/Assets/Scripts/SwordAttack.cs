using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    Animator anim;
    Collider swordHitbox;
<<<<<<< HEAD
    public float damageValue;
=======
    private int damageValue;
    private string currentElement;
    bool attacking;
>>>>>>> 8b87322bcee5dc43911e67a66210a7f7f7a3052c

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
        if (Input.GetButtonDown("Attack"))
        {
            anim.SetBool("attacking", true);
            swordHitbox.isTrigger = true;

        }
        else if (Input.GetButtonUp("Attack"))
        {
            anim.SetBool("attacking", false);
            swordHitbox.isTrigger = false;
        }
    }

    //checks if the game object that collided with the sword is an enemy
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
<<<<<<< HEAD
=======
        if(other.tag == "Enemy" && attacking == true)
>>>>>>> 8b87322bcee5dc43911e67a66210a7f7f7a3052c
        {
            other.gameObject.GetComponent<EnemyController>().loseHealth(damageValue);
        }
    }
<<<<<<< HEAD
=======

    public void updateAttackStr(int newAtkStr)
    {
        damageValue = newAtkStr;
    }
>>>>>>> 8b87322bcee5dc43911e67a66210a7f7f7a3052c
}

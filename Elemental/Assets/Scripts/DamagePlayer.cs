using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamagePlayer : MonoBehaviour
{
<<<<<<< HEAD
    public float damageValue;
    public CharacterController player;
=======
    public int damageValue;
>>>>>>> 8b87322bcee5dc43911e67a66210a7f7f7a3052c

    void OnTriggerEnter(Collider other)
    {
<<<<<<< HEAD
        other.gameObject.GetComponent<PlayerHealthManager>().loseHealth(damageValue);
=======
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerController>().loseHealth(damageValue);
        }
>>>>>>> 8b87322bcee5dc43911e67a66210a7f7f7a3052c
    }
}

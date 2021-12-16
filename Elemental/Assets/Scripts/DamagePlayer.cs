using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamagePlayer : MonoBehaviour
{
    public int damageValue;

    void OnTriggerEnter(Collider other)
    {
        if(collision.gameObject.tag == "Player")
        {
            gameObject.GetComponent<PlayerController>().loseHealth(damageValue);
        }
    }
}

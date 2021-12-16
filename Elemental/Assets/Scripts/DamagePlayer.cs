using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamagePlayer : MonoBehaviour
{
    public float damageValue;
    public CharacterController player;

    void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<PlayerHealthManager>().loseHealth(damageValue);
    }
}

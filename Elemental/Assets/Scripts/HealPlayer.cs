using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealPlayer : MonoBehaviour
{
    public float healValue;
    public CharacterController player;

    void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<PlayerHealthManager>().gainHealth(healValue);
    }
}

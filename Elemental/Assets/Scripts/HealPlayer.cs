using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealPlayer : MonoBehaviour
{
<<<<<<< HEAD
    public float healValue;
    public CharacterController player;
=======
    public int healValue;
>>>>>>> 8b87322bcee5dc43911e67a66210a7f7f7a3052c

    void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<PlayerHealthManager>().gainHealth(healValue);
    }
}

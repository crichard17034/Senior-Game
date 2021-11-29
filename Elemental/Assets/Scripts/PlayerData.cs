using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData 
{
    public float maxHealth;
    public float currentHealth;
    public float attackStr;

    public PlayerData(PlayerController player)
    {
        maxHealth = player.maxHealth;
        currentHealth = player.currentHealth;
        attackStr = player.attackStr;
    }
}

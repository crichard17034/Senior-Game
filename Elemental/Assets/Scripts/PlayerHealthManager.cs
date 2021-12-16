using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHealthManager : MonoBehaviour
{
<<<<<<< HEAD
    public float currentHealth;
    public float maxHealth;
=======
    private int currentHealth;
    private int maxHealth;
>>>>>>> 8b87322bcee5dc43911e67a66210a7f7f7a3052c
    public GameObject healthText;
    public GameObject healthImage;
    public Texture fullHealthIMG;
    public Texture halfHealthIMG;
    public Texture quarterHealthIMG;

<<<<<<< HEAD
    void Start()
    {
        currentHealth = maxHealth;
        setHealthBar();
    }

    public void setHealthBar()
=======

    public void setHealthBar(int newHealth)
>>>>>>> 8b87322bcee5dc43911e67a66210a7f7f7a3052c
    {
        healthText.GetComponent<TextMeshProUGUI>().text = "" + currentHealth;
        setHealthIMG(currentHealth);
    }

    public void setHealthIMG(int healthValue)
    {
        int halfHealth = maxHealth/2;
        int quarterHealth = maxHealth/4;

        if(healthValue > halfHealth)
        {
            healthImage.GetComponent<RawImage>().texture = fullHealthIMG;
        }
        else if(healthValue <= halfHealth && healthValue > quarterHealth)
        {
            healthImage.GetComponent<RawImage>().texture = halfHealthIMG;
        }
        else
        {
            healthImage.GetComponent<RawImage>().texture = quarterHealthIMG;
        }
    }

<<<<<<< HEAD
    public void loseHealth(float damageValue)
    {
        currentHealth -= damageValue;
        if(currentHealth < 0)
        {
            currentHealth = 0;
        }
        setHealthBar();
    }

    public void gainHealth(float healthValue)
    {
        currentHealth += healthValue;
        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        setHealthBar();
=======
    public void newSceneHealth(int newMaxHealth, int newCurrentHealth)
    {
        maxHealth = newMaxHealth;
        currentHealth = newCurrentHealth;
        setHealthBar(currentHealth);
    }

    public void levelUpHealth(int newMaxHealth)
    {
        maxHealth = newMaxHealth;
        currentHealth = maxHealth;
        setHealthBar(currentHealth);
>>>>>>> 8b87322bcee5dc43911e67a66210a7f7f7a3052c
    }
}

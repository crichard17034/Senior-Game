using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHealthManager : MonoBehaviour
{
    public float currentHealth;
    public float maxHealth;
    public GameObject healthText;
    public GameObject healthImage;
    public Texture fullHealthIMG;
    public Texture halfHealthIMG;
    public Texture quarterHealthIMG;

    void Start()
    {
        currentHealth = maxHealth;
        setHealthBar();
    }

    public void setHealthBar()
    {
        healthText.GetComponent<TextMeshProUGUI>().text = "" + currentHealth;
        setHealthIMG(currentHealth);
    }

    public void setHealthIMG(float healthValue)
    {
        float halfHealth = maxHealth/2;
        float quarterHealth = maxHealth/4;

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
    }
}

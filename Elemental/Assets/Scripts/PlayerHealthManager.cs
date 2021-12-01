using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHealthManager : MonoBehaviour
{
    private float currentHealth = 100f;
    private float maxHealth = 100f;
    public GameObject healthText;
    public GameObject healthImage;
    public Texture fullHealthIMG;
    public Texture halfHealthIMG;
    public Texture quarterHealthIMG;

    void Start()
    {
        currentHealth = maxHealth;
        setHealthBar(currentHealth);
    }

    public void setHealthBar(float newHealth)
    {
        currentHealth = newHealth;
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

    public void updateHealthBar(float newMaxHealth)
    {
        maxHealth = newMaxHealth;
        currentHealth = newMaxHealth;
    }
}

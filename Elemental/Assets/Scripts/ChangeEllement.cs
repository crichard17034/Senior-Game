using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeEllement : MonoBehaviour
{
    //This File is connected to the Element Object within the First Person Controller

    //Tells the Player that they have the element
    bool hasFire = false;
    bool hasWater = false;
    bool hasWind = false;

    //Lets the program know which element is active or not.
    bool FireActive = false;
    bool WaterActive = false;
    bool WindActive = false;


    //lets the game know how many gems that the player collected 
    int totalGems = 0;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switchOutElement();
    }


    public void OnTriggerEnter(Collider other)
    {

        /**
         *If the player picks up a Gem With an Ellement
         *They are then able to use that color of the gems
         *Ellement and will be able to switch over to that
         *Ellement
         */

        if (other.CompareTag("FireGem"))
        {
            Destroy(other.gameObject);
            totalGems = totalGems + 1;
            hasFire = true;
            Debug.Log("The Player Gained the Fire Element");
            Debug.Log("The Player Can now Switched to the Fire Element");
        }
        if (other.CompareTag("WaterGem"))
        {
            Destroy(other.gameObject);
            totalGems = totalGems + 1;
            hasWater = true;
            Debug.Log("The Player Gained the Water Element");
            Debug.Log("The Player Can now Switched to the Water Element");
        }
        if (other.CompareTag("WindGem"))
        {
            Destroy(other.gameObject);
            totalGems = totalGems + 1;
            hasWind = true;
            Debug.Log("The Player Gained the Wind Element");
            Debug.Log("The Player Can now Switched to the Wind Element");
        }
    }


    public void switchOutElement()
    {
        //If the total amount of gems is Greater than 0
        if (totalGems >= 0)
        {
            //Check What kind of element the player currently has
            if(hasFire == true)
            {
                //if they have fire they can switch to the fire ellement by
                //pressing the #1 button
                if (Input.GetKeyDown(KeyCode.Alpha1))
                {
                    FireActive = true;
                    WaterActive = false;
                    WindActive = false;
                    Debug.Log("Element was changed to Fire");
                }
            }
            //if they have water they can switch to the water ellement by
            //pressing the #2 button
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                if (hasWater == true)
                {
                    FireActive = false;
                    WaterActive = true;
                    WindActive = false;
                    if (WaterActive == true)
                    {
                        Debug.Log("Element Was Changed to Water");
                    }
                }
            }
            //if they have wind they can switch to the wind ellement by
            //pressing the #3 button
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                if (hasWind == true)
                {
                    FireActive = false;
                    WaterActive = false;
                    WindActive = true;
                    if (WindActive == true)
                    {
                        Debug.Log("Element Was Changed to Wind");
                    }
                }
            }

        }
    }

}

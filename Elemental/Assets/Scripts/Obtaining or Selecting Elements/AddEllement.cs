using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddEllement : MonoBehaviour
{

    public bool isFireGem = false;
    public bool isWaterGem = false;
    public bool isWindGem = false;

    public bool hasFireElem = false;
    public bool hasWaterElem = false;
    public bool hasWindElem = false;
    private void OnTriggerEnter(Collider other)
    {
       

        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);

            if (isFireGem == true) 
            { 
                ChangeEllement.setElem = "Fire";
                Debug.Log("The Player Picked up a Fire Gem");
            }
            if (isWaterGem == true) 
            {     
                ChangeEllement.setElem = "Water";
                Debug.Log("The Player Picked up a Water Gem");

            }
            if (isWindGem == true) 
            { 
                ChangeEllement.setElem = "Wind";
                Debug.Log("The Player Picked up a Wind Gem");


            }

        }
    }
}

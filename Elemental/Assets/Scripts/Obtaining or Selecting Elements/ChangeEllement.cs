using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeEllement : MonoBehaviour
{   

    //Can be Changed by the Add Elements Script
    public static bool hasFire = false;
    public static bool hasWater = false;
    public static bool hasWind = false;

    public static int totalGems = 0;


    //A Variable that is accessed by the addEllement script.
    public static string setElem = "No Element";

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnGUI()
    {
        GUI.Box(new Rect(188, 504, 134, 50), "Obtained the Element: \n" + setElem);
    }

    public void switchOutElement()
    {
        if (totalGems >= 0)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            { }
        }
        else { }
    }

}

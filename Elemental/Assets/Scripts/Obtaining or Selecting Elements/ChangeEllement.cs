using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeEllement : MonoBehaviour
{   

    //Variables to Set the Current Element
    public bool hasFire = false;
    public bool hasWater = false;
    public bool hasWind = false;

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
        
    }

}

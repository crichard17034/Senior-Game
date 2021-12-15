using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnePlayerController : MonoBehaviour
{
    static OnePlayerController instance;
    
    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}

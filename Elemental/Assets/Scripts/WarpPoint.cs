using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpPoint : MonoBehaviour
{
    public string warpLocation;

    void OnTriggerEnter(Collider other)
    {
        FindObjectOfType<GameManager>().Teleport(warpLocation);
    }
}
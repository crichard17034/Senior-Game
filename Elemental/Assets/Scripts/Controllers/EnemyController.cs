using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    NavMeshAgent agent;
    Transform target;
    public float lookRadius = 10f;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }


    void Update()
    {

    }
}

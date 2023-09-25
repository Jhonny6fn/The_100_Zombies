using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFollow : MonoBehaviour
{
    public NavMeshAgent enemy;
    public Transform Player;

    void Start()
    {
        enemy = GetComponent<NavMeshAgent>();
        Player = GameObject.Find("FPSController").transform;
    }

    void Update()
    {
        enemy.SetDestination(Player.position);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public float distanceToFollowPath = 2;
    public Transform[] destinations;
    private int i = 0;
    public bool followPlayer;
    private GameObject player;
    private float distanceToPlayer;
    public float distanceToFollowPlayer = 10;

    void Start()
    {
        navMeshAgent.destination = destinations[0].transform.position;
        player = FindObjectOfType<PlayerMovement>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
        if (distanceToPlayer<distanceToFollowPlayer && followPlayer)
        {
            FollowPlayer();
        }
        else
        {
            EnemyPath();
        }
        
        
        
        /*float distance = Vector3.Distance(transform.position, destination1.transform.position);
        if (distance<2)
        {
            navMeshAgent.destination = destination2.transform.position;
        }*/
    }
    public void EnemyPath()
    {
        navMeshAgent.destination = destinations[i].transform.position;
        if (Vector3.Distance(transform.position,destinations[i].position) <= distanceToFollowPath)
        {
            if (destinations[i] != destinations[destinations.Length - 1])
            {
                i++;
            }
            else
            {
                i = 0;
            }
        }
    }
    public void FollowPlayer()
    {
        navMeshAgent.destination = player.transform.position;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Agent : MonoBehaviour
{
    // Variables
    private GameObject Pack;
    private bool Leader;
    private NavMeshAgent NavAgent;

    Vector3 TargetLocation;
    Vector3 OffSetToLeader;
    float MovementSpeed;


    private void Awake()
    {
        TargetLocation = transform.position;
        NavAgent = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        NavAgent.destination = TargetLocation;
    }



    // Getters and setters
    public void SetPack(GameObject pack)
    {
        Pack = pack;
    }
    public void SetLeader(bool leader)
    {
        Leader = leader;
    }
    public void SetTarget(Vector3 location)
    {
        TargetLocation = location;
    }
    public void SetMovementSpeed(float speed)
    {
        MovementSpeed = speed;
        NavAgent.speed = speed;
    }
    public void SettOffset(Vector3 offset)
    {
        OffSetToLeader = offset;
    }
    public Vector3 GetOffset()
    {
        return OffSetToLeader;
    }
}

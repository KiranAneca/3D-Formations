﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentGroup : MonoBehaviour
{
    public enum formation
    {
        VShape = 0,
        Square = 1
    }

    // Variables
    [SerializeField] private int AgentAmount = 50;
    public GameObject Agent;
    private formation Formation;

    // Visualize
    [SerializeField] private GameObject Marker;
    [SerializeField] private Material LeaderMat;
    void Start()
    {
        
        // Spawn all the agents in a random pattern
        for (int i = 0; i < AgentAmount; ++i)
        {
            GameObject temp = Instantiate(Agent);
            temp.GetComponent<Agent>().SetPack(this.gameObject);
            temp.transform.SetParent(this.transform);
            temp.transform.position = new Vector3(Random.Range(-6f, 6f), 0, Random.Range(-6f, 6f));
        }

        // Set the first agent as the leader
        this.transform.GetChild(0).GetComponent<Agent>().SetLeader(true);
        this.transform.GetChild(0).GetComponent<Agent>().SetMovementSpeed(5f);
        this.transform.GetChild(0).GetComponent<MeshRenderer>().material = LeaderMat;

        // Run over all the agents, excluding the leader
        for (int i = 1; i < transform.childCount; ++i)
        {
            // Calculate the offset off the rest of the agents to the leader
            Vector3 offset = (this.transform.GetChild(0).position - this.transform.GetChild(i).position);
            this.transform.GetChild(i).GetComponent<Agent>().SettOffset(offset);
            // Set the movement speed to a random value
            this.transform.GetChild(i).GetComponent<Agent>().SetMovementSpeed(Random.Range(2.5f, 5.5f));
        }
    }
    private void Update()
    {
        // Set the destination of the leader
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
            {
                this.transform.GetChild(0).GetComponent<Agent>().SetTarget(hit.point);
                Marker.transform.position = hit.point;
                Debug.Log("Target set");
            }
        }

        // Make the rest of the agents folow the leader
        for (int i = 1; i < transform.childCount; ++i)
        {
            Vector3 leaderPos = new Vector3(this.transform.GetChild(0).position.x, this.transform.GetChild(0).position.y, this.transform.GetChild(0).position.z);
            Vector3 loc = leaderPos - this.transform.GetChild(i).GetComponent<Agent>().GetOffset();
            this.transform.GetChild(i).GetComponent<Agent>().SetTarget(loc);
        }
    }

    public void ChangeFormation(int form)
    {
        Formation = (formation)form;
        FormFormation(Formation);
    }
    private void FormFormation(formation form)
    {
        switch (form)
        {
            case formation.VShape:
                for(int i = 1; i < this.transform.childCount; ++i)
                {
                    // Move the even to the right side, and the odd to the left side
                    if(i % 2 == 0)
                    {
                        Vector3 offset = new Vector3(i/2, 0, i/2);
                        this.transform.GetChild(i).GetComponent<Agent>().SettOffset(offset);
                    }
                    else
                    {
                        Vector3 offset = new Vector3(-i/2 - 1, 0, i/2 + 1);
                        this.transform.GetChild(i).GetComponent<Agent>().SettOffset(offset);
                    }
                }
                break;
            case formation.Square:
                float distance = Mathf.CeilToInt( AgentAmount / 8.0f);
                for (int i = 1; i < this.transform.childCount; ++i)
                {
                    if (i % 4 == 0) // bottomLeft
                    {
                        Vector3 offset = new Vector3(-distance, 0, -distance + i/4);
                        this.transform.GetChild(i).GetComponent<Agent>().SettOffset(offset);
                    }
                    else if(i % 4 == 1) // topLeft
                    {
                        Vector3 offset = new Vector3(-distance + i/4, 0, distance);
                        this.transform.GetChild(i).GetComponent<Agent>().SettOffset(offset);
                    }
                    else if (i % 4 == 2) // topRight
                    {
                        Vector3 offset = new Vector3(distance, 0, distance - i/4);
                        this.transform.GetChild(i).GetComponent<Agent>().SettOffset(offset);
                    }
                    else // bottomRight
                    {
                        Vector3 offset = new Vector3(distance - i/4, 0, -distance);
                        this.transform.GetChild(i).GetComponent<Agent>().SettOffset(offset);
                    }
                }
                break;
            default:
                break;
        }
    }
}
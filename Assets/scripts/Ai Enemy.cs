using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AiEnemy : MonoBehaviour
{
    


    public Transform[] goals;   // Add all goals here in Inspector

    private NavMeshAgent agent;
    private int currentGoalIndex = 0;

    void Start()
    {
        agent = GetComponentInChildren<NavMeshAgent>();
        //agent.updateRotation = false;

        if (goals.Length > 0)
            agent.destination = goals[0].position;
    }

    void Update()
    {
        /*Vector3 velocity = agent.velocity;

        if (velocity.sqrMagnitude > 0.1f)
            transform.rotation = Quaternion.LookRotation(-velocity.normalized);*/

        if (goals.Length == 0) return;
        if (agent.pathPending) return;

        if (agent.remainingDistance <= 0.25f &&
            agent.hasPath &&
            agent.velocity.sqrMagnitude < 0.01f)
        {
            currentGoalIndex = (currentGoalIndex + 1) % goals.Length;

            Debug.Log("Next Goal: " + currentGoalIndex);

            agent.SetDestination(goals[currentGoalIndex].position);
        }
    }

    /*void Update()
    {
        Vector3 velocity = agent.velocity;

        // Face movement using right side
        if (velocity.sqrMagnitude > 0.1f)
        {
            transform.rotation = Quaternion.LookRotation(-velocity.normalized);
        }

        // When reached goal, switch to next one
        *//*if (!agent.pathPending && agent.remainingDistance <= 0.5f)
        {
            currentGoalIndex++;
            Debug.Log(currentGoalIndex);
            if (currentGoalIndex >= goals.Length)
                currentGoalIndex = 0; // loop back

            agent.destination = goals[currentGoalIndex].position;
        }*//*
        if (agent.pathPending) return;

        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
            {
                currentGoalIndex++;
                Debug.Log(currentGoalIndex);
                if (currentGoalIndex < goals.Length)
                    agent.SetDestination(goals[currentGoalIndex].position);
            }
        }
    }*/
}
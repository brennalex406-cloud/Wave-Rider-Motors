using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class AiEnemy : MonoBehaviour
/*{

    public Text lapTime;
    public Text startCountdown;

    public float totalLapTime;
    public float totalCountdownTime;

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

        if (totalCountdownTime > 0)
        {
            totalCountdownTime -= Time.deltaTime;
            startCountdown.text = Mathf.Round(totalCountdownTime).ToString();
            agent.speed = 0;
        }
        if (totalCountdownTime <= 0)
        {
            startCountdown.text = "";
            totalLapTime -= Time.deltaTime;
            lapTime.text = Mathf.Round(totalLapTime).ToString();
            float randFloat = Random.Range(30f, 35f);
            agent.speed = randFloat;
            Debug.Log("speed " + randFloat);
        }
        *//*Vector3 velocity = agent.velocity;

        if (velocity.sqrMagnitude > 0.1f)
            transform.rotation = Quaternion.LookRotation(-velocity.normalized);*//*

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

    
}*/


{
    public Text lapTime;
    public Text startCountdown;

    public float totalLapTime;
    public float totalCountdownTime;

    // Goal points
    public Transform[] goals;

    private NavMeshAgent agent;
    private int currentGoalIndex = 0;

    void Start()
    {
        // NavMeshAgent must be on SAME object
        agent = GetComponent<NavMeshAgent>();

        // Disable automatic rotation
        agent.updateRotation = false;

        // Set first destination
        if (goals.Length > 0)
        {
            agent.SetDestination(goals[0].position);
        }
    }

    void Update()
    {
        // =========================
        // START COUNTDOWN
        // =========================

        if (totalCountdownTime > 0)
        {
            totalCountdownTime -= Time.deltaTime;

            startCountdown.text =
                Mathf.Round(totalCountdownTime).ToString();

            agent.speed = 0;
        }
        else
        {
            startCountdown.text = "";

            // LAP TIMER
            totalLapTime -= Time.deltaTime;

            lapTime.text =
                Mathf.Round(totalLapTime).ToString();

            // RANDOM SPEED
            float randFloat = Random.Range(30f, 35f);

            agent.speed = randFloat;
        }

        // =========================
        // BOAT ROTATION
        // =========================

        Vector3 velocity = agent.velocity;

        if (velocity.sqrMagnitude > 0.1f)
        {
            Quaternion targetRotation =
                Quaternion.LookRotation(velocity.normalized);

            // Change 90 to -90 if needed
            transform.rotation =
                targetRotation * Quaternion.Euler(0, 90, 0);
        }

        // =========================
        // GOAL CHECK
        // =========================

        if (goals.Length == 0) return;

        if (agent.pathPending) return;

        if (agent.remainingDistance <= 0.25f &&
            agent.hasPath &&
            agent.velocity.sqrMagnitude < 0.01f)
        {
            currentGoalIndex =
                (currentGoalIndex + 1) % goals.Length;

            Debug.Log("Next Goal: " + currentGoalIndex);

            agent.SetDestination(
                goals[currentGoalIndex].position
            );
        }
    }
}
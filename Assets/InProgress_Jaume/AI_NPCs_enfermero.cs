using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.AI;


public class AI_NPCs_enfermero : MonoBehaviour
{
    [SerializeField] private bool isPlayerInRange;
    public enum State
    {
        Patrolling,
        Dialoguing,
        Waiting // Add the new state here
    }
    public State currentState;
    NavMeshAgent agent;
    public Transform[] destinationPoints;
    int destinationIndex = 0;
    public float visionRange;
    private Animator anim;
    private float waitTime = 5f; // Change the wait time here

    // Start is called before the first frame update
    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponentInChildren<Animator>();
    }

    void Start()
    {
        currentState = State.Patrolling;
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
            case State.Patrolling:
                Patrol();
                break;
            case State.Waiting: // Add the new case here
                Wait();
                break;
        }
    }

    void Patrol()
    {
        agent.destination = destinationPoints[destinationIndex].position;
        anim.SetBool("isIdle", false);

        if (Vector3.Distance(transform.position, destinationPoints[destinationIndex].position) < 1)
        {
            currentState = State.Waiting; // Change the state to Waiting when reaching the destination
            waitTime = 5f; // Set the wait time to 5 seconds
            
        }

        if (isPlayerInRange)
        {
            agent.speed = 0;
            anim.SetBool("isQuiet", true);
            anim.SetBool("isIdle", true);
        }
        else
        {
            agent.speed = 2;
            anim.SetBool("isQuiet", false);
            anim.SetBool("isIdle", false);
        }
    }

    void Wait()
    {
        waitTime -= Time.deltaTime;
        anim.SetBool("isIdle", true);
        if (waitTime <= 0f)
        {
            currentState = State.Patrolling; // Change the state back to Patrolling after waiting
            destinationIndex = (destinationIndex + 1) % destinationPoints.Length; // Move to the next destination point
        }
    }

    /*void Dialoguing()
    {
        agent.speed = 0;

        //anim.SetBool("isTalking", true);

        currentState = State.Patrolling;
    }*/
    
    void OnDrawGizmos()
    {
        foreach(Transform point in destinationPoints)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(point.position, 1);
        }

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, visionRange);
    }

     private void OnTriggerEnter(Collider collision )
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = true;
        }

        if(collision.gameObject.CompareTag("Ruhe"))
        {
            isPlayerInRange = true;
        }

        if(collision.gameObject.CompareTag("Hangin"))
        {
            isPlayerInRange = true;
        }

        if(collision.gameObject.CompareTag("Kalju"))
        {
            isPlayerInRange = true;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = false;
        }

         if(collision.gameObject.CompareTag("Ruhe"))
        {
            isPlayerInRange = false;
        }

         if(collision.gameObject.CompareTag("Hangin"))
        {
            isPlayerInRange = false;
        }

         if(collision.gameObject.CompareTag("Kalju"))
        {
            isPlayerInRange = false;
        }
    }
}


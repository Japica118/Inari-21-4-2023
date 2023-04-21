using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.AI;


public class AI_NPCs : MonoBehaviour
{
    [SerializeField]private bool isPlayerInRange;

    public enum State
    {
        Patrolling,

        Dialoguing
    }

    public State currentState;

    NavMeshAgent agent;

    public Transform[] destinationPoints;
    
    int destinationIndex = 0;

    public float visionRange;

    private Animator anim;

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

            /*case State.Dialoguing:
                Dialoguing();
            break;*/
        }
    }

     void Patrol()
    {
        agent.destination = destinationPoints[destinationIndex].position;

        if(Vector3.Distance(transform.position, destinationPoints[destinationIndex].position) < 1)
        {
            if(destinationIndex < destinationPoints.Length)
            {
                destinationIndex += 1;
            }
            
            if(destinationIndex == destinationPoints.Length)
            {
                destinationIndex = 0;
            }
        
        //currentState = State.Patrolling;      
        }

        if(isPlayerInRange)
        {
            agent.speed = 0;

            anim.SetBool("isQuiet", true);
        }
        else
        {
            agent.speed = 2;
                
            anim.SetBool("isQuiet", false);
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


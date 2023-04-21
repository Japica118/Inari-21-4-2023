using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class AI_Enemies : MonoBehaviour
{
    public enum State
    {
        Patrolling,

        Chasing,

        Attacking
    }

    public State currentState;

    NavMeshAgent agent;

    public Transform[] destinationPoints;
    
    int destinationIndex = 0;

    public float visionRange;

    public Transform player;

    public Transform player2;

    public Transform player3;

    public Transform player4;

    [SerializeField] private float attackRange;

    // Start is called before the first frame update
    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
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
            case State.Chasing:
                Chase();
            break;
            default:
                Chase();
            break;
        
            case State.Attacking:
                Attack();
            break;
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
            
        }

        if(Vector3.Distance(transform.position, player.position) < visionRange && player.gameObject.activeInHierarchy)
        {
            currentState = State.Chasing;
        }

        if(Vector3.Distance(transform.position, player2.position) < visionRange && player2.gameObject.activeInHierarchy)
        {
            currentState = State.Chasing;
        }

        if(Vector3.Distance(transform.position, player3.position) < visionRange && player3.gameObject.activeInHierarchy)
        {
            currentState = State.Chasing;
        }

        if(Vector3.Distance(transform.position, player4.position) < visionRange && player4.gameObject.activeInHierarchy)
        {
            currentState = State.Chasing;
        }
    }

    void Chase()
    {
        if(player.gameObject.activeInHierarchy)
            agent.destination = player.position;
        
        if(player2.gameObject.activeInHierarchy)
            agent.destination = player2.position;

        if(player3.gameObject.activeInHierarchy)
            agent.destination = player3.position;

        if(player4.gameObject.activeInHierarchy)
            agent.destination = player4.position;

        if(Vector3.Distance(transform.position, player.position) > visionRange && player.gameObject.activeInHierarchy)
        {
            currentState = State.Patrolling;
        }

         if(Vector3.Distance(transform.position, player2.position) > visionRange && player2.gameObject.activeInHierarchy)
        {
            currentState = State.Patrolling;
        }

        if(Vector3.Distance(transform.position, player3.position) > visionRange && player3.gameObject.activeInHierarchy)
        {
            currentState = State.Patrolling;
        }

        if(Vector3.Distance(transform.position, player4.position) > visionRange && player4.gameObject.activeInHierarchy)
        {
            currentState = State.Patrolling;
        }

         
        if(Vector3.Distance(transform.position, player.position) < attackRange && player.gameObject.activeInHierarchy)
        {
            Debug.Log("Estoy atacando");

            SceneManager.LoadScene(1);

            currentState = State.Attacking;
        }

        if(Vector3.Distance(transform.position, player2.position) < attackRange && player2.gameObject.activeInHierarchy)
        {
            Debug.Log("Estoy atacando");

            SceneManager.LoadScene(1);

            currentState = State.Attacking;
        }

        if(Vector3.Distance(transform.position, player3.position) < attackRange && player3.gameObject.activeInHierarchy)
        {
            Debug.Log("Estoy atacando");

            SceneManager.LoadScene(1);

            currentState = State.Attacking;
        }

        if(Vector3.Distance(transform.position, player4.position) < attackRange && player4.gameObject.activeInHierarchy)
        {
            Debug.Log("Estoy atacando");

            SceneManager.LoadScene(1);

            currentState = State.Attacking;
        }
    }
    
    void Attack()
    {
        if(Vector3.Distance(transform.position, player.position) > attackRange && player.gameObject.activeInHierarchy)
        {
            currentState = State.Chasing;
        }

        if(Vector3.Distance(transform.position, player2.position) > attackRange && player2.gameObject.activeInHierarchy)
        {
            currentState = State.Chasing;
        }

        if(Vector3.Distance(transform.position, player3.position) > attackRange && player3.gameObject.activeInHierarchy)
        {
            currentState = State.Chasing;
        }

        if(Vector3.Distance(transform.position, player4.position) > attackRange && player4.gameObject.activeInHierarchy)
        {
            currentState = State.Chasing;
        }
    }
    

    void OnDrawGizmos()
    {
        foreach(Transform point in destinationPoints)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(point.position, 1);
        }

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, visionRange);

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }

}

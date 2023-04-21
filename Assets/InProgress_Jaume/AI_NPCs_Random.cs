using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI_NPCs_Random : MonoBehaviour
{
    public enum State
    {
        Patrolling,

        Dialoguing,

        Waiting,

        Travelling
    }

    public State currentState;

    NavMeshAgent agent;

    [SerializeField] private float visionRange;

    [SerializeField] [Range(0, 360)] private float visionAngle;

    [SerializeField] private LayerMask obstaclesMask;

    public Transform player;

    [SerializeField] float patrolRange = 10f;

    [SerializeField] private Transform patrolZone;
    
    [SerializeField] private float sec = 5f;

    private Animator anim;

    private bool isPlayerInRange;

    private GameObject currentGameObject;


   
    // Start is called before the first frame update
    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();

        anim = GetComponent<Animator>();
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

            case State.Travelling:
                Travel();
            break;

            case State.Waiting:
                Wait();
            break;

            /*case State.Dialoguing:
                Dialoguing();
            break;*/
        }
    }

     void Patrol()
    {
        Vector3 randomPosition;
        
        agent.speed = 2;

        if(RandomPoint(patrolZone.position, patrolRange, out randomPosition))
        {
            agent.destination = randomPosition;

            Debug.DrawRay(randomPosition, Vector3.up * 5, Color.blue, 5f);
        }

         if(isPlayerInRange = true && Input.GetButtonDown("Submit") || Input.GetKeyDown(KeyCode.JoystickButton1))
            {
                Debug.Log("Cambio a estado dialogo");
                
                currentState = State.Dialoguing;
            }

        currentState = State.Waiting;


    }

     bool RandomPoint(Vector3 center, float range, out Vector3 point)
    {
        Vector3 randomPoint = center + Random.insideUnitSphere * range;

        NavMeshHit hit;

        if(NavMesh.SamplePosition(randomPoint, out hit, 4, NavMesh.AllAreas))
        {
            point = hit.position;

            return true;
        }

        point = Vector3.zero;
        
        return false;
    }

    void Travel()
    {
        if(agent.remainingDistance <= 0.2)
        {
            currentState = State.Patrolling;
        }

        /*if(isPlayerInRange == true && Input.GetButtonDown("Submit"))
        {
            Debug.Log("Cambio a estado dialogo");
                
            currentState = State.Dialoguing;
        }*/ 

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

    void Wait()
    {
        sec -= Time.deltaTime;

        if(sec <= 0)
        {
            currentState = State.Patrolling;

            sec = 2;
        }

        currentState = State.Travelling;
    }

    bool FindTarget()
    {
        if(Vector3.Distance(transform.position, player.position) < visionRange)
        {
            Vector3 directionToTarget = (player.position - transform.position).normalized;

            if(Vector3.Angle(transform.forward, directionToTarget) < visionAngle / 2)
            {
                float distanceToTarget = Vector3.Distance(transform.position, player.position);

                if(!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstaclesMask))
                {
                    return true;
                }
            }
        }

        return false;
    }

    /*void Dialoguing()
    {
    
        agent.speed = 0;


    }*/

    

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, visionRange);

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(patrolZone.position, patrolRange);
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
        currentGameObject = collision.gameObject;
    }

    if(collision.gameObject.CompareTag("Hangin"))
    {
        isPlayerInRange = true;
        currentGameObject = collision.gameObject;
    }

    if(collision.gameObject.CompareTag("Kalju"))
    {
        isPlayerInRange = true;
        currentGameObject = collision.gameObject;
    }
}


   private void OnTriggerExit(Collider collision)
{
    if(collision.gameObject.CompareTag("Player"))
    {
        isPlayerInRange = false;
    }

    if(collision.gameObject == currentGameObject)
    {
        currentGameObject = null;
    }
}


    
}

using UnityEngine;
using UnityEngine.AI;

public enum NPCState
{
    Patrol,
    LookAtPlayer,
    FollowPlayer,
    ReturnHome
}

public class NPCAI : MonoBehaviour
{
    public static NPCAI Instance;
    [Header("Return Path")]
    public Transform[] returnPathPoints;
    private int returnPathIndex;

    [Header("References")]
    public NavMeshAgent agent;
    public Transform player;

    [Header("Patrol")]
    public Transform[] patrolPoints;
    private int currentPatrolIndex;

    [Header("Follow Settings")]
    public float followDistance = 3f;

    [Header("Return")]
    public Transform homePoint;

    private NPCState currentState = NPCState.Patrol;

    void Start()
    {
        Instance = this;
        agent.SetDestination(patrolPoints[currentPatrolIndex].position);
    }

    void Update()
    {
        switch (currentState)
        {
            case NPCState.Patrol:
                Patrol();
                break;

            case NPCState.LookAtPlayer:
                LookAtPlayer();
                break;

            case NPCState.FollowPlayer:
                FollowPlayer();
                break;

            case NPCState.ReturnHome:
                ReturnHome();
                break;
        }
    }


    void Patrol()
{
    if (agent.isStopped)
        agent.isStopped = false;

    if (!agent.pathPending && agent.remainingDistance < 0.5f)
    {
        currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Length;
        agent.SetDestination(patrolPoints[currentPatrolIndex].position);
    }
}

    void LookAtPlayer()
    {
        agent.isStopped = true;

        Vector3 direction = (player.position - transform.position).normalized;
        direction.y = 0;

        if (direction != Vector3.zero)
        {
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                lookRotation,
                Time.deltaTime * 5f
            );
        }
    }

    void FollowPlayer()
    {
        float distance = Vector3.Distance(transform.position, player.position);

        if (distance > followDistance)
        {
            agent.isStopped = false;
            agent.SetDestination(player.position);
        }
        else
        {
            agent.isStopped = true;
        }
    }

   void ReturnHome()
{
    if (agent.pathPending)
        return;

    if (agent.remainingDistance <= 0.5f)
    {
        returnPathIndex++;

        if (returnPathIndex >= returnPathPoints.Length)
        {
            agent.isStopped = true; 
            LookAtPlayer();
            return;
        }

        agent.SetDestination(returnPathPoints[returnPathIndex].position);
        
    }
}

    
    public void OnPlayerInteract()
    {
        currentState = NPCState.LookAtPlayer;
    }

    public void StartFollowing()
    {
        currentState = NPCState.FollowPlayer;
    }

    public void OnItemGiven()
{
    currentState = NPCState.ReturnHome;
    returnPathIndex = 0;

    agent.isStopped = false;
    agent.ResetPath();
    agent.SetDestination(returnPathPoints[returnPathIndex].position);
}
    
    public void BackToPatrol()
{
    if (currentState == NPCState.ReturnHome) return;

    agent.isStopped = false;
    agent.ResetPath();

    currentState = NPCState.Patrol;
    agent.SetDestination(patrolPoints[currentPatrolIndex].position);
}
}

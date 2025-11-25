using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class SimpleRoam : MonoBehaviour
{
    NavMeshAgent agent;
    public GameObject charaterSprite;
    public GameObject player;
    public GameObject[] navPoints;
    private int index = 0;
    // Start is called before the first frame update
    void Start()
    {
        
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        //charaterSprite.transform.LookAt(player.transform, Vector3.up);
        if (!agent.pathPending && agent.remainingDistance < 0.5f) // Did Reach my destination 
        {
            index = index % navPoints.Length;
            //Vector3 destination = transform.position + new Vector3(Random.Range(-5.0f,5.0f), 0.0f, Random.Range(-5.0f,5.0f));
            agent.destination = navPoints[index++].transform.position;
        }
}
}

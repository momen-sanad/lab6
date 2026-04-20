using UnityEngine;
using UnityEngine.AI;


public class enemyAI : MonoBehaviour
{

    [Header("Movement System")]
    [SerializeField]
    public Transform target;

    [SerializeField]
    public NavMeshAgent agent;

    void Start()
    {
        if(!agent)
            agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if(agent.isOnNavMesh && target)
            agent.SetDestination(target.position);
        else
            Debug.LogWarning("Agent is not on NavMesh or target is not set.");
    }
}

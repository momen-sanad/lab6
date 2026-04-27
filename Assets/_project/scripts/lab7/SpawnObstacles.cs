using UnityEngine;
using UnityEngine.AI;
using Unity.AI.Navigation;

public class SpawnObstacles : MonoBehaviour
{
    [Header("Spawning")]
    public GameObject coverPrefab;          
    public int spawnCount = 10;
    public float areaSize = 15f;            
    public float minDistanceFromPlayer = 5f;
    public int maxAttemptsPerSpawn = 20;    

    [Header("Constraint Reference")]
    public Transform playerStart;           

    [Header("NavMesh")]
    public NavMeshSurface surface;          

    [Header("Path Validation")]
    public NavMeshAgent validationAgent;
    public Transform goalPosition;

    private void Start()
    {
        GenerateLevel();

        if (surface)
        {
            surface.BuildNavMesh();
            Debug.Log("NavMesh baked successfully!");
        }
        else
        {
            Debug.LogWarning("No NavMeshSurface assigned. Skipping runtime bake.");
        }

        ValidatePath();
    }

    void GenerateLevel()
    {
        if (!coverPrefab)
        {
            Debug.LogError("Cover prefab is not assigned.");
            return;
        }

        Vector3 playerStartPos = (playerStart) ? playerStart.position : Vector3.zero;

        int spawned = 0;
        int attempts = 0;
        int maxAttempts = Mathf.Max(spawnCount * maxAttemptsPerSpawn, spawnCount);

        while (spawned < spawnCount && attempts < maxAttempts)
        {
            attempts++;

            Vector3 newPos = new Vector3(
                Random.Range(-areaSize, areaSize),
                0f,
                Random.Range(-areaSize, areaSize)
            );

            if (Vector3.Distance(newPos, playerStartPos) < minDistanceFromPlayer)
                continue;

            Instantiate(coverPrefab, newPos, Quaternion.identity);
            spawned++;
        }

        if (spawned < spawnCount)
        {
            Debug.LogWarning(
                $"Only spawned {spawned}/{spawnCount} cover blocks. " +
                $"Try increasing areaSize or lowering minDistanceFromPlayer."
            );
        }
    }

    void ValidatePath()
    {
        if (!validationAgent || !goalPosition)
        {
            Debug.LogWarning("Path validation skipped. Assign validationAgent and goalPosition.");
            return;
        }

        NavMeshPath path = new NavMeshPath();

        bool foundPath = validationAgent.CalculatePath(goalPosition.position, path);

        if (foundPath && path.status == NavMeshPathStatus.PathComplete)
        {
            Debug.Log("Valid path found! Level is playable.");
        }
        else
        {
            Debug.LogWarning($"Path is {path.status} — regenerate level!");
        }
    }
}
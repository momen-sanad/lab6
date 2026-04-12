using UnityEngine;

public class HazardSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject hazard;

    [SerializeField]
    private float spawnInterval = 2f;
    private float timer = 0;

    private void SpawnRandomHazard()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(-10f, 10f), 0, Random.Range(-10f, 10f));
        Instantiate(hazard, spawnPosition, Quaternion.identity);
    }

    void Update()
    {
        timer += Time.deltaTime;
        
        if (timer >= spawnInterval)
        {
            SpawnRandomHazard();
            timer = 0;
        }

    }
}

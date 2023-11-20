using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    // Vars
    [SerializeField] public GameObject enemyPrefab;
    [SerializeField] public float startTime = 2.0f;
    [SerializeField] public float endTime = 12.0f;
    [SerializeField] public float spawnRate = 2.0f;
    [SerializeField] public float destroyTime = 4.0f;

    // Start is called before the first frame update
    void Start()
    {
        WavesManager.instance.AddWave(this);
        InvokeRepeating("Spawn", startTime, spawnRate);
        Invoke("EndSpawner", endTime);
        // Invoke("CancelInvoke", endTime);
    }

    void Spawn() {
        float randomX = Random.Range(-10.0f, 10.0f); 
        float randomY = 0.0f; 
        // float randomY = Random.Range(-10.0f, 10.0f); 
        float randomZ = Random.Range(-10.0f, 10.0f); 
        Vector3 origin = transform.position;
        
        Vector3 randomPosition = new Vector3(origin.x + randomX, origin.y + randomY, origin.z + randomZ);
        GameObject enemyIns = Instantiate(enemyPrefab, randomPosition, transform.rotation);
        DestroyEnemy(enemyIns);
    }

    void DestroyEnemy(GameObject enemy) {
        Destroy(enemy, destroyTime);
        ScoreManager.instance.addAmount(-2);
    }

    void EndSpawner() {
        WavesManager.instance.RemoveWave(this);
        CancelInvoke();
    }
}
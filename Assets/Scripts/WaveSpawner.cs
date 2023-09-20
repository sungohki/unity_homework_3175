using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    // Vars
    [SerializeField] public GameObject enemyPrefab;
    [SerializeField] public float startTime = 2.0f;
    [SerializeField] public float endTime = 10.0f;
    [SerializeField] public float spawnRate = 1.0f;
    [SerializeField] public float destoryTime = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", startTime, spawnRate);
        Invoke("CancelInvoke", endTime);
    }

    void Spawn() {
        GameObject enemyIns = Instantiate(enemyPrefab, transform.position, transform.rotation);
        Destroy(enemyIns, destoryTime);
    }
}
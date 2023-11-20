using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    // Vars
    [SerializeField] private float enemySpd = 10.0f;

    void Update()
    {
        transform.Translate(0, 0, enemySpd * Time.deltaTime * Random.Range(0.5f, 1.8f));
    }
}

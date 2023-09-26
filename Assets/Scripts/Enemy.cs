using UnityEngine;

public class Enemy : MonoBehaviour
{
    void Start()
    {
        EnemyManager.instance.enemies.Add(this);
    }

    void Update()
    {
        EnemyManager.instance.enemies.Remove(this);
    }
}

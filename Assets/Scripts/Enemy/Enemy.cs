using UnityEngine;

public class Enemy : MonoBehaviour
{
    void Start()
    {
        EnemyManager.instance.AddEnemy(this);
    }

    private void OnDestroy() {
        EnemyManager.instance.RemoveEnemy(this);
    }
}

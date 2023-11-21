using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject particlePrefab;
    void Start()
    {
        EnemyManager.instance.AddEnemy(this);
    }

    private void OnDestroy() {
        Instantiate(particlePrefab, transform.position, transform.rotation);
        EnemyManager.instance.RemoveEnemy(this);
    }
}

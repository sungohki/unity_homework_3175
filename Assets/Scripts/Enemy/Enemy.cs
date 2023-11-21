using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject particlePrefab;
    void Start()
    {
        EnemyManager.instance.AddEnemy(this);
    }

    private void OnDestroy() {
        GameObject temp = Instantiate(particlePrefab, transform.position, transform.rotation);
        Destroy(temp, 4.0f);
        EnemyManager.instance.RemoveEnemy(this);
    }
}

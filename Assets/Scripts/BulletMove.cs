using UnityEngine;

public class BulletMove : MonoBehaviour
{
    // Vars
    [SerializeField] private float bulletSpd = 30.0f;

    void Update()
    {
        transform.Translate(0, 0, bulletSpd * Time.deltaTime);
    }
}

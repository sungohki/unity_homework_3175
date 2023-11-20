using UnityEngine;

public class BulletMove : MonoBehaviour
{
    // Vars
    [SerializeField] private float bulletSpd = 30.0f;
    [SerializeField] private float bulletDmg = -2.0f;

    void Update()
    {
        transform.Translate(0, 0, bulletSpd * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other) {
        Destroy(gameObject);
        if (other.GetComponent<ObjectLife>()) {
            other.GetComponent<ObjectLife>().addLifePoint(bulletDmg);
        }
        if (other.tag == "Enemy"){
            Destroy(other.gameObject);
            Debug.Log("enemy destroyed!!");
        }
    }
}

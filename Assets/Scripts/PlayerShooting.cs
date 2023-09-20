using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    // Variables
    [SerializeField] public Transform gun; // 총구 위치(Transform)
    [SerializeField] public GameObject bulletPrefab; // 발사할 총알 프리팹

    void Update()
    {
        // 마우스 왼쪽 버튼을 클릭하거나 다른 입력 방식으로 발사할 수 있도록 조절 가능
        if (Input.GetKeyDown(KeyCode.Mouse0))
            Shoot();
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, gun.position, gun.rotation);
        // Rigidbody bulletRb= bullet.GetComponent<Rigidbody>();

        Destroy(bullet, 3.0f); // 총알이 일정 시간 후에 파괴되도록 설정
    }
}

using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    // Variables
    public Transform gunTransform; // 총구 위치(Transform)
    [SerializeField] public GameObject bulletPrefab; // 발사할 총알 프리팹
    [SerializeField] public float bulletSpeed = 10.0f; // 총알 속도
    [SerializeField] public float fireRate = 0.5f; // 발사 간격
    [SerializeField] public float powerUp = 0.5f;
    [SerializeField] private float nextFireTime = 0.2f; // 다음 발사 가능한 시간

    void Update()
    {
        // 마우스 왼쪽 버튼을 클릭하거나 다른 입력 방식으로 발사할 수 있도록 조절 가능
        if (Input.GetButtonDown("Fire1") && Time.time >= nextFireTime)
            Shoot();
    }

    void Shoot()
    {
        // 발사 간격 설정
        nextFireTime = Time.time + (fireRate * (Input.GetKey(KeyCode.LeftShift) ? powerUp : 1.0f) );

        // 총알 생성 및 초기화
        GameObject bullet = Instantiate(bulletPrefab, gunTransform.position, gunTransform.rotation);
        Rigidbody bulletRb= bullet.GetComponent<Rigidbody>();

        // 총알에 속도 부여
        bulletRb.velocity = gunTransform.forward * bulletSpeed;

        // 총알이 어떤 충돌에도 반응하도록 설정 (충돌 시 총알 파괴)
        Destroy(bullet, 3.0f); // 총알이 일정 시간 후에 파괴되도록 설정
    }
}

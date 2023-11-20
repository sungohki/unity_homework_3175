using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    // Variables
    [SerializeField] public Transform gun; // 총구 위치(Transform)
    [SerializeField] public GameObject weapon1; // 발사할 총알 프리팹
    [SerializeField] public GameObject weapon2; // 발사할 총알 프리팹
    public int  weaponMode = 1;

    void Update()
    {
        changeWeapon();
        // 마우스 왼쪽 버튼을 클릭하거나 다른 입력 방식으로 발사할 수 있도록 조절 가능
        if (Input.GetKeyDown(KeyCode.Mouse0))
            Shoot();
    }

    void Shoot()
    {
        GameObject bullet;
        if (weaponMode == 1) {
            bullet = Instantiate(weapon1, gun.position, gun.rotation);
            Destroy(bullet, 3.0f); // 총알이 일정 시간 후에 파괴되도록 설정
        } else if (weaponMode == 2) {
            bullet = Instantiate(weapon2, gun.position, gun.rotation);
            Destroy(bullet, 3.0f); // 총알이 일정 시간 후에 파괴되도록 설정
        }
        // Rigidbody bulletRb= bullet.GetComponent<Rigidbody>();
    }

    void changeWeapon() {
        if (Input.GetKey(KeyCode.Alpha1))
            weaponMode = 1;
        else if (Input.GetKey(KeyCode.Alpha2))
            weaponMode = 2;
    }
}

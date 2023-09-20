using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] float sensitivity = 2.0f; // 마우스 감도 조절 변수

    [SerializeField] float rotationX = 0.0f; // X 축 회전 각도 변수
    [SerializeField] float rotationY = 0.0f; // Y 축 회전 각도 변수

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // 게임 시작 시 마우스 커서를 화면 중앙에 고정
    }

    void Update()
    {
        // 마우스 입력 받기
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        // 카메라 X 축 회전 계산
        rotationX -= mouseY * sensitivity;
        rotationX = Mathf.Clamp(rotationX, -90.0f, 90.0f); // X 축 회전 제한

        // 카메라 Y 축 회전 계산
        rotationY += mouseX * sensitivity;
        
        // 플레이어 회전
        transform.rotation = Quaternion.Euler(0, rotationY, 0);

        // 카메라 회전
        // transform.rotation = Quaternion.Euler(rotationX, rotationY, 0);
    }
}

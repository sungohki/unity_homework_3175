using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemySight : MonoBehaviour
{
    public float distance = 10.0f;
    public float angle;
    public LayerMask objectsLayers;
    public LayerMask obstaclesLayers;
    public Collider detectedObject;

    private void Update() {
        Collider[] colliders = Physics.OverlapSphere(
            transform.position, distance, (int)objectsLayers
        );
        // 구 내부에 존재하는 모든 콜라이더를 배열로 반환

        detectedObject = null;
        for (int i = 0; i < colliders.Length; i++) {
            Collider collider = colliders[i];

            Vector3 directionToController = Vector3.Normalize(
                collider.bounds.center - transform.position
            );

            float angleToCollider = Vector3.Angle(
                transform.forward, directionToController
            );

            if (angleToCollider < angle) {
                // Viewing Angle Filter
                if (!Physics.Linecast(transform.position, collider.bounds.center, out RaycastHit hit, obstaclesLayers)) {
                    // Occulusion Filter
                    Debug.DrawLine(transform.position, collider.bounds.center, Color.green);
                    detectedObject = collider;
                    break;
                } else {
                    Debug.DrawLine(transform.position, hit.point, Color.red);
                }
            }
        }
    }

    void OnDrawGizmos() {
        // wireSphere을 출력하는 상태 함수
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, distance);

        Vector3 rightDirection = Quaternion.Euler(0, angle, 0) * transform.forward;
        Gizmos.DrawRay(transform.position, rightDirection * distance);

        Vector3 leftDirection = Quaternion.Euler(0, -angle, 0) * transform.forward;
        Gizmos.DrawRay(transform.position, leftDirection * distance);
    }


}

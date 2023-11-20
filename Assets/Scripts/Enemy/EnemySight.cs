using Unity.VisualScripting;
using UnityEngine;

public class EnemySight : MonoBehaviour
{
    public float distance;
    public float angle;
    public LayerMask objectsLayers;
    public LayerMask obstaclesLayers;
    public Collider detectedObject;

    private void Update() {
        Collider[] colliders = Physics.OverlapSphere(
            transform.position, distance, (int)objectsLayers
        );

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
                if (!Physics.Linecast(transform.position, collider.bounds.center, (int)obstaclesLayers)) {
                    detectedObject = collider;
                    break;
                }
            }
        }
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, distance);
    }
}

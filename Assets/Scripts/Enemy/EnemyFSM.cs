using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFSM : MonoBehaviour {
    // public enum EnenmyState { GoToBase, AttackBase, ChasePlayer, AttackPlayer }
    public enum EnenmyState {  ChasePlayer, AttackPlayer }
    public EnenmyState currnetState;

    public EnemySight sightSensor;
    public Transform baseTransform;
    public float playerChaseDistance;
    public float playerAttackDistance;

    public GameObject player;

    void Update()
    {
        if (currnetState == EnenmyState.ChasePlayer) {
            ChasePlayer();
        } else {
            AttackPlayer();
        }
    }
   void ChasePlayer() {
        print("state : ChasePlayer");

        Vector3 directionToPlayer = (player.transform.position - transform.position).normalized;
        float distanceToPlayer = Vector3.Distance(transform.position, sightSensor.detectedObject.transform.position);
        transform.Translate(directionToPlayer * distanceToPlayer * Time.deltaTime);

        if (distanceToPlayer <= playerAttackDistance) {
            currnetState = EnenmyState.AttackPlayer;
        }
    }
   void AttackPlayer() {
        print("state : AttackPlayer");

        float distanceToPlayer = Vector3.Distance(transform.position, sightSensor.detectedObject.transform.position);

        if (distanceToPlayer > playerAttackDistance * 1.1f) {
            currnetState = EnenmyState.ChasePlayer;
        }
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, playerAttackDistance);

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, playerChaseDistance);
    }
}

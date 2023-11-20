using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFSM : MonoBehaviour {
    public enum EnenmyState { GoToBase, AttackBase, ChasePlayer, AttackPlayer }
    public EnenmyState currnetState;

    public EnemySight sightSensor;
    public Transform baseTransform;
    public float baseAttackDistance;
    public float playerAttackDistance;

    void Update()
    {
        if (currnetState == EnenmyState.GoToBase) {
            GoToBase();
        } else if (currnetState == EnenmyState.AttackBase) {
            AttackBase();
        } else if (currnetState == EnenmyState.ChasePlayer) {
            ChasePlayer();
        } else {
            AttackPlayer();
        }
    }

    void GoToBase() {
        // print("state : GoToBase");
        if (sightSensor.detectedObject != null) {
            currnetState = EnenmyState.ChasePlayer;
        }

        float distanceToBase = Vector3.Distance(transform.position, baseTransform.position);

        if (distanceToBase < baseAttackDistance) {
            currnetState = EnenmyState.AttackBase;
        }
    }
   void AttackBase() {
        // print("state : AttackBase");

    }
   void ChasePlayer() {
        // print("state : ChasePlayer");
        if (sightSensor.detectedObject == null) {
            currnetState = EnenmyState.GoToBase;
            return;
        }

        float distanceToPlayer = Vector3.Distance(transform.position, sightSensor.detectedObject.transform.position);

        if (distanceToPlayer <= playerAttackDistance) {
            currnetState = EnenmyState.AttackPlayer;
        }
    }
   void AttackPlayer() {
        // print("state : AttackPlayer");
        if (sightSensor.detectedObject == null) {
            currnetState = EnenmyState.GoToBase;
            return;
        }

        float distanceToPlayer = Vector3.Distance(transform.position, sightSensor.detectedObject.transform.position);

        if (distanceToPlayer > playerAttackDistance * 1.1f) {
            currnetState = EnenmyState.ChasePlayer;
        }
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, playerAttackDistance);

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, baseAttackDistance);
    }
}

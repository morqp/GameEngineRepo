using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyChase : MonoBehaviour {

  
  [SerializeField]
  private Animator enemyAnimator;

  [SerializeField]
  private float walkSpeed;

  [SerializeField]
  private float runSpeed;

  [SerializeField]
  private float triggerRange;

  private GameObject target;
  private NavMeshAgent navMeshAgent;
  private Vector3 differenceVector;

  void Start() {
    navMeshAgent = GetComponent<NavMeshAgent>();
    target = GameObject.FindGameObjectWithTag("Player");
  }

  void Update() {
    GetTargetPosition();
  }

  void FixedUpdate() {
    Movement();
  }

  private void GetTargetPosition() {
    navMeshAgent.destination = target.transform.position;
    differenceVector = navMeshAgent.destination - transform.position;
  }

  private void Movement() {
    if (differenceVector.magnitude >= triggerRange) {
      navMeshAgent.speed = walkSpeed;
      enemyAnimator.SetBool("isRunning", false);
      enemyAnimator.SetBool("isWalking", true);
    }
    else if (differenceVector.magnitude < triggerRange) {
      navMeshAgent.speed = runSpeed;
      enemyAnimator.SetBool("isWalking", false);
      enemyAnimator.SetBool("isRunning", true);
    }

    if (navMeshAgent.velocity.magnitude < 1) {
      enemyAnimator.SetBool("isWalking", false);
      enemyAnimator.SetBool("isRunning", false);
    }
  }
}

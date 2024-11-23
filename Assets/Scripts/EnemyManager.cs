using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour {
  [SerializeField]
  private float damage = 1f;

  [SerializeField]
  private float health = 5f;

  [SerializeField]
  private Animator enemyAnimator;

  [SerializeField]
  private float walkSpeed;

  [SerializeField]
  private float runSpeed;

  [SerializeField]
  private float triggerRange;

  [SerializeField]
  private Image healthBar;

  [SerializeField]
  private GameObject healthCanvas;

  private GameObject player;
  private GameObject target;
  private NavMeshAgent navMeshAgent;
  private Vector3 differenceVector;
  private AudioSource deathSound;
  public bool killEnemy = false;

  public void Hit(float damage) {
    health -= damage;
    healthBar.fillAmount = health / 5f;
    if (health <= 0) {
      enemyAnimator.SetBool("isDead", true);
      deathSound.Play();
      healthCanvas.SetActive(false);
      killEnemy = true;
      Destroy(gameObject, 4f);
    }
  }

  private void Start() {
    player = GameObject.FindGameObjectWithTag("Player");
    navMeshAgent = GetComponent<NavMeshAgent>();
    target = GameObject.FindGameObjectWithTag("Player");
    deathSound = GetComponent<AudioSource>();
  }

  private void Update() {
    GetTargetPosition();
  }

  private void SuicideConditions() {
    if (killEnemy) {
      navMeshAgent.speed = 0f;
      damage = 0f;
    }
  }

  private void FixedUpdate() {
    Movement();
    SuicideConditions();
  }

  private void OnCollisionEnter(Collision collision) {
    if (collision.gameObject == player) {
      player.GetComponent<PlayerManager>().Hit(damage);
      player.GetComponent<PlayerManager>().bloodSplatter = true;
    }
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

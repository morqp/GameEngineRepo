using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour {

  private bool wantsToShoot = false;
  private GameObject enemy;
  private AudioSource shootSound;

  [SerializeField]
  private Animator playerAnimator;

  [SerializeField]
  GameObject playerCamera;

  [SerializeField]
  private float travelDistance;

  [SerializeField]
  private float bulletDamage;

  [SerializeField]
  private ParticleSystem muzzleFlash;

  [SerializeField]
  private GameManager gameManager;

  void Start() {
    enemy = GameObject.FindGameObjectWithTag("Enemy");
    shootSound = GetComponent<AudioSource>();
  }

  void Update() {
    CheckInput();

/*    if (playerAnimator.GetBool("isShooting")) {
      playerAnimator.SetBool("isShooting", false);
    }*/

  }

  private void FixedUpdate() {
    Shoot();
    CheckEndGame();
  }

  private void CheckEndGame() {
    if (gameManager.gameEnd) {
      wantsToShoot = false;
    }
  }

  private void CheckInput() {
    if (Input.GetMouseButtonDown(0)) {
      wantsToShoot = true;
    }
  }

  private void Shoot() {
    if (wantsToShoot && !gameManager.gameEnd) {
      wantsToShoot = false;

      playerAnimator.SetBool("isShooting", true);

      muzzleFlash.Play();
      shootSound.Play();

      RaycastHit hit;

      if (Physics.Raycast(playerCamera.transform.position, transform.forward, out hit, travelDistance)){

        EnemyManager enemyManager = hit.transform.GetComponent<EnemyManager>();

        if (enemyManager != null && !enemyManager.killEnemy){
          enemyManager.Hit(bulletDamage);
        }

      }
    }

  }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
  [SerializeField]
  private GameObject prefab;

  [SerializeField]
  private float coolDown;

  [SerializeField]
  GameManager gameManager;

  private GameObject instantiatePrefab = null;
  private float lastSpawnTime;
  private int enemiesAlive;

  private void Start() {
    lastSpawnTime = Time.time;
  }

  private void Update() {
    EnemyAmountCheck();
    SpawnEnemy();
  }

  private void EnemyAmountCheck() {
    enemiesAlive = GameObject.FindGameObjectsWithTag("Enemy").Length;
    Debug.Log("enemies: " + enemiesAlive);
  }

  private void SpawnEnemy() {
    if (!gameManager.gameEnd) {
      if (Time.time - lastSpawnTime >= coolDown && enemiesAlive < 15) {
        instantiatePrefab = Instantiate(prefab, transform.position, transform.rotation);
        lastSpawnTime = Time.time;
      }
    }
  }
}

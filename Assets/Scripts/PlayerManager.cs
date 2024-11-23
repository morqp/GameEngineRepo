using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
  [SerializeField]
  private float health = 20f;

  [SerializeField]
  private Text healthText;

  [SerializeField]
  GameManager gameManager;

  [SerializeField]
  private Image healthBar;

  [SerializeField]
  private GameObject blood;

  [SerializeField]
  private AudioSource painSound;

  public bool bloodSplatter;

  public void Hit(float damage) {
    health -= damage;
    healthBar.fillAmount = health / 20f;
    if (bloodSplatter) {
      StartCoroutine(ActivateBloodSplatter());
      bloodSplatter = false;
    }
    if (health <= 0) {
      gameManager.EndGame();
    }
  }

  private IEnumerator ActivateBloodSplatter() {
    blood.SetActive(true);
    painSound.Play();
    yield return new WaitForSeconds(0.25f);
    blood.SetActive(false);
  }

}

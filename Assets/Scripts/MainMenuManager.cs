using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour {

  [SerializeField]
  private AudioSource buttonClick;

  public void StartGame() {
    SceneManager.LoadScene(1);
  }

  public void ExitGame() {
    Debug.Log("Quitting Game");
    Application.Quit();
  }

  public void ButtonClickSound() {
    buttonClick.Play();
  }

}

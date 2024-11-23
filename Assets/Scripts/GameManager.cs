using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour {

  [SerializeField]
  private TextMeshProUGUI time;

  [SerializeField]
  private GameObject endText;

  [SerializeField]
  private GameObject startText;

  [SerializeField]
  private GameObject endScreen;

  private Text endingText;
  private float seconds = 0;
  private bool addTime;
  private bool started;
  private string formattedTime;
  private AudioSource backgroundMusic;

  public bool gameEnd;

  private void Start() {
    endingText = endText.GetComponent<Text>();
    backgroundMusic = GetComponent<AudioSource>();
  }

  private void Update() {
    if (!gameEnd) {
      TimerCheck();
    }
    StartTextCheck();
  }

  public void EndGame() {
    Time.timeScale = 0f;
    gameEnd = true;
    Cursor.lockState = CursorLockMode.None;
    endingText.text = "you survived for\n<size=80>" + formattedTime + "</size>";
    endScreen.SetActive(true);
    time.gameObject.SetActive(false);
    AudioListener.volume = 0f;
  }

  private void TimerCheck() {
    if (addTime == false) {
      addTime = true;
      StartCoroutine(Timer());
    }
  }

  private void StartTextCheck() {
    if (started == false) {
      started = true;
      StartCoroutine(StartText());
    }
  }

  private IEnumerator Timer() {
    yield return new WaitForSeconds(1f);
    seconds++;
    time.color = Color.white;
    TimeSpan timeSpan = TimeSpan.FromSeconds(seconds);
    formattedTime = string.Format("{0}:{1:00}", Mathf.FloorToInt((float)timeSpan.TotalMinutes), timeSpan.Seconds);
    time.text = "TIME: " + formattedTime;
    addTime = false;
  }

  private IEnumerator StartText() {
    startText.SetActive(true);
    yield return new WaitForSeconds(5f);
    startText.SetActive(false);
  }
  public void ExitGame() {
    Debug.Log("Quitting Game");
    Application.Quit();
  }

  public void RestartGame() {
    SceneManager.LoadScene(1);
    Time.timeScale = 1f;
    AudioListener.volume = 1f;
  }
  
  public void BackToMenu() {
    SceneManager.LoadScene(0);
    Time.timeScale = 1f;
    AudioListener.volume = 1f;
  }

}

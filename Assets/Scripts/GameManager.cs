using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int enemiesAlive = 0;
    public int round = 0;
    public GameObject[] spawnPoints;
    public GameObject enemyPrefab;

    public GameObject[] uselessUI;
    public Text roundNumer;
    public Text roundsSurvived;
    public GameObject endScreen;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (enemiesAlive == 0)
        {

            round++;
            roundNumer.text = "Round " + round.ToString();
            NextWave(round);
        }
    }
    public void NextWave(int round)
    {
        for (int i = 0; i < round; i++)
        {
            GameObject spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

            GameObject enemySpawned = Instantiate(enemyPrefab, spawnPoint.transform.position, Quaternion.identity);
            enemySpawned.GetComponent<Enemymanager>().manager = GetComponent<GameManager>();
            enemiesAlive++;

        }
    }
    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }
    public void EndGame()
    {
        endScreen.SetActive(true);
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        roundsSurvived.text = round.ToString();
        foreach ( var item in uselessUI)
        {
            item.gameObject.SetActive(false);
        }
    }
}

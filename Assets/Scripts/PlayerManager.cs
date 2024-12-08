using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public float health = 100;
    public Text playerHealth;

    public GameManager gameManager;
    public void Hit(float dmg)
    {
        health -= dmg;
        playerHealth.text = health.ToString() + " Health";
        if (health <= 0)
        {
            gameManager.EndGame();
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

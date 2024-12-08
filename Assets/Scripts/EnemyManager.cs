using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemymanager : MonoBehaviour
{
    public GameObject player;
    private NavMeshAgent agent;
    public Animator enemyAnimator;
    public float dmg = 20f;
    public float zHealth = 100f;

    public GameManager manager;
    public void ZHit(float damage)
    {
        zHealth -= damage;
        if (zHealth <= 0)
        { 
            manager.enemiesAlive -= 1;
            Destroy(gameObject);
        }
    }

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = player.transform.position;
        if (agent.velocity.magnitude > 1)
        {
            enemyAnimator.SetBool("isRunning", true);
        }
        else
        {
            enemyAnimator.SetBool("isRunning", false);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == player)
        {
            player.GetComponent<PlayerManager>().Hit(dmg);
        }
    }
}

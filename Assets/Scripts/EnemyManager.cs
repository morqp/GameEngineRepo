using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemymanager : MonoBehaviour
{
    public GameObject player;
    private NavMeshAgent agent;
    public Animator enemyAnimator;
    public float dmg = 10f;
    public float zHealth = 100f;

    public GameManager manager;

    private AudioSource audioSource;
    public AudioClip runningSound;

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

        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = player.transform.position;
        if (agent.velocity.magnitude > 1)
        {
            enemyAnimator.SetBool("isRunning", true);

            if (!audioSource.isPlaying)
            {
                audioSource.clip = runningSound;
                audioSource.loop = true;
                audioSource.Play();
            }
        }
        else
        {
            enemyAnimator.SetBool("isRunning", false);

            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }
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

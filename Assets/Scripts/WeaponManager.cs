using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class WeaponManager : MonoBehaviour
{
    public Camera playerCam;
    public float weaponRange = 100f;
    public float dmg = 15f;
    public Animator FPSAnim;

    public AudioSource audioSource; 
    public AudioClip shootSound;

    public GameObject gameOverScreen;

    void Start()
    {
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (FPSAnim.GetBool("isShooting"))
        {
            FPSAnim.SetBool("isShooting", false);
        }
        if (Input.GetButtonDown("Fire1"))
        {
           
            Shoot();
        }
    }
    public void Shoot()
    {
        if (!gameOverScreen.activeSelf)
        {
            audioSource.PlayOneShot(shootSound);
        }

        FPSAnim.SetBool("isShooting", true);
        RaycastHit hit;
        Physics.Raycast(playerCam.transform.position, transform.forward * -1, out hit, weaponRange);

        Enemymanager enemyManager = hit.transform.GetComponent<Enemymanager>();
        if (enemyManager!=null)
        {
            enemyManager.ZHit(dmg);
        }

    }
}

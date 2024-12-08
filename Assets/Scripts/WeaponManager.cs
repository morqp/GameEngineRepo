using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public Camera playerCam;
    public float weaponRange = 50f;
    public float dmg = 15f;
    public Animator FPSAnim;
    void Start()
    {
        
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

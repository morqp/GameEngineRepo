using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicScript : MonoBehaviour
{
 
    [SerializeField] private float rotMag = 100f;
    void Start()
    {
    }

    void Update()
    {
        transform.Rotate(0, rotMag * Time.deltaTime, 0);
    }
}

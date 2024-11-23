using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovement : MonoBehaviour {
  
  [SerializeField]
  private float speed;

  [SerializeField]
  private float maxYAngle;

  [SerializeField]
  GameManager gameManager;

  Vector3 turn;


  private void Start() {
    Cursor.lockState = CursorLockMode.Locked; 
  }

  private void Update() {
    turn.x += Input.GetAxis("Mouse X") * speed;
    turn.y += Input.GetAxis("Mouse Y") * speed;
  }

  private void FixedUpdate() {
    if (!gameManager.gameEnd) {
      turn.y = Mathf.Clamp(turn.y, -maxYAngle, maxYAngle);
      transform.localRotation = Quaternion.Euler(-turn.y, turn.x, 0);
    }
  }
}

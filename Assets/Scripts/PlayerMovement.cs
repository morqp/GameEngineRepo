using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

  [SerializeField]
  public float walkForce;

  [SerializeField]
  private float jumpForce;

  [SerializeField]
  private float turnForce;

  [SerializeField]
  private float maxWalkSpeed;

  bool isGrounded;
  bool wantsToJump;
  Vector3 walk;
  Vector3 jump;
  Rigidbody rb;
  private AudioSource footStepsSound;
  private bool isWalking = false;

  private void Start() {
    rb = GetComponent<Rigidbody>();
    jump = new Vector3(0.0f, 2.0f, 0.0f);
    footStepsSound = GetComponent<AudioSource>();
  }

  private void Update() {
    Walking();
    JumpCheck();
    UpdateFootstepsSound();
  }

  private void FixedUpdate() {
    if (wantsToJump && isGrounded) {
      isGrounded = false;
      wantsToJump = false;
      rb.AddForce(jump * jumpForce, ForceMode.Impulse);
    }
    
    if (rb.velocity.magnitude < maxWalkSpeed) {
      rb.AddForce(walk.z * walkForce * transform.forward);
    }

    if (rb.velocity.magnitude < maxWalkSpeed) {
      rb.AddForce(walk.x * walkForce * transform.right);
    }
    
  }

  private void Walking() {
    walk = Vector3.zero;

    if (Input.GetKey(KeyCode.W)) {
      walk.z += 1;
    }
    if (Input.GetKey(KeyCode.S)) {
      walk.z += -1;
    }
    if (Input.GetKey(KeyCode.A)) {
      walk.x -= 1;
    }
    if (Input.GetKey(KeyCode.D)) {
      walk.x += 1;
    }

    isWalking = walk != Vector3.zero;
  }

  private void JumpCheck() {
    if (Input.GetKeyDown(KeyCode.Space) && isGrounded) {
      wantsToJump = true;
    }
  }

  private void UpdateFootstepsSound() {
    if (isWalking && !footStepsSound.isPlaying) {
      footStepsSound.Play();
    }
    else if (!isWalking && footStepsSound.isPlaying) {
      footStepsSound.Stop();
    }
  }

  private void OnCollisionEnter(Collision collision) {
    //Debug.DrawRay(collision.contacts[0].point, collision.contacts[0].normal, Color.magenta);
    if (collision.contacts[0].normal.y > 0.7f) {
      isGrounded = true;
    }
  }
}

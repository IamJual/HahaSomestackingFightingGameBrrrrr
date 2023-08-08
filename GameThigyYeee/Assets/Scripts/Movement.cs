using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public float speed = 7.125f;
    public float dashMultiplayer = 10f;

    public float jumpHeight = 50f;
    public float doubleJumpUses = 1f;

    public Transform groundCheck;
    public LayerMask ground;
    bool onGround = false;

    public Rigidbody rb;
    float doubleJumps;


    void Start() {
        rb = GetComponent<Rigidbody>();
        doubleJumps = doubleJumpUses;
    }

    void Update() {

        Dash();
        DoubleJump();
        Move();

    }


    public void Move() {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        transform.Translate(movement * speed * Time.deltaTime);
    }
    public void DoubleJump() {

        onGround = Physics.CheckSphere(groundCheck.position, .1f, ground);

        if (Input.GetButtonDown("Vertical") && (onGround || doubleJumps > 0)) {
            
            doubleJumps = doubleJumps - 1;
            rb.AddForce(new Vector3(0, jumpHeight, 0), ForceMode.Impulse);
        }

        if (onGround) {
            doubleJumps = doubleJumpUses;
        }
    }

    public void Dash() {
        if (Input.GetButtonDown("Jump")) {
            rb.AddForce(new Vector3(speed * dashMultiplayer, 0, 0) * Input.GetAxis("Horizontal"), ForceMode.Impulse);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 3f;
    public float jumpHeight = 5f;
    public Rigidbody rigidbody;

    void Start() {
        rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(x, 0, z);

        transform.Translate(movement * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump")) {
            rigidbody.AddForce(new Vector3(0, jumpHeight, 0), ForceMode.Impulse);
        }

    }
}

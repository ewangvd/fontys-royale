using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sr_jumping : MonoBehaviour
{
    Rigidbody player;
    private float jumpForce = 5f;
    private bool onGround;

    void Start()
    {
        player = GetComponent<Rigidbody>();
        onGround = true;
    }

    void Update()
    {
        if (Input.GetButton("Jump") && onGround == true)
        {
            player.velocity = new Vector3(0f, jumpForce, 0f);
            onGround = false;
        }
    }


    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            onGround = true;
        }
    }
}

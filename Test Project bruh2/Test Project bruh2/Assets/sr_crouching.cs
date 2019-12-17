using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sr_crouching : MonoBehaviour
{
    public float crouchSpeed;
    public float sprintSpeed;
    public float moveSpeed;

    private bool isCrouched = false;
    
    void Start()
    {
        GameObject playerRevived = GameObject.Find("playerRevived");
        sr_movement move = playerRevived.GetComponent<sr_movement>();
        move.speed = moveSpeed;
    }

    void Update()
    {           
        Crouch();
        
    }

    void Crouch()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            moveSpeed = crouchSpeed;
            isCrouched = true;
            transform.localScale = new Vector3(1, 0.5f, 1);
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift) && isCrouched == true)
        {
            moveSpeed = 0.1f;
            isCrouched = false;
            transform.localScale = new Vector3(1, 1, 1);
            
        }

    }


}

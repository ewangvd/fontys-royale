using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sr_look : MonoBehaviour
{
    public float sensitivity;
    public GameObject player;

    //ML is current rotation of the mouse
    private Vector2 ML;

    private void Start()
    {
        //locks cursor in the middle of the screen for playing
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Update()
    {
        //CL is how much the rotation changes
        Vector2 CL = new Vector2(Input.GetAxisRaw("Mouse X") * sensitivity, Input.GetAxisRaw("Mouse Y") * sensitivity);

        //the current rotation is added to the changed to move the mouse
        ML += CL;

        ML.y = Mathf.Clamp(ML.y, -90, 90);

        transform.localRotation = Quaternion.AngleAxis(-ML.y, Vector3.right);
        player.transform.localRotation = Quaternion.AngleAxis(ML.x, player.transform.up);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
}

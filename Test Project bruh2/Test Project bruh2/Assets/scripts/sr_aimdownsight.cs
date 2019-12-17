using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sr_aimdownsight : MonoBehaviour
{
    public Camera Hip;
    public Camera Aim;

    public Canvas crosshair;

    private bool crosshairOn = true;

    void Start()
    {
        Hip.enabled = true;
        Aim.enabled = false;
        
    }

    void Update()
    {
        AimDownSight();
    }

    void AimDownSight()
    {
        if (Input.GetMouseButtonUp(1))
        {
            Hip.enabled = !Hip.enabled;
            Aim.enabled = !Aim.enabled;

            if (crosshairOn == true)
            {
                DisableCanvas();
                crosshairOn = false;
            }
            else
            {
                EnableCanvas();
                crosshairOn = true;
            }
        }
    }

    void DisableCanvas()
    {
        crosshair.GetComponent<Canvas>().enabled = false;
    }

    void EnableCanvas()
    {
        crosshair.GetComponent<Canvas>().enabled = true;
    }



   
}


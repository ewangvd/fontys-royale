using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sr_throw : MonoBehaviour
{
    public GameObject grenadePrefab;
    public float throwForce = 10f;
  
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.G))
        {
            throwgrenade();
        }
    }

    void throwgrenade()
    {
        GameObject gren = Instantiate(grenadePrefab, transform.position, transform.rotation) as GameObject;
        gren.GetComponent<Rigidbody>().AddForce(transform.forward * throwForce, ForceMode.Impulse);
    }
}

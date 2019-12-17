using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sr_grenade : MonoBehaviour
{
    public float grenadeDelay = 3f;
    public GameObject explosionEffect;

    float countdown;

    bool exploded = false;

    void Start()
    {
        countdown = grenadeDelay;
    }

   
    void Update()
    {
        countdown -= Time.deltaTime;
        if (countdown <= 0f && !exploded)
        {
            Explode();
            exploded = true;
        }
    }

    void Explode()
    {
        Instantiate(explosionEffect, transform.position, transform.rotation);

        Destroy(gameObject);
    }
}

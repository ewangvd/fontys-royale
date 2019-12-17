using UnityEngine;
using System.Collections;

public class sr_shooting : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public float impactForce;

    public Camera fpsCam;

    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;
    public GameObject bulletHole;


    public int maxAmmo = 10;
    private int currentAmmo;


    public float reloadTime = 1f;
    private bool isReloading = false;

    void Start()
    {
        currentAmmo = maxAmmo;
    }

    void Update()
    {
        if (isReloading)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(doReload());
            return;
        }

        if(currentAmmo <= 0)
        {
            StartCoroutine(doReload());
            return;
        }

        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    IEnumerator doReload ()
    {
        isReloading = true;
        Debug.Log("reloading");

        yield return new WaitForSeconds(reloadTime);

        currentAmmo = maxAmmo;
        Debug.Log("reload complete");
        isReloading = false;
    }

    void Shoot()
    {
        muzzleFlash.Play();

        currentAmmo--;

        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            target Target = hit.transform.GetComponent<target>();

            if (Target != null)
            {
                Target.TakeDamage(damage);
            }

            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }

            GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 1f);

            GameObject bulletGO = Instantiate(bulletHole, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(bulletGO, 10f);
        }
    }
}
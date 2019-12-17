using UnityEngine;
using System.Collections;

public class sr_recoil : MonoBehaviour
{
    public float recoilTime;
    public Vector3 beginRecoil;
    public Vector3 endRecoil;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            StartCoroutine(WaitAndMove(recoilTime));
        }
    }

    IEnumerator WaitAndMove(float delayTime)
    {
        yield return new WaitForSeconds(delayTime); 
        float startTime = Time.time;
        while (Time.time - startTime <= 1)
        { 
            transform.position = Vector3.Lerp(beginRecoil, endRecoil, Time.time - startTime); 
            yield return 1; 
        }
    }
}

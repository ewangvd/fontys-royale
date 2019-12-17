using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class sr_movement : MonoBehaviour
    {
        public float speed;

        private void FixedUpdate()
        {
            float ws = Input.GetAxis("Vertical") * speed;
            float ad = Input.GetAxis("Horizontal") * speed;

            transform.Translate(ad, 0, ws);
        }
    }


using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace UOGame
{
    public class BulletDisable : MonoBehaviour
    {
        private void OnEnable()
        {
            InvokeRepeating("DisableBullet",5,0);
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Untagged")) {
                DisableBullet();
            }
        }
        void DisableBullet()
        {
            gameObject.SetActive(false);
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace UOGame
{
    public class BulletCollision : MonoBehaviour
    {
        [SerializeField] private BulletPoolManager _bulletPoolManager;
        private int bulletLifetime;
        private void Awake()
        {
            if (!_bulletPoolManager)
            {
                _bulletPoolManager = GetComponentInParent<BulletPoolManager>();
            }
            
            bulletLifetime = _bulletPoolManager.GetBulletLifetime();
        }

        //If bullet collide
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Env"))
            {
                HitEnvironment();
            }
            else if (collision.gameObject.CompareTag("Enemy"))
            {
                HitEnemy();
            }
            else if (collision.gameObject.CompareTag("Friend"))
            {
                HitFriend();
            }
            else if(collision.gameObject.CompareTag("Player"))
            {
                HitPlayer();
            }
        }
        
        //If bullet no collide we disable after X time
        private void OnEnable()
        {
            InvokeRepeating("NoHit",bulletLifetime,0);
        }

        void HitEnvironment()
        {
            gameObject.SetActive(false);
            //TODO
            //vfx YOU DAMAGE THE ENV
            
        }

        void HitEnemy()
        {
            gameObject.SetActive(false);
            //TODO
            // VFX hurt enemy
            //- 5 HP
        }

        void HitFriend()
        {
            gameObject.SetActive(false);
            //TODO
            //VFX hurt friend
            //-5 reputation points
        }

        void HitPlayer()
        {
            gameObject.SetActive(false);
            //TODO
            //VFX you hurt yourself
            // -5 HP
        }

        void NoHit()
        {
            gameObject.SetActive(false);
            //TODO
            //VFX the bullet are vanish
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace UOGame
{
    public class BulletBehaviour : MonoBehaviour
    {
        [SerializeField] private float speed = 5f;

        [SerializeField] private GameObject offset;

        [SerializeField] private GameObject bulletPrefab;

        [SerializeField] private List<GameObject> bullets;

        [SerializeField] private bool isShooted;
        // Start is called before the first frame update
        void Awake()
        {
            if (bullets.Count == 0)
            {
                bullets = new List<GameObject>(GameObject.FindGameObjectsWithTag("Bullet"));   
                HideAllBullets();
                
                Debug.Log("La lista estaba vacia pero ya te la llene");
            }
            else
            {
                HideAllBullets();
                
                Debug.Log("La lista ya estaba llena bro");
            }
        }

        void HideAllBullets()
        {
            foreach (var bullet in bullets)
            {
                bullet.SetActive(false);
            }
        }
        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                ShootBullet();
            }
        }

        void ShootBullet()
        {
            isShooted = false;

            if (!isShooted)
            {
                //recorremos la lista de balas
                foreach (var bullet in bullets)
                {
                    // si una bala esta inactiva, la utiliza para activarla
                    if (bullet.activeSelf == false)
                    {
                        EnableBullet(bullet);
                        break;
                    }
                }
            }

            if (!isShooted)
            {
                CreateBullet();
            }
            
        }

        void EnableBullet(GameObject bullet)
        {
            bullet.SetActive(true);
            bullet.transform.position = offset.transform.position;
            bullet.GetComponent<Rigidbody>().velocity = offset.transform.forward * speed;
            isShooted = true;
        }

        void CreateBullet()
        {
            GameObject newBullet = Instantiate(bulletPrefab, GameObject.FindGameObjectWithTag("BulletPool").transform);
            EnableBullet(newBullet);
            
            bullets.Add(newBullet);
        }
        void DisableBulletCollision()
        {
            
        }

        void DisableBulletTime()
        {
            
        }
    }
}

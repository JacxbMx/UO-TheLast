using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UOGame
{
    public class BulletPoolManager : MonoBehaviour
    {
        [SerializeField] private float speed = 5f;
        [SerializeField] private int bulletLifetime = 5;
        [SerializeField] private GameObject offset;
        [SerializeField] private GameObject bulletPrefab;
        [SerializeField] private List<GameObject> bullets;
        private bool _isShooted;

        void Awake()
        {
            if (bullets.Count == 0) {
                bullets = new List<GameObject>(GameObject.FindGameObjectsWithTag("Bullet"));   
                HideAllBullets();
                
                Debug.Log("La lista estaba vacia pero ya te la llene");
            }else {
                HideAllBullets();
                
                Debug.Log("La lista ya estaba llena bro");
            }
        }
        
         void Update()
         {
             if (Input.GetMouseButtonDown(0)) {
                 ShootBullet();
             }
         }
         
         void BulletPhysics(GameObject bullet)
         {
             bullet.transform.position = offset.transform.position;
             bullet.GetComponent<Rigidbody>().velocity = offset.transform.forward * speed;
         }
         
         void CreateBullet()
         {
             GameObject newBullet = Instantiate(bulletPrefab, GameObject.FindGameObjectWithTag("BulletPool").transform);
             EnableBullet(newBullet);
             bullets.Add(newBullet);
         }
            
         void EnableBullet(GameObject bullet)
         {
             bullet.SetActive(true);
             BulletPhysics(bullet);
             _isShooted = true;
         }

         public int GetBulletLifetime()
         {
             return bulletLifetime;
         }
         void HideAllBullets()
         {
             foreach (var bullet in bullets) bullet.SetActive(false);
         }
         
         void ShootBullet()
         {
             _isShooted = false;
             
             if (!_isShooted) {
                 foreach (var bullet in bullets) {
                     if (bullet.activeSelf == false) {
                         EnableBullet(bullet);
                         break;
                     }
                 }
             }
             if (!_isShooted) CreateBullet();
         }
    }
    
}

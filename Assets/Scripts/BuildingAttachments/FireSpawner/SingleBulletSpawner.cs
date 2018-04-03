using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleBulletSpawner : MonoBehaviour {

    [Header("Bullet Prefab and Properties")]
    public GameObject bulletPrefab;

    [SerializeField]
    int numberOfBulletsSpawn = 5;
    [SerializeField]
    float rateOfFire;
    [SerializeField]
    float angleOfSpead = -5.0f;

    [SerializeField]
    bool shouldFire = false;

    private void Start()
    {
        if (bulletPrefab == null)
            Debug.LogError("Bullet Prefab is not assigned");
        
        InvokeRepeating("Fire", 1.0f,1/rateOfFire);
    }

    void Fire()
    {

        if (shouldFire)
        {
            if (numberOfBulletsSpawn == 1)
            {
                GameObject g0 = Instantiate(bulletPrefab, transform.position, transform.rotation);
                g0.GetComponent<B_SingleBullet>().Initialize();
                g0.GetComponent<B_SingleBullet>().direction = this.transform.forward;
            }
            else
            {
                float initialAngle = angleOfSpead * Mathf.RoundToInt(numberOfBulletsSpawn / 2);
                for(int index = 0; index < numberOfBulletsSpawn; index++)
                {
                    GameObject g1 = Instantiate(bulletPrefab,
                                                transform.position,
                                                Quaternion.Euler(new Vector3(transform.rotation.x,
                                                                             transform.rotation.y - initialAngle,
                                                                             transform.rotation.z)));
                    g1.GetComponent<B_SingleBullet>().Initialize();
                    g1.GetComponent<B_SingleBullet>().direction = Quaternion.Euler(new Vector3(0, initialAngle, 0)) * this.transform.forward;
                    initialAngle += Mathf.Abs(angleOfSpead); 
                }
            }
        }
    }
    
}

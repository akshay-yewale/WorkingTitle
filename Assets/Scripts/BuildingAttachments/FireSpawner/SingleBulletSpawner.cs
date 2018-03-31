using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleBulletSpawner : MonoBehaviour {

    [Header("Bullet Prefab and Properties")]
    public GameObject bulletPrefab;
    [SerializeField]
    float rateOfFire = 1.0f;
    

    [SerializeField]
    bool shouldFire = false;

    private void Start()
    {
        if (bulletPrefab == null)
            Debug.LogError("Bullet Prefab is not assigned");
        
        InvokeRepeating("Fire", 1.0f,rateOfFire);
    }

    void Fire()
    {

        if (shouldFire)
        {
            GameObject g0 = Instantiate(bulletPrefab, transform.position, transform.rotation);
            g0.GetComponent<B_SingleBullet>().Initialize();
            g0.GetComponent<B_SingleBullet>().direction = this.transform.forward;
            //g0.GetComponent<B_SingleBullet>().SetForward(this.transform.forward);
        }
    }
    
}

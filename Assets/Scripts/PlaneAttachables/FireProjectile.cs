using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireProjectile : MonoBehaviour {

    [Header("Bullet Projectile Properties")]
    public GameObject BulletPrefab;
    [SerializeField]
    private float rateOfFire = 0.5f;
	// Use this for initialization
	void Start () {
        InvokeRepeating("Fire", 2.0f, rateOfFire);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Fire()
    {
        GameObject _bullet = Instantiate(BulletPrefab, this.transform.position, Quaternion.identity);
    }

}

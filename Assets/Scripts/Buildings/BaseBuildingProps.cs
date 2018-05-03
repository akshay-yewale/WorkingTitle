using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBuildingProps : MonoBehaviour {


    float baseHealth = 10.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag  == "PlaneBullet")
        {
            Debug.Log("Damage Inflicted");
            float damage = collision.gameObject.GetComponent<BulletProperties>().damageToInflicted;
            baseHealth -= damage;
        }
        if(baseHealth <=0)
        {
            Destroy(this.gameObject);
        }
    }
}

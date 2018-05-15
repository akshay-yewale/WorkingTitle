using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Inside OnTriggerEnter");
        if (other.gameObject.CompareTag("SingleBulletPrefab"))
        {
            other.gameObject.SetActive(false);
        }
    }
}

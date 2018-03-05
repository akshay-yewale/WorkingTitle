using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletProperties : MonoBehaviour {

    
    float speed = 10.0f; 
	// Use this for initialization
	void Start () {
        Invoke("Destroy", 3.0f);
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(this.transform.forward.normalized * Time.deltaTime * speed );
	}

    private void Destroy()
    {
        Destroy(this.gameObject);
    }
}

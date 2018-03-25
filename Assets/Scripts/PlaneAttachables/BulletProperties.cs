using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletProperties : MonoBehaviour {

    
    float speed = 10.0f;
	// Use this for initialization
	void Start () {
        
	}

    public void Initialized(Transform parent, float i_speed)
    {
        Invoke("Destroy", 6.0f);
       // this.transform.forward = parent.up;
        speed = i_speed;

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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneInputController : MonoBehaviour {

    float speed = 5f;
    float forwardspeed = 0.4f;

	// Use this for initialization
	void Start () {
        this.transform.position = new Vector3(1.0f, 2.25f, 10.0f);
    }

    // Update is called once per frame
    void FixedUpdate () {
        float translationZ = Input.GetAxis("Horizontal") * speed * -1 * Time.deltaTime;
        float translationX = Input.GetAxis("Vertical") * speed * 10.0f * -1 * Time.deltaTime;

        transform.Translate((forwardspeed - translationX) * Time.deltaTime, 0, translationZ);
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

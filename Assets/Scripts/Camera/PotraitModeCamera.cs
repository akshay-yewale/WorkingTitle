using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotraitModeCamera : MonoBehaviour {

    [SerializeField] bool isPotraitMode = true;
	// Use this for initialization
	void Start () {
		if(isPotraitMode)
        {
            float width = Screen.width;
            float heigth = Screen.height;
            int aspectRatio = Mathf.RoundToInt((width / heigth * 100.0f) / 100.0f);
            gameObject.GetComponent<Camera>().aspect = aspectRatio;
        }
	}
	
    public void SetupCamera(Vector3 position)
    {
        gameObject.GetComponent<Camera>().transform.position = position;
    }

}

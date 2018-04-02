using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterfaceManager : MonoBehaviour {
    public  bool isUIHovered = false;
    private static InterfaceManager _instance = null;

    private void Awake()
    {
        if (_instance == null)
            _instance = this;
        if (this != _instance)
            Destroy(this.gameObject);
    }

    public static InterfaceManager Instance
    {
        get
        { 
            if (_instance == null)
            {
            Debug.Log("InterfaceManger.cs InterfaceManager is null");
            }
            return _instance;
        }
    }

	// Use this for initialization
	void Start () {
       
	}

    // thiease are used to set the UI is begin selected at this point
    public void UIHovered()
    {
        isUIHovered = true;
    }

    public void UIHoveredExit()
    {
        isUIHovered = false;
    }
}

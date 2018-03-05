using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterfaceManager : MonoBehaviour {

    //access logger
    private static ILogger logger = Debug.unityLogger;
    private Logger DebugLogger;

    // This class is Singleton Pattern. Reason: We should give reference of this class to any other script. 
    //There can be only one object in the scene. So Singleton makes sense. 

    //Singleton structure. 
    private void Awake()
    {
        DebugLogger = new Logger();

        if (_instance == null)
            _instance = this;
        if (this != _instance)
            Destroy(this.gameObject);

        logger.Log("InterfaceManager is Initialized");
    }

    private static InterfaceManager _instance = null;

    public static InterfaceManager Instance()
    {
        if (_instance == null)
        {
            logger.Log("InterfaceManger.cs InterfaceManager is null");
        }
        return _instance;
    }

	// Use this for initialization
	void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

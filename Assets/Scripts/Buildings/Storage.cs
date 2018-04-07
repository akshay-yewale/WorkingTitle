using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Storage : MonoBehaviour {

    private enum StorageType
    {
        Fuel,
        Metal
    }

    [SerializeField]
    private GameObject cube;
    public Material mat;
    [SerializeField]
    StorageType collectorType;
    [SerializeField]
    int storageCapacity;
    int resouceStored = 0;
    [SerializeField]
    bool isStorageEnabled = false;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

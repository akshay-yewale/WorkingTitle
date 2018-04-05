using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    private enum CollectorType
    {
        Fuel,
        Metal
    }

    [SerializeField]
    private GameObject cube;
    public Material mat;
    [SerializeField]
    CollectorType collectorType;
    [SerializeField]
    int generationRate;
    [SerializeField]
    int storageCapacity;
    int fuelStored = 0;
    [SerializeField]
    bool isCollectionEnabled = false;


    #region SETTERS&GETTERS
    public int GenerationRate
    {
        get
        {
            return generationRate;
        }

        set
        {
            generationRate = value;
        }
    }

    public int StorageCapacity
    {
        get
        {
            return storageCapacity;
        }

        set
        {
            storageCapacity = value;
        }
    }

    public int FuelStored
    {
        get
        {
            return fuelStored;
        }

        set
        {
            fuelStored = value;
        }
    }

    public bool IsCollectionEnabled
    {
        get
        {
            return isCollectionEnabled;
        }

        set
        {
            isCollectionEnabled = value;
        }
    }
    #endregion

    public void Initialize()
    {

    }

    // Use this for initialization
    void Start()
    {
        InvokeRepeating("Generate", 1.0f, GenerationRate);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Generate()
    {
        if (!IsCollectionEnabled && FuelStored < StorageCapacity)
        {
            FuelStored += 1;
        } else if (!IsCollectionEnabled && FuelStored == StorageCapacity)
        {
            cube.GetComponent<MeshRenderer>().material = mat;
        }
    }

    public void OnDestroy()
    {
        Destroy();
    }

    public void Destroy()
    {

    }
}

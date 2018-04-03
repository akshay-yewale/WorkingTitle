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
    CollectorType collectorType = CollectorType.Fuel;
    [SerializeField]
    float generationRate = 1.0f;
    [SerializeField]
    int storageCapacity = 10;
    [SerializeField]
    float fuelStored = 0;
    [SerializeField]
    bool isUpgrading = false;


    #region SETTERS&GETTERS
    public float GenerationRate
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

    public float FuelStored
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

    public bool IsUpgrading
    {
        get
        {
            return isUpgrading;
        }

        set
        {
            isUpgrading = value;
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
        if (IsUpgrading && FuelStored < StorageCapacity)
        {
            FuelStored += 1.0f;
        }
        else if (IsUpgrading && FuelStored >= StorageCapacity)
        {
            FuelStored = Mathf.Clamp(FuelStored, 0, StorageCapacity);
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

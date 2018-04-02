using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImportStructures : MonoBehaviour {

    [Header("Base Building Button Prefab")]
    public GameObject BuildingButton;

    List<BuildingData> BuildingList;
    
    List<>
    private void Awake()
    {
        if(_instance == null)
            _instance  = this;

        if (_instance != this)
            Destroy(this.gameObject);
    }

    private void Start()
    {
        Invoke("Initialize", 2.0f); ;
    }

    private static ImportStructures _instance = null;
    public static ImportStructures Instance
    {
        get
        {
            return _instance;
        }
    }

    public void Initialize()
    {
        Debug.Log("Import Structure Initialize");
        BuildingList = ResourceManager.Instance.BaseBuildingList;
        if (BuildingList == null)
            Debug.Log("ImportStructures Building Import failed");

        StimulatePanel();
    }

    void StimulatePanel()
    {
        for(int index = 0; index < BuildingList.Count; index++)
        {
            Debug.Log("ImportStructures Building");
            GameObject g0 = Instantiate(BuildingButton);
            g0.transform.SetParent(this.transform);
        }
    }


    public void Destroy()
    {
        
    }

    public void OnDestroy()
    {
        Destroy();
    }
}

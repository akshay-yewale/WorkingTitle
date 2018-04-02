using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImportStructures : MonoBehaviour {

    [Header("Base Building Button Prefab")]
    public GameObject BuildingButton;

    [Header("Horizantal Scroller")]
    [SerializeField]private GameObject horizantalScroller;

    List<BuildingData> BuildingList;
    int offset = 0;

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
            
            GameObject g0 = Instantiate(BuildingButton);
            string name = BuildingList[index].name;
            g0.GetComponent<Button>().onClick.AddListener(() => OnBuildingButtonClicked(name));
            g0.GetComponent<Image>().sprite = BuildingList[index].icon;
            g0.transform.SetParent(horizantalScroller.transform);
            //g0.transform.transform.position = new Vector3(0, 0, 0); 
            RectTransform rt = g0.GetComponent<RectTransform>();
            rt.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, index * 100 , rt.rect.width);
            rt.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Top, 2.0f , rt.rect.height);
            //rt.position = new Vector3(rt.position.x + (index * 100), -65.0f, rt.position.z);
            
        }
    }


    public void Something() { }

    public void OnBuildingButtonClicked(string name)
    {
        BuildingEditManager.Instance.OnBuildingSelected(name);
    }

    public void Destroy()
    {
        
    }

    public void OnDestroy()
    {
        Destroy();
    }
}

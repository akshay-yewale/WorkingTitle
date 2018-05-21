using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingEditManager : MonoBehaviour {

    private new Camera camera;
    private BaseGrid baseGrid;
    private ResourceManager resourceManager; 

    private bool isBuildingSelected = false;
    private Vector3 mousePosition;
    private Vector3 worldPosition;

    private GameObject cursorPointBuilding = null;
    private GameObject cursorPointSelectedBuilding = null;



    //Singleton Pattern
    private static BuildingEditManager _instance = null;
    private void Awake()
    {
        if (_instance == null)
            _instance = this;
        if (this != _instance)
            Destroy(this.gameObject);
    }
    public static BuildingEditManager Instance
    {
        get
        {
            if (_instance == null)
                Debug.LogError("BuildingEditManager.cs BuildingEditManager is not initialized");
            return _instance;
        }
    }
    // Use this for initialization
    void Start () {
        camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        baseGrid = BaseGrid.Instance;
        resourceManager = ResourceManager.Instance;
	}
	
	// Update is called once per frame
	void Update () {
        PlaceBuildingOnBase();

    }

    private void PlaceBuildingOnBase()
    {
        if (isBuildingSelected && !InterfaceManager.Instance.isUIHovered)
        {
            UpdateMousePosition();

            Node currentNode = baseGrid.NodeFromWorldPosition(mousePosition);

            worldPosition = currentNode.worldPosition;

            Debug.Log("currentNode  :" + currentNode.index +" " + worldPosition);
            if(cursorPointBuilding == null)
            {
                cursorPointBuilding = Instantiate(cursorPointSelectedBuilding, worldPosition, Quaternion.identity) as GameObject;
            }
            else
            {
                cursorPointBuilding.transform.position = worldPosition;
                if(Input.GetMouseButtonDown(0) && !InterfaceManager.Instance.isUIHovered && currentNode.IsEmpty())
                {
                    GameObject buildingPlaced = Instantiate(cursorPointSelectedBuilding, worldPosition, Quaternion.identity);
                    buildingPlaced.transform.SetParent(this.transform);
                    currentNode.SetIsEmpty(false);
                
                    RemoveCursorContents();
                }
            }
        }
    }

    void UpdateMousePosition()
    {

        //Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            mousePosition = hit.point;
          
        }

    }

    void RemoveCursorContents()
    {
        if (cursorPointBuilding != null)
        {
            Destroy(cursorPointBuilding.gameObject);
            cursorPointBuilding = null;
        }
        isBuildingSelected = false;
    }

    public void OnBuildingSelected(string buildingName)
    {
        if(cursorPointBuilding != null)
        {
            Destroy(cursorPointBuilding.gameObject);
            cursorPointBuilding = null;     
        }

        BuildingData selectedBuildingData = resourceManager.GetBuildingData(buildingName);
        cursorPointSelectedBuilding = selectedBuildingData.buildingPrefab;
        isBuildingSelected = true;
    }
}

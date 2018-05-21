using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceManager : MonoBehaviour
{
    public List<BuildingData> BaseBuildingList;
    
    private void Awake()
    {
       
        if (_instance == null)
            _instance = this;
        if (_instance != this)
            Destroy(this.gameObject);
    }

    private static ResourceManager _instance = null;
    public static ResourceManager Instance
    {
        get
        {
            return _instance;
        }
    }

    public BuildingData GetBuildingData(int ID)
    {
        BuildingData retVal = null;
        for(int index =0; index < BaseBuildingList.Count; index++)
        {
            if(BaseBuildingList[index].UniqueId == ID)
            {
                retVal = BaseBuildingList[index];
                break;
            }
        }
        return retVal;
    }

    public BuildingData GetBuildingData(string name)
    {
        BuildingData retVal = null;
        for (int index = 0; index < BaseBuildingList.Count; index++)
        {
            if (name.Equals(BaseBuildingList[index].name))
            {
                retVal = BaseBuildingList[index];
                break;
            }
        }
        return retVal;
    }
}

[System.Serializable]
public class BuildingData
{
    public string name;
    public int UniqueId;
    public GameObject buildingPrefab;
    public Sprite icon;
    public int BoundVertical;
    public int BoundHorizantal;
}

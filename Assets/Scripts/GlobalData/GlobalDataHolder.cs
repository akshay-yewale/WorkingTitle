using System.Collections;
using System.Collections.Generic;
using UnityEngine;

struct BaseBuildingVariables
{
    public int GridSizeX;
    public int GridSizeZ;
}

struct PlayerData
{
    int Level;
}

public class GlobalDataHolder : MonoBehaviour {

    [SerializeField]
    int GridSize__X;

    [SerializeField]
    int GridSize__Z;
    

    private static GlobalDataHolder _instance = null;
    public static GlobalDataHolder Instance
    {
        get
        {
            return _instance;
        }
    }



    BaseBuildingVariables baseBuildingVariables;

    public int[] GetBaseBuildingVariable()
    {
        int[] gridParameters = new int[2];
        gridParameters[0] = baseBuildingVariables.GridSizeX;
        gridParameters[1] = baseBuildingVariables.GridSizeZ;
        return gridParameters;
    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
            InitializeBaseBuildingData();
           
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    void InitializeBaseBuildingData()
    {
        baseBuildingVariables.GridSizeX = GridSize__X;
        baseBuildingVariables.GridSizeZ = GridSize__Z;
    }

    

}

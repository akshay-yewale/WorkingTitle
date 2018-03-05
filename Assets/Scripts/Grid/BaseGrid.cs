using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseGrid : MonoBehaviour {

    private Node[,] grid;
    int maxSizeX, maxSizeZ;

    [Header("Grid Node Properties")]
    public GameObject[] GridNodePrefab;
    public float offset;


    private static ILogger logger = Debug.unityLogger;
    private Logger DebugLogger;

    private void Start()
    {
        DebugLogger = new Logger("BaseLog.txt");
        GenerateGrid(5, 10);

    }

    public void GenerateGrid(int maxX, int maxZ)
    {
        maxSizeX = maxX;
        maxSizeZ = maxZ;

        grid = new Node[maxX, maxZ];

        Vector3 position = this.transform.position;
        float posY = this.transform.position.y;

        for(int index = 0 ; index < maxX; index++)
        {
            float posX = position.x + offset * index;
            for (int jndex = 0; jndex < maxZ; jndex++)
            {
                
                float posZ = position.z + offset * jndex;
                GameObject _node = Instantiate(GridNodePrefab[(index + jndex)%GridNodePrefab.Length], new Vector3(posX, posY, posZ),  Quaternion.identity)as GameObject;
                _node.transform.SetParent(this.transform);
            }
        }

        logger.Log("BaseGrid : Grid Generation Success");
    }

}

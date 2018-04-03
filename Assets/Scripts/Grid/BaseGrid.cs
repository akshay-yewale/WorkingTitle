using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseGrid : MonoBehaviour
{
    [Header("Grid Node Properties")]
    public GameObject[] GridNodePrefab;
    public float offset;
    public int maxSizeGridX;
    public int maxSizeGridZ;

    private Node[,] grid;
    private float subtractionToOffsetValue;
    private static ILogger logger = Debug.unityLogger;
    private Logger DebugLogger;
    private Vector3 startPoint;

    private static BaseGrid _instance = null;
    public static BaseGrid Instance
    {
        get
        {
            if (_instance == null)
                Debug.LogError("BaseGrid.cs BaseGrid is not initialized");
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance == null)
            _instance = this;

        if (_instance != this)
            Destroy(this.gameObject);
    }

    private void Start()
    {
        DebugLogger = new Logger("BaseLog.txt");

        startPoint = this.transform.position;
        subtractionToOffsetValue = offset / 2.0f;
        int[] _GridParameters = GlobalDataHolder.Instance.GetBaseBuildingVariable();
        maxSizeGridX = _GridParameters[0];
        maxSizeGridZ = _GridParameters[1];

        GenerateGrid(maxSizeGridX, maxSizeGridZ);

    }

    private void GenerateGrid(int maxX, int maxZ)
    {
        grid = new Node[maxZ, maxX];
        Vector3 position = this.transform.position;
        float posY = this.transform.position.y;

        for (int index = 0; index < maxZ; index++)
        {
            float posZ = position.z + offset * index;
            for (int jndex = 0; jndex < maxX; jndex++)
            {

                float posX = position.x + offset * jndex;
                GameObject _node = Instantiate(GridNodePrefab[(index + jndex) % GridNodePrefab.Length], new Vector3(posX, posY, posZ), Quaternion.identity) as GameObject;
                _node.transform.SetParent(this.transform);

                Node node = new Node();
                node.index = index * 100 + jndex;
                node.isEmpty = true;
                node.gridX = index;
                node.gridZ = jndex;
                node.worldPosition = new Vector3(posX, posY, posZ);
                grid[index, jndex] = node;
                
            }
        }
        logger.Log("BaseGrid : Grid Generation Success");

        CreateMouseCollision();

        Vector3 cameraPosition = new Vector3(maxX / 2, 7, maxZ / 2 - 1);
        GameObject.FindGameObjectWithTag("MainCamera").gameObject.GetComponent<PotraitModeCamera>().SetupCamera(cameraPosition);

    }

    void CreateMouseCollision()
    {
        GameObject go = new GameObject();
        go.name = "BoxColliderForInput";
        go.tag = "BoxColliderForInput";
        go.transform.SetParent(this.transform);
        go.AddComponent<BoxCollider>();
        go.GetComponent<BoxCollider>().size = new Vector3(maxSizeGridX * offset, 0.01f, maxSizeGridZ * offset);
        go.transform.position = new Vector3((maxSizeGridX * offset) / 2 + startPoint.x - subtractionToOffsetValue, 0, (maxSizeGridZ * offset) / 2 + startPoint.z - subtractionToOffsetValue);
    }

    public Node NodeFromWorldPosition(Vector3 worldPosition)
    {

        float worldX = worldPosition.x - startPoint.x;
        float worldZ = worldPosition.z - startPoint.z;

        worldX /= offset;
        worldZ /= offset;

        int x = Mathf.RoundToInt(worldX);
        int z = Mathf.RoundToInt(worldZ);


        if (x >= maxSizeGridX)
            x = maxSizeGridX - 1;
        else if (x < 0)
            x = 0;

        if (z >= maxSizeGridZ)
            z = maxSizeGridZ - 1;
        else if (z < 0)
            z = 0;

        return grid[z, x];
    }
}

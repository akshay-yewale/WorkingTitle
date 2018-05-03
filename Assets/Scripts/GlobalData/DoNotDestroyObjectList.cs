using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoNotDestroyObjectList : MonoBehaviour {

    private List<GameObject> dontDestroyList;

    private static DoNotDestroyObjectList _instance = null;
    public static DoNotDestroyObjectList GetInstance()
    {
        return _instance;
    }

    private void Awake()
    {
        if(_instance == null)
        {
            _instance = this;
        }
        if (_instance != this)
            Destroy(this.gameObject);
    }

    void Start () {
        dontDestroyList = new List<GameObject>();
        DontDestroyOnLoad(this.gameObject);
	}

	public void AddDonotDestroyGameObject(GameObject i_gameobject)
    {
        dontDestroyList.Add(i_gameobject);
    }

    public void DestroyAndRemove(GameObject i_gameObject)
    {
        dontDestroyList.Remove(i_gameObject);
        Destroy(i_gameObject);
    }
}

//The implementation is considered for 
// storing the gameobject and associated Csharp script attached
[System.Serializable]
public struct GameObjectComponentStruct
{
    public GameObject gameObject;
    public List<string>
}
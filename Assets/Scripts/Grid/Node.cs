using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour {

    public int index;
    public bool isEmpty;


    public int gridX, gridZ;
    public Vector3 worldPosition;




    public void SetIsEmpty(bool b) { isEmpty = b; }

    public bool IsEmpty(){ return isEmpty;  }

}

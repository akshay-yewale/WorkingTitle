using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public enum BuidlingType
{
    NULL,
    LONGRANGED,
    SHORTRANGED
};

[CreateAssetMenu(fileName = "Building", menuName = "Base/Building", order = 1)]
public class Building : ScriptableObject {
    public new string name;
    public int level;
    public BuidlingType type;
    public float health;
    //call this function in Monobehaviour OnValidateFunction
    void Validation()
    {
        
    }
}

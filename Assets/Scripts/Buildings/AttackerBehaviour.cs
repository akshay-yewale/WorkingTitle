using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerBehaviour : MonoBehaviour {

    private Core.Base_Structure base_Structure_Ref = null;

    [Header("Properties")]
    [SerializeField]
    private GameObject Bullet_Prefab;

    [Header("Properties")]
    [SerializeField]
    private float f_Damage_Per_Bullet;
    private bool b_IsAttacking;
    private float f_Attack_Speed;


    public bool IsAttacking{
        get { return b_IsAttacking; }
        set { b_IsAttacking = value; }
    }



    private void Start()
    {
        //Initialize();
    }


    private void Initialize(){
        base_Structure_Ref = GetComponent<Core.Base_Structure>();
        if (base_Structure_Ref== null){
            Debug.Log("Base Structure not attached to " + this.gameObject.name);
        }



    }

}

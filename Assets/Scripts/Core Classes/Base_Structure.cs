using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Core
{
    //all the base building will have this script attached.
    public class Base_Structure : MonoBehaviour {

        private float m_health;
        private Enum_BuildingType e_BuildingType;
        private int i_Level;

        public int Level
        {
            get { return i_Level; }
            set { i_Level = value; }
        }

        //return type: return the type of building as enum
        public Enum_BuildingType BuildingType
        {
            get { return e_BuildingType; }
        }

        //return : float current health
        public float Health
        {
            get { return m_health; }
        }

        //return type: boolean if building is standing
        public bool IsStanding() {
            if (m_health <= 0)
                return true;
            return false;
        }

        //Dealt Damage will reduce health
        //IP: float damage will be reduced from health
        //return type: boolean if building is standing
        public bool AddDamage(float damage){
            m_health -= damage;
            return IsStanding();
        }
    
        // run this test for data validation
        public void CustomUnitTest()
        {
            //Need to assign a logger 
            if (Health <= 0)
                Debug.Log(this.gameObject + ": Health <= 0");

            if(Level == 0 )
                Debug.Log(this.gameObject + ": Level is not setup");

            if(e_BuildingType == Enum_BuildingType.UNDEFINED)
                Debug.Log(this.gameObject + ": Building Type is not defined");
        }
    }
}// Core Namespace



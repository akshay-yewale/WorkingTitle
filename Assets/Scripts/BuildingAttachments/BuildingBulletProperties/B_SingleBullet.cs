using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B_SingleBullet : MonoBehaviour {

    bool isHoming = false;
    float lifeTime = 1.0f;
    float speed = 10.0f;


    public void Initialize(float i_lifeTime = 4.0f, float i_speed = 10.0f, bool i_isHoming = false)
    {
        lifeTime = i_lifeTime;
        speed = i_speed;
        i_isHoming = isHoming;

        Invoke("Destroy", lifeTime);
    }

    private void Update()
    {
        if(!isHoming)
            transform.Translate(this.transform.forward.normalized * Time.deltaTime * speed);
        else
        {
            Debug.LogAssertion("Homing feature for bullet is not implemented");
        }
    }

    private void Destroy()
    {
        Destroy(this.gameObject);
    }

}

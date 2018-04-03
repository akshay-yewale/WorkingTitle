using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour
{

    float rotationspeed = 0.1f;

    [SerializeField]
    bool shouldRotate = false;

    // Use this for initialization
    void Start()
    {
        InvokeRepeating("Rotate", 0.1f, rotationspeed);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {

    }

    void Rotate()
    {
        if (shouldRotate)
        {
            Quaternion originalRotation = transform.rotation;
            transform.rotation = originalRotation * Quaternion.AngleAxis(1, Vector3.up);
        }
    }
}

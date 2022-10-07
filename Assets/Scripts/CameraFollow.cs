using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("GameObject")] 
    // [SerializeField] private GameObject followObject;
    // [SerializeField] private GameObject camera;
    [SerializeField] private Transform target;

    [SerializeField] private Vector3 offset;
    

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = target.position + offset;
        
        // Camera Y postition Fixed
        if (transform.position.y <= -0.006176025f)
        {
            transform.position = new Vector3(transform.position.x, -0.006176025f, transform.position.z);
        }
    }
}

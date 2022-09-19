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
    void Update()
    {
        transform.position = target.position + offset;
    }
}

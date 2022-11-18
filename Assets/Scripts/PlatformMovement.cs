using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    [SerializeField] private float platformSpeed;
    public Transform[] points;
    private int i;
    private Rigidbody MoveplatformRB;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, points[i].position) < 0.02f)
        {
            i++;
            if (i == points.Length)
            {
                i = 0;
            }
        }
        //transform.Translate(new Vector3(1, 0, 0) * Time.deltaTime);
        //MoveplatformRB.MovePosition(MoveplatformRB.position + new Vector3(1, 0, 0) * Time.);
        transform.position = Vector2.MoveTowards(transform.position, points[i].position, platformSpeed * Time.deltaTime);
    }
}


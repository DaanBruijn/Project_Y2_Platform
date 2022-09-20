using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//im gonna do it anyway delete it if you want
public class PaperTurn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("a"))
        {
            Vector3 charecterScale = transform.localScale;

            while (charecterScale.x > -1)
            {
                charecterScale.x -= 0.0000000000001f;
            }
            
            transform.localScale = charecterScale;
        }

        if (Input.GetKeyDown("d"))
        {
            Vector3 charecterScale = transform.localScale;
            charecterScale.x = 1;
            transform.localScale = charecterScale;
        }
    }
}

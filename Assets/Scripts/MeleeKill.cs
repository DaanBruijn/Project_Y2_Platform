using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeKill : MonoBehaviour
{
    [SerializeField]private GameObject player;
    [SerializeField]private Vector3 offset;
    [SerializeField]private bool canWallKick;
    [SerializeField]private float kickBounceBack;
    [SerializeField]private float kickBounceUp;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        offset = new Vector3(player.transform.localScale.x * 1.5f, 0, 0);
        transform.position = player.transform.position + offset;
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        Debug.Log("collision");
        Debug.LogWarning(other.gameObject.tag);
        if (other.gameObject.tag == "Enemy")
        {
            Debug.LogWarning("killed enemy :(" + other.gameObject.tag);
            //called when an enemy is hit by melee attack
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "Floor")
        {
            
            Debug.Log("kicked");
            //called when the player kicks the wall
            GameObject.Find("Player").GetComponent<PlayerMovement>().rb.AddForce(new Vector2(kickBounceBack * player.transform.localScale.x * -1, kickBounceUp), ForceMode2D.Impulse);
        }
    }
}

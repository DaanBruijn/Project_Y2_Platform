using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    //this script is set on the power up, not the player

    // 0 = invincibility
    // 1 = superjump
    // 2 = increased max Jumps
    // 3 = Projectile shooter
    
    [SerializeField]private int type;
    [SerializeField]private int time;
    //boost is only used for jump boost
    //boost adds a set amount of force to the jump power 
    [SerializeField]private float boost;
    [SerializeField]private bool respawns = false;
    private PlayerMovement playerMovement;
    private SoundManager soundManager;
    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GameObject.Find("Player").GetComponent<PlayerMovement>();
        soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // you can put: || other.gameObject.tag == "Good-Projectile" after "Player" to make projectiles able to collect power ups
        if (other.gameObject.tag == "Player")
        {
            if (respawns == true)
            {
                Invoke("Respawn", time);
            }

            soundManager.PlayGoodSound();
            if (type == 0)
            { 
                if (playerMovement.invincible == false)
                {
                        playerMovement.Invincibility(time);
                        gameObject.SetActive(false);
                }
            }

            if (type == 1)
            { 
                if (playerMovement.superJump == false )
                {
                    playerMovement.SuperJump(time, boost);
                    gameObject.SetActive(false);
                }
            }

            if (type == 2)
            { 
                if (playerMovement.extraJumps == false )
                {
                    playerMovement.ExtraJumps(time, boost);
                    gameObject.SetActive(false);
                }
            }

            if (type == 3)
            { 
                if (playerMovement.projectileShooter == false ) 
                {
                    playerMovement.ProjectileShooter(time, boost);
                    gameObject.SetActive(false);
                }
            }
        }
    }

    private void Respawn()
    {
        gameObject.SetActive(true);
    }
}

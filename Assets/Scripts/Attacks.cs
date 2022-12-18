using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacks : MonoBehaviour
{
    public GameObject projectile;
    public GameObject attackHitBox;

    private PlayerMovement playerMovement;
    public float attackCooldownTime = 1;
    [SerializeField]private bool attackCooldown;
    [SerializeField] private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("l"))
        {
            Debug.Log("trying to kick");
            if (playerMovement.allowedMelee == true && attackCooldown == false && !playerMovement.leftWallSlide && !playerMovement.rightWallSlide && !playerMovement.isGroundPound)
            {   
                MeleeAttack();
            }
        }
        if (Input.GetKeyDown("j"))
        {
            if (playerMovement.projectileShooter == true && attackCooldown == false)
            {  
                ShootProjectile();
            }
        }

        
    }

    public void ShootProjectile()
    {
        //summons projectile at the current position, with the direction of the player
        Instantiate(projectile, transform.position + new Vector3(1 * gameObject.transform.localScale.x, 0, 0), Quaternion.identity, gameObject.transform);
        attackCooldown = true;
        Invoke("AttackCooldownEnd", attackCooldownTime);
    }

    public void MeleeAttack()
    {
        attackHitBox.SetActive(true);
        animator.SetBool("Attacking", true);
        Debug.Log("did a kick");
        attackCooldown = true;
        Invoke("MeleeEnd", 0.2f);
        Invoke("AttackCooldownEnd", attackCooldownTime);
    }

    void AttackCooldownEnd()
    {
        attackCooldown = false;
    }

    void MeleeEnd()
    {
        attackHitBox.SetActive(false);
        animator.SetBool("Attacking", false);
    }

}

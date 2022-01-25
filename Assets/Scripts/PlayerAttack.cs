using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{   
     [SerializeField] private Animator animator;
     [SerializeField] private float attackCooldown;
     private float cooldownTimer = Mathf.Infinity;
     private PlayerMovement playerMovement;
    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)&& cooldownTimer > attackCooldown && playerMovement.canAttack())
            Attack();
        
        cooldownTimer += Time.deltaTime;
    }

    private void Attack(){
        animator.SetTrigger("attack");
        cooldownTimer = 0;
    }

    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Animator animator;

    [SerializeField] LayerMask groundLayer;
    [SerializeField] LayerMask trapLayer;
    Rigidbody2D body;
    BoxCollider2D boxCollider;

    bool isJumping = false;
    
    bool getInput = true;
    bool  isDying = false;
    float horizontalInput;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();    
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(getInput == true) {
            horizontalInput = Input.GetAxis("Horizontal");
        
        // moving the character
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

        // flip the character in the direction of walking
        if(horizontalInput > 0.01f){
            transform.localScale = new Vector3(-1, 1 , 1);
           
        }
        else{
            if(horizontalInput < -0.01f){
                 transform.localScale = Vector3.one;
            }
        }
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded())
            Jump();
        
        //set animator parameters
        animator.SetBool("run", horizontalInput != 0);
        animator.SetBool("grounded",isGrounded());

        if(Input.GetKeyDown(KeyCode.E)){
            CheckInteraction();
        }
        
            //animator.SetTrigger("die");
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void Jump(){
        if(isJumping == false){
        body.velocity = new Vector2(body.velocity.x, speed*4);
        animator.SetTrigger("jump");
        isJumping = true;
        Invoke("resetIsJumping",0.5f);
        }
    }

    private void resetIsJumping(){
        isJumping = false;
    }
    private bool isGrounded(){
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center,boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }

    public bool canAttack(){
        return isGrounded();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "Trap"&& isDying == false)
        {
            
            getInput = false;
            animator.SetTrigger("die");
            Invoke("Reload", 1.2f);
            isDying = true;
            body.velocity = Vector2.zero;
            
        }
        if (collision.gameObject.tag == "Character")
        {
            collision.gameObject.transform.GetComponent<Interactible>().Interact();
            print("collision");
        }
    }

    private void Reload(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    private void CheckInteraction(){
        RaycastHit2D[] raycastHits = Physics2D.BoxCastAll(transform.position,boxCollider.bounds.size, 0, Vector2.zero);
        if(raycastHits.Length > 0){
            foreach(RaycastHit2D rc in raycastHits){
                if(rc.transform.GetComponent<Interactible>()){
                    rc.transform.GetComponent<Interactible>().Interact();
                    return;
                }
            }
        }
    }
}

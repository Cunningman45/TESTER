using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    [SerializeField] private LayerMask groundLayer;
    private Rigidbody2D rb;
    //private bool isGrounded;
    private Animator anim;
    private BoxCollider2D boxCollider;

    void Start() {
        //Grab references for rigidbody and animator from object
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>(); 
        boxCollider = GetComponent<BoxCollider2D>();
    }//end Start

    void Update(){
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        //Flip player sprite when moving left or right
        if(moveInput > 0.01f)
            transform.localScale = Vector3.one;
        else if (moveInput < -0.01f)
            transform.localScale = new Vector3(-1, 1, 1);

        if (Input.GetKey(KeyCode.Space) && isGrounded()){
            Jump();
        }//end if

        //Set animation params
        anim.SetBool("Run", moveInput != 0);
        anim.SetBool("Grounded", isGrounded());
    }//end Update

    private void Jump(){
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        anim.SetTrigger("Jump");
    }//end Jump

    private void OnCollisionEnter2D(Collision2D collision){

    }//end OnCollisionEnter2D

    /*private void OnCollisionExit2D(Collision2D collision){
        if (collision.gameObject.CompareTag("Ground")){
            isGrounded = false;
        }
    }//end OnCollisionExit2D*/

    private bool isGrounded(){
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }//end isGrounded()

    private bool onWall() {
        return false;
    }//end onWall()
}//end class PlayerController
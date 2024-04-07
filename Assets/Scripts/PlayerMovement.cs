using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float movementX;
    private float movementSpeed = 8f;
    private SpriteRenderer spRender;
    private Animator anim;
    private Rigidbody2D myBody;
    private string Walk_Status = "Walk";
    private float jumpForce = 10f;
    private bool isGrounded;
    private bool jumpInput;

    void Awake(){
        spRender = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        myBody = GetComponent<Rigidbody2D>();

    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        movementX = Input.GetAxisRaw("Horizontal");
        playerMovement();
        playerAnimation();
        if(Input.GetButtonDown("Jump")){
            jumpInput = true;
        }
    }
    void FixedUpdate()
    {
        if(jumpInput){
        playerJump();
        jumpInput = false;
        }
        
    }

    void playerMovement(){
        transform.position = transform.position + new Vector3(movementX,0,0)*movementSpeed*Time.deltaTime;
    }

    void playerAnimation(){
        if(movementX < 0){
            anim.SetBool(Walk_Status,true);
            spRender.flipX = true;
        }
        else if(movementX > 0){
            anim.SetBool(Walk_Status,true);
            spRender.flipX = false;
        }
        else if(movementX == 0){
            anim.SetBool(Walk_Status,false);
            spRender.flipX = false;
        }
    }

    void playerJump(){
        if(isGrounded){
            isGrounded = false;
            myBody.AddForce(new Vector2(0f,jumpForce),ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.CompareTag("Ground")){
            isGrounded = true;
        }
    }
    
}

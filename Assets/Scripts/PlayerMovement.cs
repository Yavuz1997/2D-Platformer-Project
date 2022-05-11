using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D playerRb;
    private Animator playerAnim;
    private SpriteRenderer playerSprite;
    private BoxCollider2D playerCol;
    [SerializeField] private LayerMask jumpableGround;
    [SerializeField] private float runSpeed = 7f;
    [SerializeField] private float jumpForce = 15f;
    [SerializeField] private AudioSource jumpSF;
    private float dirX = 0f;
    private enum movementState { idle, running, jumping, falling };
    private void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerSprite = GetComponent<SpriteRenderer>();
        playerAnim = GetComponent<Animator>();
        playerCol = GetComponent<BoxCollider2D>();
    }
    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        playerRb.velocity = new Vector2(dirX * runSpeed, playerRb.velocity.y);
        if(Input.GetButtonDown("Jump") && (IsGrounded())){
            jumpSF.Play();
            playerRb.velocity = new Vector2(playerRb.velocity.x,jumpForce);
        }
        animationStateUpdate();
    }
    
    private void animationStateUpdate(){
        movementState state;
        if(dirX > 0f){
            state = movementState.running;
            playerSprite.flipX = false;
        }
        else if (dirX < 0f){
            state = movementState.running;
            playerSprite.flipX = true;
        }
        else{
            state = movementState.idle;
        }

        if(playerRb.velocity.y > .1f){
            state = movementState.jumping;
        }
        else if(playerRb.velocity.y < -.1f){
            state = movementState.falling;
        }

        playerAnim.SetInteger("state",(int)state);
    }

    private bool IsGrounded(){
        return Physics2D.BoxCast(playerCol.bounds.center, playerCol.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D playerRb;
    private Animator playerAnim;
    private SpriteRenderer playerSprite;
    [SerializeField] private float runSpeed = 7f;
    [SerializeField] private float jumpForce = 15f;
    private float dirX = 0f;
    // Start is called before the first frame update
    private void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerSprite = GetComponent<SpriteRenderer>();
        playerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        playerRb.velocity = new Vector2(dirX * runSpeed, playerRb.velocity.y);
        if(Input.GetButtonDown("Jump")){
            playerRb.velocity = new Vector2(playerRb.velocity.x,jumpForce);
        }
        animationStateUpdate();
    }
    
    private void animationStateUpdate(){
        if(dirX > 0f){
            playerAnim.SetBool("Running", true);
            playerSprite.flipX = false;
        }
        else if (dirX < 0f){
            playerAnim.SetBool("Running", true);
            playerSprite.flipX = true;
        }
        else{
            playerAnim.SetBool("Running", false);
        }
    }
}

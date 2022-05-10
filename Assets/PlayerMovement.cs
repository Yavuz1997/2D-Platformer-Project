using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D playerRb;
    // Start is called before the first frame update
    private void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        float dirX = Input.GetAxisRaw("Horizontal");
        playerRb.velocity = new Vector2(dirX * 10f, playerRb.velocity.y);
        if(Input.GetButtonDown("Jump")){
            playerRb.velocity = new Vector2(playerRb.velocity.x,15f);
        }
    }
    
}

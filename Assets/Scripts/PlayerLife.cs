using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collission) {
        if (collission.gameObject.CompareTag("Trap")){
            death();
        }
    }

    private void death(){
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death");
    }

    private void restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

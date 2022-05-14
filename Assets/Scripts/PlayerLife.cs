using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    [SerializeField] private AudioSource deathSF;
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
    private void OnTriggerEnter2D(Collider2D coll) {
        if (coll.gameObject.CompareTag("Trap")){
            death();
        }
    }
    private void OnTriggerStay2D(Collider2D coll) {
        if (coll.gameObject.CompareTag("Trap")){
            death();
        }
    }

    private void death(){
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death");
        deathSF.Play();
    }

    private void restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

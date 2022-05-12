using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Victory : MonoBehaviour
{
    [SerializeField] private AudioSource victorySF;
    private bool levelComp = false;
    public Animator transition;
    
    private void OnTriggerEnter2D(Collider2D coll) {
        if (coll.gameObject.name == "Player" && levelComp != true){
            levelComp = true;
            victorySF.Play();
            transition.SetTrigger("Start");
            Invoke("completeLevel",1f);
        }
    }
    private void completeLevel(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
}

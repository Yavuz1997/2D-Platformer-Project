using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Victory : MonoBehaviour
{
    [SerializeField] private AudioSource victorySF;
    
    private void OnTriggerEnter2D(Collider2D coll) {
        if (coll.gameObject.name == "Player"){
            victorySF.Play();
            completeLevel();
        }
    }
    private void completeLevel(){

    }
}

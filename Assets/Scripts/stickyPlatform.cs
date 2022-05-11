using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stickyPlatform : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D coll) {
       if(coll.gameObject.name == "Player"){
           coll.gameObject.transform.SetParent(transform);
       } 
    }
   private void OnCollisionExit2D(Collision2D coll) {
       if(coll.gameObject.name == "Player"){
           coll.gameObject.transform.SetParent(null);
       }
   }
}

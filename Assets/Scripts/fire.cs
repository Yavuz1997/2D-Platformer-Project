using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class fire : MonoBehaviour
{
    private Animator anim;
    [SerializeField] GameObject obj;

    private void Start()
    {
       anim = GetComponent<Animator>();
    }
    
    private void OnTriggerEnter2D(Collider2D coll) {
        if(coll.gameObject.name == "Player"){
            if(!anim.GetBool("isSteppedOn")){
                Invoke("fireAnim",1f);
            }
            else{
                fireAnim();
            }
            
        } 
    }
    private void fireAnim(){
        anim.SetBool("isSteppedOn",true);
        obj.tag = "Trap";
        Invoke("backToIdle",3f);
    }
    private void backToIdle(){
        obj.tag = "Untagged";
        anim.SetBool("isSteppedOn",false);
    }
}

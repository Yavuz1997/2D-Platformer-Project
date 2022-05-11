using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class itemCollector : MonoBehaviour
{
    [SerializeField] private AudioSource collectSF;
    private int bananas = 0;
    [SerializeField] private Text bananasText;
    private void OnTriggerEnter2D(Collider2D collission) {

        if(collission.gameObject.CompareTag("Banana")){
            collectSF.Play();
            Destroy(collission.gameObject);
            bananas++;
            bananasText.text = "Bananas: " + bananas;
        }
    }
}

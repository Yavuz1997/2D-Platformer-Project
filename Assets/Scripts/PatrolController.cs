using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolController : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    private int currIndex = 0;
    [SerializeField] private float speed = 2f;
    private void Update()
    {
        if(Vector2.Distance(waypoints[currIndex].transform.position,transform.position) < 0.1f){
            currIndex++;
            if(currIndex >= waypoints.Length){
                currIndex = 0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position,waypoints[currIndex].transform.position,Time.deltaTime * speed);
    }
}

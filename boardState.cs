using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boardState : MonoBehaviour
{
    float laserLength = 1f;
    // the layer we want to make the raycast at

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up, laserLength);
        if (hit.collider != null){
            // Debug.Log("Board is full");
            gameplay.cuttingBoard = "full";
        }
        else{
            // clear the board of salt and pepper and other stuff as well. 
            // Debug.Log("Board is empty");
            gameplay.cuttingBoard = "empty";
        }
    }
    // void OnTriggerEnter2D(Collider2D other){
    //     if (other.tag == "FOOD"){
    //         Debug.Log("Food detected");
    //         gameplay.cuttingBoard = "full";
    //     }
    // }
    // void OnTriggerExit2D(Collider2D other){
    //     gameplay.cuttingBoard = "empty";
    // }

}

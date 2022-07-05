using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grillState : MonoBehaviour
{
    float laserLength = 3f;
    // int layer = 1;
    // int food_layermask = 1 << layer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up, laserLength);
        // if ((hit.collider != null) && (hit.collider.tag == "FOOD")){
        //     Debug.Log("grill is full");
        //     gameplay.grill = "full";
        // }
        // else{
        //     // clear the board of salt and pepper and other stuff as well. 
        //     // Debug.Log("Board is empty");
        //     gameplay.grill = "empty";
        //     Debug.Log("grill is empty");
        // }
        if (hit.collider == null){
            gameplay.grill = "empty";
            // Debug.Log("grill is empty");
        }
    }

}

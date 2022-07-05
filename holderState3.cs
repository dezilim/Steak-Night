using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class holderState3 : MonoBehaviour
{
    // float laserLength = 0.1f;
    // the layer we want to make the raycast at

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    // void Update()
    // {
    //     RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up, laserLength);
    //     if (hit.collider == null){
    //         // clear the board of salt and pepper and other stuff as well. 
    //         // Debug.Log("Board is empty");
    //         gameplay.holder3 = "empty";
    //     }
    // }

     void OnEnterTrigger2D(){
        gameplay.holder3 = "full";
        Debug.Log("Holder3 is full");
    }
    
    void OnExitTrigger2D(){
        gameplay.holder3 = "empty";
        Debug.Log("Holder3 is empty");
    }
}

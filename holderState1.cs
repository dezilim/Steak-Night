using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class holderState1 : MonoBehaviour
{
    // float laserLength = 0.1f;
    // the layer we want to make the raycast at

    // Update is called once per frame
     void OnEnterTrigger2D(){
        gameplay.holder1 = "full";
        Debug.Log("Holder3 is full");
    }
    
    void OnExitTrigger2D(){
        gameplay.holder1 = "empty";
        Debug.Log("Holder3 is empty");
    }
}

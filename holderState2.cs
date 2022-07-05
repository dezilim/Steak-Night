using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class holderState2 : MonoBehaviour
{
    void OnEnterTrigger2D(){
        gameplay.holder2 = "full";
        Debug.Log("Holder2 is full");
    }
    
    void OnExitTrigger2D(){
        gameplay.holder2 = "empty";
        Debug.Log("Holder2 is empty");
    }
}

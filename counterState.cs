using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class counterState : MonoBehaviour
{
    float laserLength = 1f;
    public string servedFood;
    public float checkFoodTime = 0f;
    // Start is called before the first frame update


    void Update()
    {
        RaycastHit2D hitFood = Physics2D.Raycast(transform.position, Vector2.up, laserLength);
        if (hitFood.collider != null){
            // Debug.Log("Board is full");
            checkFoodTime += Time.deltaTime;
            if (checkFoodTime > 1f){
                servedFood = hitFood.collider.gameObject.tag;
                if ((servedFood == gameplay.order) && (hitFood.collider.gameObject.GetComponent<controller>().cookState == "yes")){
                    gameplay.frontOrderDone = "yes";
                    gameplay.score += 5;
                    Destroy(hitFood.collider.gameObject);
                    Debug.Log("servedFood");
                }
                
                gameplay.counter = "full";
            }
            if (checkFoodTime > 8f){
                gameplay.counter = "empty";
                Destroy(hitFood.collider.gameObject);
            }
            
            
        }
        else{
            // clear the board of salt and pepper and other stuff as well. 
            // Debug.Log("Board is empty");
            checkFoodTime = 0f;
            gameplay.counter = "empty";
        }
    }
    // void OnEnterTrigger2D(Collider2D food){
    //     Debug.Log("Helllllo");
    //     gameplay.counter = "full";
    //     servedFood = food.gameObject.tag;
    //     Debug.Log("servedFood:" + servedFood);
    //     if (servedFood == gameplay.order){
    //         gameplay.frontOrderDone = "yes";
    //     }
    //     Debug.Log("servedFood");
    //     Destroy(food.gameObject, 3f);
    // }
    
    // void OnExitTrigger2D(){
    //     gameplay.counter = "empty";
    //     Debug.Log("Counter is empty");
    // }
}

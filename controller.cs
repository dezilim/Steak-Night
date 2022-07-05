using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controller : MonoBehaviour
{
    private Vector3 _dragOffset;
    private Vector3 _initialPos;
    public static string isCooking; 
    public float cookingTime = 0f; 
    public string cookState; 
    // public float spawnTime = 0f;

    // public GameObject wrongRecipePopUp;
    

    public Sprite newBeef, newSalmon,  newFish, newPrawn, trash;
    public string gotSalt, gotPepper, gotThyme, gotOnion, gotButter;
    
    public string correctRecipe;

    void Start(){
        isCooking = "false";
        gotSalt = "no";
        gotPepper = "no";
        gotThyme = "no";
        gotOnion = "no";
        gotButter = "no";
        correctRecipe = "no";
        cookState = "no";
    }


    void OnMouseDown(){
        _dragOffset = transform.position - GetMousePos();
        _initialPos = GetMousePos() + _dragOffset/10;
    }
    // Start is called before the first frame update
    void OnMouseDrag()
    {
        transform.position = GetMousePos() + _dragOffset/10;
    }

    // we want to snap it to a new position if valid, otherwise, return to the prev position.
    void OnMouseUp()
    {
        // SNAPPING TO GRILL
        if ((gameplay.grill == "empty") &&(transform.position.x < gameplay.grill_RightBound  && transform.position.x > gameplay.grill_LeftBound) && (transform.position.y < gameplay.grill_TopBound  && transform.position.y > gameplay.grill_BotBound)){
            // we should check if an item is allowed to be cooked on the grill actually 

            //check the status of the sauces 
            // snap to grill no matter if correct recipe or nah
            transform.position = new Vector3(3.7f, -1.68f, 0f);
            gameplay.grill = "full"; 
            // BEEF1
            if (gameObject.name == "beef(Clone)"){
                Debug.Log("Beef to change");
                if ((gotSalt == "yes")  && (gotPepper == "yes") && (gotThyme == "yes")){
                    Debug.Log("Snapping to position");
                    // transform.position = new Vector3(3.7f, -1.68f, 0f);
                    // gameplay.grill = "full"; 
                    gameObject.tag = "beef1";
                    correctRecipe = "yes";
                }
                else {
                    Debug.Log("wrong recipe!");
                    correctRecipe = "no";
                    // transform.position = new Vector3(-2f,-1.8f,0f);
                    // gameplay.showWrongRecipe = "true";
                }
            }

            // SALMON 1 and SALMON 2
            else if (gameObject.name == "salmon(Clone)"){
                if ((gotSalt == "yes")  && (gotPepper == "yes") && (gotThyme == "yes")){
                    // transform.position = new Vector3(3.7f, -1.68f, 0f);
                    // gameplay.grill = "full"; 
                    gameObject.tag = "salmon1";
                    correctRecipe = "yes";
                }
                else if((gotButter == "yes")){
                    gameObject.tag = "salmon2";
                    correctRecipe = "yes";
                }
                
                else{
                    Debug.Log("wrong recipe!");
                    // transform.position = new Vector3(-2f,-1.8f,0f);
                    correctRecipe = "no";
                    // gameplay.showWrongRecipe = "true";
                }
            }

           


            // FISH STUFF
            else if (gameObject.name == "fish(Clone)"){
                if ((gotSalt == "yes")  && (gotPepper == "yes") && (gotOnion == "yes")){
                    // transform.position = new Vector3(3.7f, -1.68f, 0f);
                    // gameplay.grill = "full"; 
                    gameObject.tag = "fish1";
                    correctRecipe = "yes";
                }
                else {
                    Debug.Log("wrong recipe!");
                    // transform.position = new Vector3(-2f,-1.8f,0f);
                    correctRecipe = "no";
                    // gameplay.showWrongRecipe = "true";
                }
            }


            else if (gameObject.name == "prawn(Clone)"){
                if (gotButter == "yes"){
                    // transform.position = new Vector3(3.7f, -1.68f, 0f);
                    // gameplay.grill = "full";
                    gameObject.tag = "prawn1";
                    correctRecipe = "yes";
                }
                else {
                    Debug.Log("wrong recipe!");
                    // transform.position = new Vector3(-2f,-1.8f,0f);
                    correctRecipe = "no";
                    // gameplay.showWrongRecipe = "true";
                    // wrongRecipePopUp.GetComponent<Canvas>().enabled = true;
                }
            } 
            
        }

        // SNAP TO HOLDER (3 inventory spots)
        else if ((transform.position.x < gameplay.holder_RightBound  && transform.position.x > gameplay.holder_LeftBound) && (transform.position.y < gameplay.holder_TopBound  && transform.position.y > gameplay.holder_TopBound-1.1f)){
            if(gameplay.holder1 == "empty"){
                transform.position = gameplay.holderSpot1;
                gameplay.holder1 = "full";
            }
        }

        else if ((transform.position.x < gameplay.holder_RightBound  && transform.position.x > gameplay.holder_LeftBound) && (transform.position.y < gameplay.holder_TopBound -1.1f  && transform.position.y > gameplay.holder_TopBound-2.2f)){
            if(gameplay.holder2 == "empty"){
                transform.position = gameplay.holderSpot2;
                gameplay.holder2 = "full";
            }
        }
        else if ((transform.position.x < gameplay.holder_RightBound  && transform.position.x > gameplay.holder_LeftBound) && (transform.position.y < gameplay.holder_TopBound -2.2f  && transform.position.y > gameplay.holder_TopBound-3.4f)){
            if(gameplay.holder3 == "empty"){
                transform.position = gameplay.holderSpot3;
                gameplay.holder3 = "full";
            }
        }



            // else if(gameplay.holder2 == "empty"){
            //     transform.position = gameplay.holderSpot2;
            //     gameplay.holder2 = "full";
            // }
            // else if(gameplay.holder3 == "empty"){
            //     transform.position = gameplay.holderSpot3;
            //     gameplay.holder3 = "full";
            // }
            
            
            // transform.position = new Vector3(6.73f, -1.18f, 0f);
        
        //(gameplay.counter == "empty") &&
        // SNAP TO COUNTER
        // note: counter state only checks if alr got meat there or nah
        else if ( (transform.position.x < gameplay.counter_RightBound  && transform.position.x > gameplay.counter_LeftBound) && (transform.position.y < gameplay.counter_TopBound  && transform.position.y > gameplay.counter_BotBound)){
            transform.position = new Vector3(3.1f, 0.9f, 0f);
        }

        // SNAP TO BOARD
        else if ((gameplay.cuttingBoard == "empty") && (transform.position.x < gameplay.board_RightBound  && transform.position.x > gameplay.board_LeftBound) && (transform.position.y < gameplay.board_TopBound  && transform.position.y > gameplay.board_BotBound)){
            transform.position = new Vector3(-2f, -1.8f, 0f);
        }

        // DESTROY OBJECT IF AT DUSTBIN
        else if ( (transform.position.x < gameplay.dustbin_RightBound  && transform.position.x > gameplay.dustbin_RightBound-1.3f) && (transform.position.y < gameplay.dustbin_TopBound  && transform.position.y > gameplay.dustbin_TopBound-1f)){
            Destroy(gameObject);
        }

        // DESTROY OBJECT IF TOO LOW
        else if (transform.position.y < -4.81f){
            Destroy(gameObject);
        }

        
        // RETURN TO INITIAL POSITION
        else {
            // transform.position = new Vector3(-1.67f, -1.84f,0f);
            transform.position = _initialPos;
        }

    }

    // Update is called once per frame
    Vector3 GetMousePos(){
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        return mousePos;
    }
    



    void Update(){


        // check if this particular gameobject is on the grill and fire on 
        if ((transform.position.x < gameplay.grill_RightBound  && transform.position.x > gameplay.grill_LeftBound) && (transform.position.y < gameplay.grill_TopBound  && transform.position.y > gameplay.grill_BotBound) && (gameplay.fire == "on")){
            isCooking = "true";
            // Debug.Log("cooking now");
        }
        else {
            isCooking = "false";
            // Debug.Log("not cooking now");
        }
        Debug.Log(gameObject.name);
        // cook the food
        if(isCooking == "true"){
            cookingTime += Time.deltaTime;
            // Change sprite only if its correctrecipe, otherwise turn it into trash
            if((cookingTime > 4f) && (correctRecipe == "yes")){
                cookState = "yes";
                // GetComponent<SpriteRenderer>().color = new Color(0.8f,0.3f,0.1f);
                if (gameObject.name == "beef(Clone)"){
                    gameObject.GetComponent<SpriteRenderer>().sprite = newBeef;
                }
                else if (gameObject.name == "salmon(Clone)"){ 
                    gameObject.GetComponent<SpriteRenderer>().sprite = newSalmon;
                }
                else if (gameObject.name == "fish(Clone)"){
                    gameObject.GetComponent<SpriteRenderer>().sprite = newFish;
                }
                else if (gameObject.name == "prawn(Clone)"){
                    gameObject.GetComponent<SpriteRenderer>().sprite = newPrawn;
                }
                // Debug.Log("Sprite changed");
            }
            else if((cookingTime > 4f) && (correctRecipe == "no")){
                // switch sprite to trash
                gameObject.GetComponent<SpriteRenderer>().sprite = trash;
                cookState = "burnt";
            }

            if(cookingTime > 6f){
                Debug.Log("item burnt");
                cookState = "burnt";
                gameObject.GetComponent<SpriteRenderer>().sprite = trash;
            }
        }

        // destroy game object after too long 


    }
}

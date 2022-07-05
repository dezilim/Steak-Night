using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class gameplay : MonoBehaviour
{

    public AudioSource GameAudio;


    public static string cuttingBoard, grill, holder, counter, saltClicked, pepperClicked, butterClicked, onionClicked, thymeClicked;
    public static string fire; public GameObject fire_obj;
    public static float grill_LeftBound, grill_RightBound, grill_TopBound, grill_BotBound;
    public static float board_LeftBound, board_RightBound, board_TopBound, board_BotBound;
    public static float holder_LeftBound, holder_RightBound, holder_TopBound, holder_BotBound;
    public static float counter_LeftBound, counter_RightBound, counter_TopBound, counter_BotBound;
    public static float dustbin_RightBound, dustbin_TopBound;

    public static Vector3 holderSpot1, holderSpot2, holderSpot3;
    public int n_holders;
    public static string holder1, holder2, holder3;

    // CANVASES
    public static string showWrongRecipe;
    public GameObject endGameUI;



    public static float dragDropMargin = 0.2f;



    // active gameplay running shop 
    // ----------------------------
    // ----------------------------
    
    public static string shopOpen;
    public static float shopTime;
    public static int firstIte = 0;
    public static int score = 0;
    public static int nb_curr_customers = 0;
    public static int nb_max_customers = 4;

    public static int game_level = 0;

    public Text scoreText, timerText, order1Text, order2Text, order3Text; 

    // the frontorder is obtained by using a raycast at the position of the first customer. It is used together in counterState to check to destroy or nah
    // public int nb_customer_types = 2;
    public GameObject[] customersToSelect;
    public GameObject[] customersSelected = new GameObject[3];
    public GameObject customer;
    int prevIndex;

    public Vector3[] positionArray = new Vector3[3]; 
    // List<GameObject> = customerList;
    public static int index_selectCustomer, index_selectRecipe;
    public static string frontOrderDone, frontOrder;
    // for moving the customers 
    // public float speed;
    // public float movingTime = 0f;
    

    public string[] recipes = new string[] {"salmon1","salmon2", "beef1", "fish1", "prawn1" };
    public GameObject[] recipes_Sprites;
    public static string order;


    public GameObject box;


    float laserLength = 3f;
    RaycastHit[] hitRemainingCustomers;





    // keep track of which customer spaces are occupied 
    int[] spacesCustomers = { 0, 0, 0};
    // Start is called before the first frame update
    void Start()
    {

        Time.timeScale = 0;
        AudioListener.pause = true;
        shopOpen = "false";
        prevIndex = 50;

        customersToSelect = GameObject.FindGameObjectsWithTag("CUSTOMER");

        

        cuttingBoard = "empty";
        grill = "empty";
        counter = "empty";

        saltClicked = "no";
        pepperClicked = "no";
        butterClicked = "no";
        onionClicked = "no";
        thymeClicked = "no";

        // wrongRecipePopUp.GetComponent<Canvas>().enabled = true;

        fire_obj.GetComponent<SpriteRenderer>().enabled = false; 
        fire = "off";

        grill_LeftBound = 2.5f - dragDropMargin; 
        grill_RightBound = 5.1f + dragDropMargin; 
        grill_TopBound = -0.5f + dragDropMargin; 
        grill_BotBound = -3.7f - dragDropMargin;

        holder_LeftBound = 5.9f - dragDropMargin; 
        holder_RightBound = 7.71f + dragDropMargin; 
        holder_TopBound = -0.8f + dragDropMargin; 
        holder_BotBound = -4f - dragDropMargin;

        board_LeftBound = -3.86f - dragDropMargin; 
        board_RightBound = -0.13f + dragDropMargin; 
        board_TopBound = -1.2f + dragDropMargin; 
        board_BotBound = -2.82f - dragDropMargin;

        counter_LeftBound = 2f - dragDropMargin; 
        counter_RightBound = 5.66f + dragDropMargin; 
        counter_TopBound =  1.67f + dragDropMargin; 
        counter_BotBound = 0.59f - dragDropMargin;

        dustbin_RightBound =1.38f;
        dustbin_TopBound = 1.2f;

        n_holders = 3;
        holder1 = "empty"; holder2 = "empty"; holder3 = "empty";
        holderSpot1 = new Vector3(6.73f, -1.29f, 0f);
        holderSpot2 = new Vector3(6.73f, -2.12f, 0f);
        holderSpot3 = new Vector3(6.73f, -3.24f, 0f);


        showWrongRecipe = "false"; frontOrderDone = "no";

        positionArray[0] = new Vector3(-1.72f, 1.6f, 0f);
        positionArray[1] = new Vector3(-1.72f-2.8f, 1.6f, 0f);
        positionArray[2] = new Vector3(-1.72f-5.6f, 1.6f, 0f);
        // positionArray[3] = new Vector3(-4*1.72f, 0.67f, 0f);

        customersToSelect = GameObject.FindGameObjectsWithTag("CUSTOMER");
        Debug.Log("Length of list of customers"); 
        Debug.Log(customersToSelect.Length);

    }

    public void openShop() {
        
        shopOpen = "true";
        Time.timeScale = 1;
        AudioListener.pause = false;

        shopTime = 10f;
        score = 0;  
        // Time.timeScale = 1;
    }

    public void pauseTime(){
        Time.timeScale = 0;
        AudioListener.pause = true;
    }

    public void continueTime(){
        Time.timeScale = 1;
        AudioListener.pause = false;
    }

    public void incrementLevel(){
        game_level += 1;
    }

    // void moveCustomerSmooth(GameObject customerObj, Vector3 customerPosition){
    //     customerObj.transform.position =  Vector3.Lerp(customerPosition+ 2*Vector3.left, customerPosition, 0.3f);
    // }

    // Update is called once per frame
    void Update()
    {

        // float step = speed * Time.deltaTime;
        // allow for salt and pepper to be clkickable again
        if (cuttingBoard == "empty"){
            saltClicked = "no"; pepperClicked = "no";
            butterClicked = "no";
            onionClicked = "no";
            thymeClicked = "no";
        }




        // ACTIVE GAMEPLAY 
        if (shopOpen == "true"){
            

            timerText.text =shopTime.ToString("f1");
            scoreText.text = score.ToString();
            // instantiate customers for the first time once shop opens. 
            if(firstIte == 0){
                
                
                for(int i =  0; i < 3; i++){
                    do{
                        index_selectCustomer = Random.Range (0, customersToSelect.Length); 
                    }while (index_selectCustomer == prevIndex); 
                    // index_selectCustomer = Random.Range (0, customersToSelect.Length); 
                    prevIndex = index_selectCustomer;
                    index_selectRecipe = Random.Range (0, recipes.Length);
                    customer = customersToSelect[index_selectCustomer];
                    order = recipes[index_selectRecipe];

                    // var thisCustomer = Instantiate(customer, new Vector2(-1.72f - i*2.5f, 0.67f), customer.transform.rotation);
                    // var thisCustomer = Instantiate(customer, positionArray[i] + 2*Vector3.left, customer.transform.rotation);
                    var thisCustomer = Instantiate(customer, positionArray[i], customer.transform.rotation);
                    var thisBox = Instantiate(box, positionArray[i] + new Vector3(1f,1.2f,0f), box.transform.rotation);
                    var thisMenuItem = Instantiate(recipes_Sprites[index_selectRecipe], thisBox.transform.position+ 0.5f*Vector3.up, thisBox.transform.rotation);
                    thisBox.transform.parent = thisCustomer.transform;
                    thisMenuItem.transform.parent = thisCustomer.transform;
                    
                    // give as input the customer object and its final p osition. the function will move it by lerp. 
                    // while (timeElapsed < lerpDuration){
                           
                    // }
                    
                    thisCustomer.gameObject.tag = order;
                    customersSelected[i] = thisCustomer.gameObject;


                    
                }
                order1Text.text = customersSelected[0].tag;
                order2Text.text = customersSelected[1].tag;
                order3Text.text = customersSelected[2].tag;
                firstIte = 1;
            }

            RaycastHit2D hitCustomer = Physics2D.Raycast(transform.position, Vector2.up, laserLength);
            if (hitCustomer.collider != null){
                // get whats the current order. 
                order = hitCustomer.collider.gameObject.tag;
                Debug.Log(order);
                if (frontOrderDone == "yes"){
                //destroy the customer gameobject 
                    
                    Destroy(hitCustomer.collider.gameObject);
                
                }
            }

            // let's find out whats the front order 

            // if the first customer is gone, let's find all gameobjects here and move them in x position 
            if ((frontOrderDone == "yes")){
                // shift all customers to the right and instantiate a new customer
                Debug.Log("Do something lo");

                // movingTime += Time.deltaTime;
                for(int i = 1; i < 3; i++ ){
                    // customersSelected[i].transform.position = Vector3.MoveTowards(customersSelected[i].transform.position, positionArray[i-1],step);
                    customersSelected[i].transform.position = positionArray[i-1];
                    customersSelected[i-1] = customersSelected[i];
                }
                // instantiate a new customer and assign it to the end of the gameobject array of selected customers 

                do{
                    index_selectCustomer = Random.Range (0, customersToSelect.Length); 
                }while (index_selectCustomer == prevIndex); 
                    // index_selectCustomer = Random.Range (0, customersToSelect.Length); 
                prevIndex = index_selectCustomer;
                // index_selectCustomer = Random.Range (0, customersToSelect.Length);
                index_selectRecipe = Random.Range (0, recipes.Length);
                customer = customersToSelect[index_selectCustomer];
                order = recipes[index_selectRecipe];
                var thisCustomer = Instantiate(customer, positionArray[2], customer.transform.rotation);
                var thisBox = Instantiate(box, positionArray[2]+ new Vector3(1f,1.2f,0f), box.transform.rotation);
                var thisMenuItem = Instantiate(recipes_Sprites[index_selectRecipe], thisBox.transform.position+ 0.5f*Vector3.up, thisBox.transform.rotation);
                // make the box and menu item child of the customer so it follows 
                thisBox.transform.parent = thisCustomer.transform;
                thisMenuItem.transform.parent = thisCustomer.transform;



                thisCustomer.gameObject.tag = order;
                customersSelected[2] = thisCustomer.gameObject;
                // if(movingTime > 2f){
                //     
                // }
                // movingTime = 0f;

                order1Text.text = customersSelected[0].tag;
                order2Text.text = customersSelected[1].tag;
                order3Text.text = customersSelected[2].tag;
                
                frontOrderDone = "no";



                // move the second and third customers to the right

                // for(int i = 1; i < 3; i++ ){
                //     customersSelected[i].transform.position = positionArray[i-1];
                //     customersSelected[i-1] = customersSelected[i];
                // }
                // // instantiate a new customer and assign it to the end of the gameobject array of selected customers 
                // index_selectCustomer = Random.Range (0, customersToSelect.Length);
                // index_selectRecipe = Random.Range (0, recipes.Length);
                // customer = customersToSelect[index_selectCustomer];
                // order = recipes[index_selectRecipe];
                // var thisCustomer = Instantiate(customer, positionArray[2], customer.transform.rotation);
                // thisCustomer.gameObject.tag = order;
                // customersSelected[nb_max_customers-1] = thisCustomer.gameObject;



                // hitRemainingCustomers = Physics.RaycastAll(transform.position, Vector2.left, 10f);
                // Debug.DrawLine(transform.position,  Vector2.left, Color.white, 5f);
                // Debug.Log("Check customers");
                // Debug.Log(hitRemainingCustomers);
                // for (int cust = 0; cust < hitRemainingCustomers.Length; cust ++){
                //     RaycastHit hit = hitRemainingCustomers[cust];
                //     Debug.Log("Moving the customers");
                //     hit.transform.position  = hit.transform.position + new Vector3(1.72f, 0f,0f);
                // }



                // RAYCAST METHOD WORKS ALSO 
                // RaycastHit2D secondCustomer = Physics2D.Raycast(transform.position - new Vector3(1.72f, 0f,0f), Vector2.up, laserLength);
                // if (secondCustomer.collider != null){
                //     secondCustomer.transform.position = secondCustomer.transform.position + new Vector3(1.72f, 0f,0f);
                // }
                // RaycastHit2D thirdCustomer = Physics2D.Raycast(transform.position - new Vector3(2*1.72f, 0f,0f), Vector2.up, laserLength);
                // if (thirdCustomer.collider != null){
                //     thirdCustomer.transform.position = thirdCustomer.transform.position + new Vector3(1.72f, 0f,0f);
                // }
                
            }

            // if (nb_curr_customers < nb_max_customers){
            //     // spawn customer, location will depend on which customer it is 
            // }


            shopTime -= Time.deltaTime;

            if (shopTime < 0f){
                shopOpen = "false";
                Time.timeScale = 0; 
                AudioListener.pause = true;
                endGameUI.SetActive(true);


                // reset game variables... dk if it will be neccessary 
                
                
            }

        }
        


    }
}

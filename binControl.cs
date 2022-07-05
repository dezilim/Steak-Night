using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INSTANTIATES OBJECTS ONTO CUTTING BOARD, ASSIGNS SAUCES TO PARENTS
public class binControl : MonoBehaviour
{
    public Transform salmonObj, beefObj, fishObj, prawnObj, saltObj, pepperObj, butterObj, thymeObj, onionObj;
    public AudioSource thudSound, puffSound;
    float laserLength = 1f;
    

	//Get the first object hit by the ray
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnMouseDown()
    {
        // check which object is clicked on
        if ((gameObject.name == "salmonClicker" ) && (gameplay.cuttingBoard == "empty")) {
            Instantiate(salmonObj, new Vector2(-2f, -1.8f), salmonObj.rotation);
            // thudSound.Play();
            //gameplay.cuttingBoard = "full";
        }
        if ((gameObject.name == "fishClicker")&& (gameplay.cuttingBoard == "empty")){
            Instantiate(fishObj, new Vector2(-2f, -1.8f), fishObj.rotation);
            // thudSound.Play();
            //gameplay.cuttingBoard = "full";
        }
        if ((gameObject.name == "prawnClicker")&& (gameplay.cuttingBoard == "empty")){
            Instantiate(prawnObj, new Vector2(-2f, -1.8f), prawnObj.rotation);
            // thudSound.Play();
            //ameplay.cuttingBoard = "full";
        }
        if ((gameObject.name == "beefClicker")&& (gameplay.cuttingBoard == "empty")){
            Instantiate(beefObj, new Vector2(-2f, -1.8f), beefObj.rotation);
            // thudSound.Play();
            //gameplay.cuttingBoard = "full";
        }


        // SAUCES

        if ((gameObject.name == "saltClicker")&& (gameplay.saltClicked == "no")){
            RaycastHit2D hit = Physics2D.Raycast(new Vector3(-2f,-1.8f,0f), Vector2.up, laserLength);
            if (hit.collider != null){
                Debug.Log("Hitting: " + hit.collider.tag);
            }
            Instantiate(saltObj, new Vector2(-2f, -1.8f), saltObj.rotation, hit.transform);
            // puffSound.Play();
            // check which item it is on, and become a child of it. 
            gameplay.saltClicked = "yes";
            Debug.Log("Clicked salt");
            hit.transform.GetComponent<controller>().gotSalt = "yes";
        }
        if ((gameObject.name == "pepperClicker")&& (gameplay.pepperClicked == "no")){
            RaycastHit2D hit = Physics2D.Raycast(new Vector3(-2f,-1.8f,0f), Vector2.up, laserLength);
            if (hit.collider != null){
                Debug.Log("Hitting: " + hit.collider.tag);
            }
            Instantiate(pepperObj, new Vector2(-2f, -1.8f), pepperObj.rotation,hit.transform);
            // puffSound.Play();
            gameplay.pepperClicked = "yes";
            hit.transform.gameObject.GetComponent<controller>().gotPepper = "yes";
        }



        if ((gameObject.name == "butterClicker")&& (gameplay.butterClicked == "no")){
            RaycastHit2D hit = Physics2D.Raycast(new Vector3(-2f,-1.8f,0f), Vector2.up, laserLength);
            if (hit.collider != null){
                Debug.Log("Hitting: " + hit.collider.tag);
            }
            Instantiate(butterObj, new Vector2(-2f, -1.8f), butterObj.rotation, hit.transform);
            // puffSound.Play();
            // check which item it is on, and become a child of it. 
            gameplay.butterClicked = "yes";
            hit.transform.gameObject.GetComponent<controller>().gotButter = "yes";
        }
        if ((gameObject.name == "thymeClicker")&& (gameplay.thymeClicked == "no")){
            RaycastHit2D hit = Physics2D.Raycast(new Vector3(-2f,-1.8f,0f), Vector2.up, laserLength);
            if (hit.collider != null){
                Debug.Log("Hitting: " + hit.collider.tag);
            }
            Instantiate(thymeObj, new Vector2(-2f, -1.8f), thymeObj.rotation, hit.transform);
            // puffSound.Play();
            gameplay.thymeClicked = "yes";
            hit.transform.gameObject.GetComponent<controller>().gotThyme = "yes";
        }

        if ((gameObject.name == "onionClicker")&& (gameplay.onionClicked == "no")){
            RaycastHit2D hit = Physics2D.Raycast(new Vector3(-2f,-1.8f,0f), Vector2.up, laserLength);
            if (hit.collider != null){
                Debug.Log("Hitting: " + hit.collider.tag);
            }
            Instantiate(onionObj, new Vector2(-2f, -1.8f), onionObj.rotation, hit.transform);
            // puffSound.Play();
            gameplay.onionClicked = "yes";
            hit.transform.gameObject.GetComponent<controller>().gotOnion = "yes";
        }
    }
}

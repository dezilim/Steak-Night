using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class manage_wrongRecipe : MonoBehaviour
{
    public static float showTime;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Canvas>().enabled = false;
        showTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameplay.showWrongRecipe == "true"){
            gameObject.GetComponent<Canvas>().enabled = true;
        }
        // while(gameplay.showWrongRecipe == "true"){
        //     showTime += Time.deltaTime;
        //     if (showTime > 5f){
        //         gameObject.GetComponent<Canvas>().enabled = false;
        //         gameplay.showWrongRecipe = "false";
        //     }   
        // }
        
    } 
}

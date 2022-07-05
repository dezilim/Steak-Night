using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireController : MonoBehaviour
{
    public GameObject fire_obj;
    public AudioSource FireAudio;


    void OnMouseDown(){
        if(gameplay.fire == "off"){
            fire_obj.GetComponent<SpriteRenderer>().enabled = true;
            gameplay.fire = "on";
            FireAudio.Play();
        }
        else{
            fire_obj.GetComponent<SpriteRenderer>().enabled = false;
            gameplay.fire = "off";
            FireAudio.Stop();
        }
        
    }
}

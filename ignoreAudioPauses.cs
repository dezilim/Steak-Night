using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ignoreAudioPauses : MonoBehaviour
{

    public AudioSource thisSound;
    // Start is called before the first frame update
    void Start()
    {
        thisSound.ignoreListenerPause = true; 
        
    }

}

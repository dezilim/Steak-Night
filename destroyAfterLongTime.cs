using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyAfterLongTime : MonoBehaviour
{
    public float spawnTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        spawnTime += Time.deltaTime;
        // for sauces, if not attached to another gameobject it has to be destroyed soon

        if (spawnTime > 100f) {
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroySauceAfterTime : MonoBehaviour
{
    public float spawnTime = 0f;

    // Update is called once per frame
    void Update()
    {
        spawnTime += Time.deltaTime;
        if ((spawnTime > 1f) && (gameObject.transform.parent == null )) {
            Destroy(gameObject);
        }
        
    }
}

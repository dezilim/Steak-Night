using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dustbin : MonoBehaviour
{
    // Start is called before the first frame update
    void OnExitTrigger2D(Collider2D col)
    {
        Destroy(col.gameObject);
    }

}

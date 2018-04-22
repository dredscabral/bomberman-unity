using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.gameObject.isStatic && col.gameObject.tag != "ExtraBomb") {
            Destroy(col.gameObject);
        }


    }


}
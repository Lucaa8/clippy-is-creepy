using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashTheBug : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collision !");
        if(collision.tag == "Bug")
        {
            SRC_Bug bugScript = collision.GetComponent<SRC_Bug>();
            bugScript.RemoveBug();
        }
    }
}

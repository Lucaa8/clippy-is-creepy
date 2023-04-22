using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class breakScreenOnCollision : MonoBehaviour
{
    Renderer image;
    // Start is called before the first frame update
    void Start()
    {
        image = GameObject.Find("glassCrack").GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
       // nothing 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        image.enabled = true;
    }
}

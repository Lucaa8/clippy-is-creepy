using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BulletExplosion : MonoBehaviour
{
    private GlobalScript script;

    public GameObject bugCounterText;
    public int bugKilledCounter;
    public int maxBugKill;

    private void Start()
    {
        script = GameObject.Find("GameArea").GetComponent<GlobalScript>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SRC_Bug bugScript = collision.GetComponent<SRC_Bug>();
        if(bugScript != null)
        {
            bugScript.RemoveBug();
            script.addKill();
        }
    }
}

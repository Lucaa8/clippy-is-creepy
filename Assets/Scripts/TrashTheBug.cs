using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class TrashTheBug : MonoBehaviour
{
    public TextMeshProUGUI bugCounterText;
    public int bugKilledCounter = 0;
    public int maxBugKill = 20;

    private void Start()
    {
        bugCounterText.text = bugKilledCounter.ToString() + " / " + maxBugKill.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collision !");
        if(collision.tag == "IsDragged")
        {
            SRC_Bug bugScript = collision.GetComponent<SRC_Bug>();
            bugScript.RemoveBug();
            bugKilledCounter++;
            bugCounterText.text = bugKilledCounter.ToString() + " / " + maxBugKill.ToString();

            if(bugKilledCounter == maxBugKill)
            {
                return;
            }
        }
    }
}

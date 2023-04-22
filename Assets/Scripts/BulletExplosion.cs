using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BulletExplosion : MonoBehaviour
{
    public TextMeshProUGUI bugCounterText;
    public int bugKilledCounter = 0;
    public int maxBugKill = 100;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SRC_Bug bugScript = collision.GetComponent<SRC_Bug>();
        bugScript.RemoveBug();

        bugKilledCounter++;
        bugCounterText.text = bugKilledCounter.ToString() + " / " + maxBugKill.ToString();
    }
}

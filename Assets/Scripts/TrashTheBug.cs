using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class TrashTheBug : MonoBehaviour
{
    public SRC_BugSpawner spawner;
    public GameObject clippyobject;

    public TextMeshPro bugCounterText;
    private int bugKilledCounter = 0;
    private int maxBugKill = 20;

    private bool rotDirRight = true;
    private bool shake = false;
    private bool clippy = false;
    public float MoveSpeed;

    private void Start()
    {
        bugCounterText.text = bugKilledCounter.ToString() + " / " + maxBugKill.ToString();
    }

    private void Update()
    {
        if (clippy)
        {
            if (clippyobject.transform.position.x < 1)
            {
                clippyobject.transform.position += clippyobject.transform.right * MoveSpeed * 10 * Time.deltaTime;
            }
            else
            {
                clippy = false;
                StartCoroutine(sleep5());
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!spawner.spawn)
            return;
        if(collision.tag == "IsDragged")
        {
            SRC_Bug bugScript = collision.GetComponent<SRC_Bug>();
            bugScript.RemoveBug();
            bugKilledCounter++;
            bugCounterText.text = bugKilledCounter.ToString() + " / " + maxBugKill.ToString();

            if(bugKilledCounter >= 12 && bugKilledCounter < 17 && !shake)
            {
                shake = true;
                StartCoroutine(shakeTrash());
            }
            else if(bugKilledCounter >= 17)
            {
                transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                shake = false;
                spawner.spawn = false;
                clippy = true;
                clippyobject.GetComponentInChildren<TextMeshPro>().text = "WOW! Il y a beaucoup trop de bugs pour les supprimer!!<br>Je n'avais pas prévu cela...";
            }
        }
    }

    IEnumerator shakeTrash()
    {
        while(shake)
        {
            Quaternion curRot = transform.rotation;
            int rot = 0;
            if (curRot.z == 0)
            {
                if (rotDirRight)
                {
                    rot = 15;
                }
                else
                {
                    rot = -15;
                }
                rotDirRight = !rotDirRight;
            }
            transform.rotation = Quaternion.Euler(0f, 0f, rot);
            yield return new WaitForSeconds(0.1f);
        }
    }

    IEnumerator sleep5()
    {
        int timer = 5;
        while (timer > 0)
        {
            timer--;
            yield return new WaitForSeconds(1.0f);
        }
        //transition !!!

	    GameObject.Find("gameManager").GetComponent<sceneSwitcher>().FadeOut();
    }
}

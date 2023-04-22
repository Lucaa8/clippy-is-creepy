using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ClippyShmooving : MonoBehaviour
{
    public float timer;
    public float timerSpeed;
    private float rand;
    private float timeToMove;
    private Vector3 newPosition;
    public int speed;

    public float xPos;
    public float yPos;
    public Vector3 desiredPos;

    public bool hasBeenDefeated = false;
    public int PV;
    private int pvmax;

    public GameObject dialog;
    public GameObject healthText;

    private int currentLine = 0;
    private string[] lines = { 
        "Vous ne pourrez pas m'arrêter",
        "Je reviendrais et me vengerais",
        "Arrrgh...",
        "Vous faîtes une grave erreur",
        "Nous nous reverrons."
    };

    void Start()
     {
        xPos = Random.Range(-3.1f, 3.1f);
        yPos = Random.Range(-3.1f, 3.1f);
        desiredPos = new Vector3(xPos, yPos, transform.position.z);
        pvmax = PV;
     }

    void Update()
    {
        if (!hasBeenDefeated)
        {
            timer += Time.deltaTime * timerSpeed;
            if (timer >= timeToMove)
            {
                transform.position = Vector3.Lerp(transform.position, desiredPos, Time.deltaTime * speed);

                if (Vector3.Distance(transform.position, desiredPos) <= 0.01f)
                {
                    xPos = Random.Range(-3.1f, 3.1f);
                    yPos = Random.Range(-3.1f, 3.1f);
                    desiredPos = new Vector3(xPos, yPos, transform.position.z);
                    timer = 0.0f;
                }
            }
        }
    }

    private void OnMouseDown()
    {
        if(PV > 0)
        {
            PV--;
            healthText.GetComponentInChildren<TextMeshPro>().text = (pvmax - PV) + "/" + pvmax;
            if(PV%2==0)
            {
                dialog.GetComponentInChildren<TextMeshPro>().text = lines[currentLine++];
            }
        }
        else
        {
            hasBeenDefeated = true;
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
		    GameObject.Find("gameManager").GetComponent<sceneSwitcher>().FadeOut();
        }
    }
}

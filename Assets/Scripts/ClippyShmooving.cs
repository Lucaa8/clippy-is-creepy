using System.Collections;
using System.Collections.Generic;
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

    void Start()
     {
        xPos = Random.Range(-3.1f, 3.1f);
        yPos = Random.Range(-3.1f, 3.1f);
        desiredPos = new Vector3(xPos, yPos, transform.position.z);
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
        }
        else
        {
            Debug.Log("Clippy has been defeated");
            hasBeenDefeated = true;
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;

            //ICI IL FAUT CHANGER DE SCENE NINI MON PETIT CHOU ADORE
            //(nohomo)
            // merci mon loulou

		    GameObject.Find("gameManager").GetComponent<sceneSwitcher>().FadeOut();
        }
    }
}

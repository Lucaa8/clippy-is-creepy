using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class breakScreenOnCollision : MonoBehaviour
{
    Renderer image;
    private bool activeClippy = false;

    public GameObject clippy;
    public GameObject bubble;
    public TextMeshPro text;
    public float MoveSpeed;

    private bool shown = false;

    // Start is called before the first frame update
    void Start()
    {
        image = GameObject.Find("glassCrack").GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
       if(activeClippy)
        {
            if (clippy.transform.position.x > 5)
            {
                clippy.transform.position -= clippy.transform.right * MoveSpeed * 10 * Time.deltaTime;
            }
            else
            {
                if (!shown)
                {
                    bubble.SetActive(true);
                    text.gameObject.SetActive(true);
                    shown = true;
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        image.enabled = true;
        activeClippy = true;
    }
}

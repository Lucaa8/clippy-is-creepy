using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Phone : MonoBehaviour
{

    private bool is_glitching;

    private string fullNumber = "4815162342";
    private int currentNumber = 0;

    public float MoveSpeed;

    public TextMeshPro numberText;
    public GameObject clippy;
    public GameObject bubble;
    public TextMeshPro text;
    public GameObject bugText;

    private bool currentGlitch1 = false;
    public Sprite phone_normal;
    public Sprite phone_glitch_1;
    public Sprite phone_glitch_2;
    public Sprite phone_glitch_3;

    private bool clippyActive = false;
    private bool clippyForward = true;
    private bool clippyBackward = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(clippyActive)
        {
            if(clippyForward)
            {
                if (clippy.transform.position.x > 7)
                {
                    clippy.transform.position -= clippy.transform.right * MoveSpeed * 10 * Time.deltaTime;
                }
                else
                {
                    bubble.SetActive(true);
                    text.gameObject.SetActive(true);
                    clippyForward = false;
                    StartCoroutine(sleep2());
                }
            }
            else if(clippyBackward)
            {
                if (clippy.transform.position.x < 10)
                {
                    clippy.transform.position += clippy.transform.right * MoveSpeed * 10 * Time.deltaTime;
                }
                else
                {
                    clippyBackward = false;
                    clippyActive = false;
                    clippyForward = true;
                }
            }
        }
    }

    public void press(string number)
    {
        if (is_glitching)
            return;
        if (fullNumber[currentNumber] == number[0])
        {
            currentNumber++;
            numberText.text += number[0];
            if(currentNumber == 3 || currentNumber == 7)
            {
                StartCoroutine(glitching(currentNumber == 7));
                is_glitching = true;
            }
            if(currentNumber == fullNumber.Length)
            {
                is_glitching = true;
                //change scene
			    GameObject.Find("gameManager").GetComponent<sceneSwitcher>().FadeOut();
            }
        }
        else
        {
            if(!clippyActive)
            {
                clippyActive = true;
            }
        }
    }

    IEnumerator glitching(bool bug)
    {
        for(int i=0;i<46;i++)
        {
            if(i%6==0 && bug)
            {
                bugText.SetActive(!bugText.activeSelf);
            }
            if(currentGlitch1)
            {
                GetComponent<SpriteRenderer>().sprite = bug ? phone_glitch_3 : phone_glitch_1;
            }
            else
            {
                GetComponent<SpriteRenderer>().sprite = phone_glitch_2;
            }
            currentGlitch1 = !currentGlitch1;
            yield return new WaitForSeconds(0.06f);
        }
        is_glitching = false;
        GetComponent<SpriteRenderer>().sprite = phone_normal;
    }

    IEnumerator sleep2()
    {
        int timer = 2;
        while (timer > 0)
        {
            timer--;
            yield return new WaitForSeconds(1.0f);
        }
        clippyBackward = true;
        bubble.SetActive(false);
        text.gameObject.SetActive(false);
    }

}

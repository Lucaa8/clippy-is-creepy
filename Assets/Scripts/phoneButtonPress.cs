using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class phoneButtonPress : MonoBehaviour
{
    SpriteRenderer sr_button;
    public Sprite dark_sprite;
    public string number;
    Sprite light_sprite;
    public TMP_Text input;
    SpriteRenderer sr_phone;
    Sprite phone_std;
    public Sprite phone_glitch_1;
    public Sprite phone_glitch_2;

    private bool is_glitching;
    private bool has_glitched;

    private int frames;
    Coroutine routine;

    // Start is called before the first frame update
    void Start()
    {
        sr_button = gameObject.GetComponent<SpriteRenderer>();
        light_sprite = sr_button.sprite;
        has_glitched = false;

        sr_phone = GameObject.Find("phone").GetComponent<SpriteRenderer>();
        phone_std = sr_phone.sprite;
    }

    // Update is called once per frame
    void Update()
    {
        if(is_glitching)
        {
            frames++;
            run_glitch();
		}
    }

    private void call_routine()
    {
        if (routine == null)
        {
            routine = StartCoroutine(enable_glitch());
        }
        else
        {
            stop_glitch();
            has_glitched = true;
		}
    }

    private void stop_glitch()
    {
        StopCoroutine(routine);
        is_glitching = false;
    }

    private void OnMouseDown()
    {
        sr_button.sprite = dark_sprite;
        input.text += number;

        if(has_glitched == false)
        {
            Debug.Log("glitch enabled");
			is_glitching = true;
            StartCoroutine(enable_glitch());
            has_glitched = true;
	    }
    }

    private void OnMouseUp()
    {
        sr_button.sprite = light_sprite;
    }

    IEnumerator enable_glitch()
    {
        yield return new WaitForSeconds(1);
        sr_phone.sprite = phone_std;
        is_glitching = false;
    }

    private void run_glitch()
    {
	    if(frames % 2 == 0)
	    {
			sr_phone.sprite = phone_glitch_1;
	    }
	    else
	    { 
			sr_phone.sprite = phone_glitch_2;
	    }
    }
}

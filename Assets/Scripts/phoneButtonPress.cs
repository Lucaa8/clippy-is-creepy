using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class phoneButtonPress : MonoBehaviour
{
    public SpriteRenderer sr_button;

    public Sprite dark_sprite;
    public Sprite light_sprite;

    public string number;

    // Start is called before the first frame update
    void Start()
    {
        sr_button = gameObject.GetComponent<SpriteRenderer>();
    }


    private void OnMouseDown()
    {
        sr_button.sprite = dark_sprite;
    }

    private void OnMouseUp()
    {
        sr_button.sprite = light_sprite;
        GameObject.Find("phone").GetComponent<Phone>().press(number);
    }
}

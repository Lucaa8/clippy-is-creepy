using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextAnimation : MonoBehaviour
{
    private bool isAnimated = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(sleep());


    }

    // Update is called once per frame
    void Update()
    {
        if(isAnimated)
        {
            gameObject.transform.position += Vector3.up * 1.5f * Time.deltaTime;
        }
    }

    IEnumerator sleep()
    {
        int timer = 3;
        while (timer > 0)
        {
            timer--;
            yield return new WaitForSeconds(1.0f);
        }
        isAnimated= true;
    }
}

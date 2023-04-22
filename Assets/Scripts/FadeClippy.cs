using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class FadeClippy : MonoBehaviour
{

    public int timer = 5;
    public float MoveSpeed = 0.5f;

    private bool remove = false;

    private bool shown = true;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(sleep5());
    }

    // Update is called once per frame
    void Update()
    {
        if(remove && shown)
        {
            if (transform.position.x > -15)
            {
                transform.position -= transform.right * MoveSpeed * 10 * Time.deltaTime;
            }
            else
            {
                if (shown) shown = false;
            }
        }
    }

    IEnumerator sleep5()
    {
        while (timer > 0)
        {
            timer--;
            yield return new WaitForSeconds(1.0f);
        }
        remove = true;
    }

}

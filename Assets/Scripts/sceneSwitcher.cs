using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class sceneSwitcher : MonoBehaviour
{
    public GameObject blackSquare;
    public string nextScene;
    // Start is called before the first frame update
    void Start()
    {
        //Color c = blackSquare.GetComponent<Image>().color;
        //c.a = 100;
        //blackSquare.GetComponent<Image>().color = c;

        Color c = blackSquare.GetComponent<Image>().color;
        c = new Color(c.r, c.g, c.b, 1);
        blackSquare.GetComponent<Image>().color = c;

        StartCoroutine(FadeIn());
    }

    // Update is called once per frame
    void Update()
    {
    }

    public IEnumerator waitAndFadeIn()
    {
        yield return new WaitForSeconds(2);
        StartCoroutine(FadeIn());
    }


    public void FadeOut()
    {
        StartCoroutine(FadeOut_());
    }

    private IEnumerator FadeOut_(int fadeSpeed = 5)
    {
        Color objectColor = blackSquare.GetComponent<Image>().color;
        float fadeAmount;

        while(blackSquare.GetComponent<Image>().color.a < 1)
        {
            fadeAmount = objectColor.a + (fadeSpeed * Time.deltaTime);

            objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
            blackSquare.GetComponent<Image>().color = objectColor;
            yield return null;
		}
        if(nextScene != "")
        {
            SceneManager.LoadScene(nextScene);
		}
    }

    public IEnumerator FadeIn(int fadeSpeed = 5)
    {
	    Color objectColor = blackSquare.GetComponent<Image>().color;
        float fadeAmount;

        while (blackSquare.GetComponent<Image>().color.a > 0)
        {
            fadeAmount = objectColor.a - (fadeSpeed * Time.deltaTime);

            objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
            blackSquare.GetComponent<Image>().color = objectColor;
            yield return null;
        }
    }
}

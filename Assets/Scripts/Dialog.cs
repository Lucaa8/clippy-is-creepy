using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor;

public class Dialog : MonoBehaviour
{

    public TextMeshProUGUI text;
    public string[] lines;
    public float speed;
    public TextMeshProUGUI linesText;

    private int index;

    // Start is called before the first frame update
    void Start()
    {
        text.text = string.Empty;
        linesText.text = "1/" + lines.Length;
        StartDialog();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(text.text == lines[index])
            {
                NextLine();
                linesText.text = (index + 1) + "/" + lines.Length;
            }
            else
            {
                StopAllCoroutines();
                text.text = lines[index];
            }
        }
    }

    void StartDialog()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        char[] c = lines[index].ToCharArray();
        for(int i=0;i<c.Length;i++)
        {
            char current = c[i];
            if(i+3 < c.Length && current == '<' && c[i+1] == 'b' && c[i+2] == 'r' && c[i+3] == '>')
            {
                text.text += "<br>";
                i += 3;
            }
            else
            {
                text.text += current;
            }
            yield return new WaitForSeconds(speed);
        }
        /*foreach(char c in lines[index].ToCharArray())
        {
            text.text += c;
            yield return new WaitForSeconds(speed);
        }*/
    }

    void NextLine()
    {
        if(index < lines.Length -1) {
            index++;
            text.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            // change scene
            GameObject.Find("gameManager").GetComponent<sceneSwitcher>().FadeOut();
        }
    }
}

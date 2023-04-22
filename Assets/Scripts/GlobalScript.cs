using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GlobalScript : MonoBehaviour
{

    public GameObject bugCounterText;
    public int bugKilledCounter;
    public int maxKills = 500;

    private bool started = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addKill()
    {
        if (maxKills - bugKilledCounter <= 0)
        {
            if(!started)
            {
                StartCoroutine(sleep1());
                started = true;
            }
            return;
        }
        bugKilledCounter++;
        bugCounterText.GetComponentInChildren<TextMeshPro>().text = (maxKills - bugKilledCounter) + " restants";
    }

    IEnumerator sleep1()
    {
        yield return new WaitForSeconds(1);

	    GameObject.Find("gameManager").GetComponent<sceneSwitcher>().FadeOut();
    }
}

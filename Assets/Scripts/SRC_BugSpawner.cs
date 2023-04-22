using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SRC_BugSpawner : MonoBehaviour
{
    public GameObject bug;
    public GameObject gameArea;
    public GameObject bugRandomText;

    public int bugCount = 0;
    public int bugLimit;
    public int bugPerFrame = 1;

    public float spawnCircleRadius;
    public float deathCircleRadius;

    public float fastestSpeed;
    public float slowestSpeed;

    public bool spawn = true;

    private string[] lines = {  "Ne faîtes pas ça!",
                                "Vous ne devriez pas faire ça!",
                                "Ne l'aidez surtout pas!",
                                "Clippy n'est pas si gentil!",
                                "Vous faîtes une grave erreur!"
                              };

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(spawn)
            MaintainBugPopulation();
    }

    void MaintainBugPopulation()
    {
        if (bugCount < bugLimit)
        {
            for (int i = 0; i < bugLimit; i++)
            {
                Vector3 position = GetRandomPositions();

                SRC_Bug newBug = AddBug(position);
            }
        }
    }

    Vector3 GetRandomPositions()
    {
        Vector3 position = UnityEngine.Random.insideUnitCircle.normalized;

        position *= spawnCircleRadius;
        position += gameArea.transform.position;

        return position;
    }

    SRC_Bug AddBug(Vector3 position)
    {
        bugCount++;
        Quaternion parentRot = Quaternion.FromToRotation(Vector3.up, gameArea.transform.position - position);
        GameObject newBug = Instantiate(bug, position, parentRot, gameObject.transform);

        int randInt = UnityEngine.Random.Range(0, 100);
        if (randInt >= 0 && randInt < 5)
        {
            GameObject newDialog = Instantiate(bugRandomText, newBug.transform);
            newDialog.SetActive(true);
            newDialog.transform.rotation = Quaternion.Euler(0f, 0f, -parentRot.z);
            newDialog.transform.position = newBug.transform.position + new Vector3(-4.5f, 0.5f, 0f);
            newDialog.GetComponentInChildren<TextMeshPro>().text = lines[randInt];
        }

        SRC_Bug bugScript = newBug.GetComponent<SRC_Bug>();
        bugScript.bugSpawner = this;
        bugScript.gameArea = gameArea;
        bugScript.speed = UnityEngine.Random.Range(slowestSpeed, fastestSpeed);

        return bugScript;
    }
}

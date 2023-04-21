using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SRC_BugSpawner : MonoBehaviour
{
    public GameObject bug;
    private List<GameObject> bugList = new List<GameObject>();

    public GameObject gameArea;

    public int bugCount = 0;
    public int bugLimit = 500;
    public int bugPerFrame = 1;

    public float spawnCircleRadius = 150.0f;
    public float deathCircleRadius = 160.0f;

    public float fastestSpeed = 20.0f;
    public float slowestSpeed = 1.0f;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
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
        GameObject newBug = Instantiate(
            bug,
            position,
            Quaternion.FromToRotation(Vector3.up, (gameArea.transform.position - position)), gameObject.transform);

        SRC_Bug bugScript = newBug.GetComponent<SRC_Bug>();
        bugScript.bugSpawner = this;
        bugScript.gameArea = gameArea;
        bugScript.speed = UnityEngine.Random.Range(slowestSpeed, fastestSpeed);

        return bugScript;
    }
}

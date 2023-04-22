using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SRC_Bug : MonoBehaviour
{
    public SRC_BugSpawner bugSpawner; 
    public GameObject gameArea;

    public float speed;


    void Update()
    {
        Move();
    }

    void Move()
    {
        transform.position += transform.up * (Time.deltaTime * speed);

        float distance = Vector3.Distance(transform.position, gameArea.transform.position);

        if (distance > bugSpawner.deathCircleRadius)
            RemoveBug();

    }
    public void RemoveBug()
    {
        Destroy(gameObject);
        bugSpawner.bugCount--;
    }
}

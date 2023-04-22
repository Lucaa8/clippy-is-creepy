using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugDragnDrop : MonoBehaviour
{
    private bool isDragged = false;
    private Vector3 offset;

    void Update()
    {
        if (isDragged)
        {
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
        }
    }

    private void OnMouseDown()
    {
        this.tag = "IsDragged";

        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        isDragged = true;
    }

    private void OnMouseUp()
    {
        this.tag = "Bug";

        isDragged = false;
    }
}

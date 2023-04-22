using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouvement : MonoBehaviour
{
    public float moveSpeed = 5.0f;

    public Rigidbody2D rb;

    Vector2 mouvement;

    void Update()
    {
        mouvement.x = Input.GetAxisRaw("Horizontal");
        mouvement.y = Input.GetAxisRaw("Vertical");

        float h = Input.mousePosition.x - Screen.width / 2;
        float v = Input.mousePosition.y - Screen.height / 2;
        float angle = -Mathf.Atan2(v, h) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, -angle);
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + mouvement * moveSpeed * Time.fixedDeltaTime);
    }
}

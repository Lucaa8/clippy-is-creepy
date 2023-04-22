using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class PlayerShooting : MonoBehaviour
{
    public Rigidbody2D bullet;
    public int speed;

     Vector3 shootDirection;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            shootDirection = Input.mousePosition;
            shootDirection.z = 0.0f;
            shootDirection = Camera.main.ScreenToWorldPoint(shootDirection);
            shootDirection = shootDirection - transform.position;
            //instantiating the bullet
            Rigidbody2D bulletInstance = Instantiate(bullet, transform.position, Quaternion.Euler(new Vector3(0, 0, 0))) as Rigidbody2D;
            bulletInstance.velocity = new Vector2(shootDirection.x * speed, shootDirection.y * speed);
        }
    }
}

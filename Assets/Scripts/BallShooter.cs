using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;

public class BallShooter : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;

    [SerializeField] private int startingBulletNumber;

    private Transform shootingPosition;

    private Camera camera;

    private Rigidbody2D body;

    private Vector3 mousePosition;
    // Start is called before the first frame update
    void Start()
    {
        camera = FindObjectOfType<Camera>();
        body = GetComponent<Rigidbody2D>();
        shootingPosition = transform.GetChild(0);
    }

    private void FixedUpdate()
    {
        Vector2 lookDirection = mousePosition - transform.position;
        float angle = Mathf.Atan2(lookDirection.y,lookDirection.x)*Mathf.Rad2Deg;
        body.rotation = angle;
        //Debug.Log(body.rotation);
        if (body.rotation >= 160)
        {
            Debug.Log("more than 160");
            body.rotation = 160;
        }
        else if (body.rotation <= 20)
        {
            Debug.Log("less than 20 " + transform.rotation.z);
            body.rotation = 20;
        }
    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = camera.WorldToScreenPoint(Input.mousePosition);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject bullet = Instantiate(bulletPrefab, shootingPosition.position, quaternion.identity);
            Rigidbody2D bulletBody = bullet.GetComponent<Rigidbody2D>();
            bulletBody.AddForce(shootingPosition.up * 10, ForceMode2D.Impulse);
        }
    }
}

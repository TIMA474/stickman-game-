using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform arrow;
    [SerializeField] private float moveSpeed, rotationSpeed;

    private bool canMove, canRotate, canShoot; //by default its false
    private Vector3 moveDir;
    private float currentRotationAngle;
    private float minRotationAngle, maxRotationAngele;

    private void Awake()
    {
        canMove = true;
        canRotate = true;
        canShoot = false;
        currentRotationAngle = 90f;
    }

    private void Update()
    {
        if (canShoot && Input.GetMouseButtonDown (0))
        {
            Shoot();
        }
    }

    private void Shoot () 
    {
        canRotate = false;
        canShoot = false;   

        moveDir = new Vector3 (Mathf.Cos (currentRotationAngle * Mathf.Deg2Rad), Mathf.Sin (currentRotationAngle* Mathf.Deg2Rad), 0);
        currentRotationAngle = (currentRotationAngle + 180) % 720f;
        //hide the arrow
        arrow.gameObject.SetActive (false);

    }

    private void FixedUpdate()
    {
        if (!canMove)
            return;

        if (canRotate)
        {

            if (currentRotationAngle > maxRotationAngele) 
            {
                currentRotationAngle = maxRotationAngele;
                rotationSpeed *= -1f;
            }

            if (currentRotationAngle < minRotationAngle)
            {
                currentRotationAngle = minRotationAngle;
                rotationSpeed *= -1f;
            }

            currentRotationAngle += rotationSpeed * Time.fixedDeltaTime;

            arrow.rotation = Quaternion.Euler(0, 0, currentRotationAngle);
        }

        else if(canMove) 
        {
            transform.position += moveDir * moveSpeed * Time.fixedDeltaTime;
        } 
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag ("Wall"))
        {
            canRotate = true;
            canShoot = true;
            arrow.gameObject.SetActive(true);
            arrow.rotation = Quaternion.Euler (0, 0, currentRotationAngle);
            var boundry = other.gameObject.GetComponent<Boundry> ();
            minRotationAngle = boundry.minAngle;
            maxRotationAngele = boundry.maxAngle;
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private float minX, maxX;
    [SerializeField] private float minY, maxY;
    [SerializeField] private float rotationSpeed = 90f;

    private void Start()
    {
        transform.position = new Vector3(Random.Range(minX,maxX), Random.Range(minY, maxY), 0f);
    }

    private void FixedUpdate()
    {
        transform.Rotate(rotationSpeed * Time.deltaTime * Vector3.forward);     
    }
}

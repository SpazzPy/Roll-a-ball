using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float speed = 3f;
    private Vector3 startPosition;



    void Start()
    {
        startPosition = transform.position;
    }
    void Update()
    {
        transform.position = startPosition;
        transform.Rotate(0f, speed * Time.deltaTime, 0f);
    }
}

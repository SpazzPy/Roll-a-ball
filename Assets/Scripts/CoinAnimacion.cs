using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CoinAnimacion : MonoBehaviour
{
    public float floatSpeed = 1f;
    public float floatHeight = 0.25f;
    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float newY = startPosition.y + Mathf.Sin(Time.time * floatSpeed) * floatHeight;
        // newY = Mathf.Max(newY, 0.5f);
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);

        transform.Rotate(new Vector3(0f, 90f, 0f) * Time.deltaTime);


    }
}

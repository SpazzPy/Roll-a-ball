using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CameraController : MonoBehaviour
{
    public Transform jugador;
    public float distance = 3;
    public float smoothTime = 0.05f;
    public float targetRotationX = 20f;
    Vector3 currentVelocity;


    void FixedUpdate()
    {
        Vector3 target = jugador.position + (transform.position - jugador.position).normalized * distance;
        target[1] = jugador.position[1] + 2.5f;

        transform.position = target;
        transform.LookAt(jugador);

        Quaternion targetRotation = Quaternion.Euler(targetRotationX, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
        transform.rotation = targetRotation;

    }

    public Vector3 GetMovementDirection()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");


        Vector3 cameraForward = transform.forward;
        Vector3 cameraRight = transform.right;

        Vector3 direccionMovimiento = (cameraForward * vertical + cameraRight * horizontal).normalized;

        return direccionMovimiento;
    }




}

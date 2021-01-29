using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroMovement : MonoBehaviour
{
    public Joystick joystickLeft;
    public Joystick joystickRight;
    public GameObject hero;
    protected TouchField TouchField;

    public Transform camHero;

    protected float movementSpeed = 2.5f;
    protected float CameraRotationSpeed = 100f;

    private void Awake()
    {
        TouchField = FindObjectOfType<TouchField>();
    }

    void Update()
    {
        Movement();
    }

    void Movement()
    {
        if (joystickLeft.Vertical != 0.0f || joystickLeft.Horizontal != 0.0f)
        {
            camHero.transform.position +=
                hero.transform.right * joystickLeft.Horizontal * movementSpeed * Time.deltaTime;
            camHero.transform.position +=
                hero.transform.forward * joystickLeft.Vertical * movementSpeed * Time.deltaTime;
        }

        if (joystickRight.Horizontal != 0.0f)
        {
            float yEulerAngles = joystickRight.Horizontal * CameraRotationSpeed * Time.deltaTime;
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x,
                transform.rotation.eulerAngles.y + yEulerAngles, transform.rotation.eulerAngles.z);
        }
        
        transform.Rotate(Vector3.up, TouchField.TouchDist.x);
    }


}

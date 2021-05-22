using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using System.Windows.Input;

public class ObjectsRotation : MonoBehaviour
{
    Joystick lookJoystick;
    Joystick joystick;
    public bool pressed;

    public void Start()
    {
        joystick = GameObject.Find("Fixed Joystick").GetComponent<Joystick>();
        lookJoystick = GameObject.Find("Fixed Joystick").GetComponent<Joystick>();
    }
    public void FixedUpdate()
    {
        float hoz = joystick.Horizontal;
        float ver = joystick.Vertical;
        Vector3 direction = new Vector3(ver, -90, -hoz).normalized;

        if (hoz == 0 || ver == 0)
        {
            pressed = false;
        }
        else
        {
            pressed = true;
        }
        UpdateLookJoystick();
    }

    public void UpdateLookJoystick()
    {
        float hoz = lookJoystick.Horizontal;
        float ver = lookJoystick.Vertical;

        if (pressed)
        {
            Vector3 direction = new Vector3(ver, -90, -hoz).normalized;
            Vector3 lookAtPosition = transform.position + direction;
            transform.LookAt(lookAtPosition);
        }
    }
}

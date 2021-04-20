using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    Joystick joystick;
    Joystick lookJoystick;
    [SerializeField] float speed = 0;
    public GameObject player;

    CharacterController playMov;


    private void Start()
    {
        playMov = GetComponent<CharacterController>();

        joystick = GameObject.Find("Fixed Joystick").GetComponent<Joystick>();
        lookJoystick = GameObject.Find("Fixed Joystick").GetComponent<Joystick>();
    }
    public void Walk()
    {
        float hoz = joystick.Horizontal;
        float ver = joystick.Vertical;
        
        if (hoz <= 0.7||hoz >= -0.7||ver >= -0.7||ver <= 0.7)
        {
            speed = 0.03f;
            player.GetComponent<Animator>().SetBool("IsWalking", true);
            player.GetComponent<Animator>().SetBool("IsRunning", false);
        }
        if (hoz == 0 && ver == 0)
        {
            player.GetComponent<Animator>().SetBool("IsWalking", false);
            player.GetComponent<Animator>().SetBool("IsRunning", false);
        }
    }
    public void FixedUpdate()
    {
        float hoz = joystick.Horizontal;
        float ver = joystick.Vertical;

        Vector3 direction = new Vector3(hoz, 0, ver).normalized;

        playMov.Move(direction * speed);
        //transform.Translate(direction * speed * Time.deltaTime, Space.World);

        
        if (ver >= 0.7||ver <= -0.7||hoz >= 0.7||hoz <= -0.7)
        {
            speed = 0.05f;
            player.GetComponent<Animator>().SetBool("IsRunning", true);
        }
        else
        {
            Walk();
        }
        UpdateLookJoystick();
        //Debug.Log(speed);
    }

    void UpdateLookJoystick()
    {
        float hoz = lookJoystick.Horizontal;
        float ver = lookJoystick.Vertical;

        Vector3 direction = new Vector3(hoz, 0, ver).normalized;
        Vector3 lookAtPosition = transform.position + direction;
        transform.LookAt(lookAtPosition);
    }
}

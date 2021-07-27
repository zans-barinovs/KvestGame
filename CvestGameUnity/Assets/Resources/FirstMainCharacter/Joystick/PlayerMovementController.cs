using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class PlayerMovementController : MonoBehaviour
{
    Joystick joystick;
    Joystick lookJoystick;
    [SerializeField] float speed = 0;
    public GameObject player;

    CharacterController playMov;

    private PhotonView ComponentPhotonView;

    private int UpdateCounter = 0;

    private float WalkingHeight = 1.0f;
    public Transform ThisObjectComponentTransform;


    private void Start()
    {
        playMov = GetComponent<CharacterController>();
        ComponentPhotonView = GetComponent<PhotonView>();

        joystick = GameObject.Find("Fixed Joystick").GetComponent<Joystick>();
        lookJoystick = GameObject.Find("Fixed Joystick").GetComponent<Joystick>();

        ScriptForEnterIntoVentilationButton.ClimbIntoVentiltionButtonOnClickEvent += WhenlimbIntoVentiltionButtonOnClickEvent;
    }
    public void Walk()
    {
        if(!ComponentPhotonView.IsMine ) return;

        float hoz = joystick.Horizontal;
        float ver = joystick.Vertical;
        
        if (hoz <= 0.7||hoz >= -0.7||ver >= -0.7||ver <= 0.7)
        {
            // Debug.Log("run fals; walk true");
            speed = 0.03f;
            player.GetComponent<Animator>().SetBool("IsWalking", true);
            player.GetComponent<Animator>().SetBool("IsRunning", false);
        }
        if (hoz == 0 && ver == 0)
        {
            // Debug.Log("run fals; walk false");
            player.GetComponent<Animator>().SetBool("IsWalking", false);
            player.GetComponent<Animator>().SetBool("IsRunning", false);
        }
    }
    public void FixedUpdate()
    {
        UpdateCounter++;

        if(UpdateCounter < 4 || !ComponentPhotonView.IsMine) return;

        float hoz = joystick.Horizontal;
        float ver = joystick.Vertical;

        Vector3 direction = new Vector3(hoz, 0, ver).normalized;

        playMov.Move(direction * speed);
        //transform.Translate(direction * speed * Time.deltaTime, Space.World);

        
        if (ver >= 0.7||ver <= -0.7||hoz >= 0.7||hoz <= -0.7)
        {
            speed = 0.05f;
            player.GetComponent<Animator>().SetBool("IsRunning", true);
            // Debug.Log("run true");
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
        if(!ComponentPhotonView.IsMine) return;

        float hoz = lookJoystick.Horizontal;
        float ver = lookJoystick.Vertical;

        Vector3 direction = new Vector3(hoz, 0, ver).normalized;
        Vector3 lookAtPosition = transform.position + direction;
        transform.LookAt(lookAtPosition);

        ThisObjectComponentTransform.position = new Vector3(ThisObjectComponentTransform.position.x, WalkingHeight, ThisObjectComponentTransform.position.z);
    }

    private void WhenlimbIntoVentiltionButtonOnClickEvent() 
    {
        WalkingHeight = 2.35f;
    }
}

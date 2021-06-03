using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEditor;

 
[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(CharacterController))]
// [RequireComponent(typeof(NetworkTransform))]
[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    public CharacterController characterController;

    public Camera FirstMainCharacterCamera;
    
    void OnValidate()
    {
        if (characterController == null)
            characterController = GetComponent<CharacterController>();
    }

    void Start()
    {
        // characterController.enabled = isLocalPlayer;
        FirstMainCharacterCamera.transform.SetParent(null);
    }

    void OnDisable()
    {
        // Camera.main.transform.SetParent(null);
        // if (Camera.main != null)
        // {
        //     Camera.main.orthographic = true;
        //     Camera.main.transform.SetParent(null);
        //     Camera.main.transform.localPosition = new Vector3(0f, 70f, 0f);
        //     Camera.main.transform.localEulerAngles = new Vector3(90f, 0f, 0f);
        // }
    }

    [Header("Movement Settings")]
    public float moveSpeed = 8f;
    public float turnSensitivity = 5f;
    public float maxTurnSpeed = 150f;

    [Header("Diagnostics")]
    public float horizontal;
    public float vertical;
    public float turn;
    public float jumpSpeed;
    public bool isGrounded = true;
    public bool isFalling;
    public Vector3 velocity;
    private int UpdateCounter = 0; 

    public PhotonView ComponentPhotonView;

    void Update()
    {
        UpdateCounter++;
        if(UpdateCounter < 5) return;
        if(!ComponentPhotonView.IsMine) return;

        ComponentPhotonView = GetComponent<PhotonView>();   
        if (!ComponentPhotonView.IsMine || !characterController.enabled)
            return;
        
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        if (Input.GetKey(KeyCode.LeftShift))
        {
            moveSpeed = 7f;
        }
        else
        {
            moveSpeed = 2.7f;
        }
        // Q and E cancel each other out, reducing the turn to zero
        if (Input.GetKey(KeyCode.Q))
            turn = Mathf.MoveTowards(turn, -maxTurnSpeed, turnSensitivity);
        if (Input.GetKey(KeyCode.E))
            turn = Mathf.MoveTowards(turn, maxTurnSpeed, turnSensitivity);
        if (Input.GetKey(KeyCode.Q) && Input.GetKey(KeyCode.E))
            turn = Mathf.MoveTowards(turn, 0, turnSensitivity);
        if (!Input.GetKey(KeyCode.Q) && !Input.GetKey(KeyCode.E))
            turn = Mathf.MoveTowards(turn, 0, turnSensitivity);
        
    }

    void FixedUpdate()
    {
        if(UpdateCounter < 5 || !ComponentPhotonView.IsMine || characterController == null) return;
        
        transform.Rotate(0f, turn * Time.fixedDeltaTime, 0f);
        
        Vector3 direction = new Vector3(horizontal, jumpSpeed, vertical);
        direction = Vector3.ClampMagnitude(direction, 1f);
        direction = transform.TransformDirection(direction);
        direction *= moveSpeed;
        if (jumpSpeed > 0)
            characterController.Move(direction * Time.fixedDeltaTime);
        else
            characterController.SimpleMove(direction);

        isGrounded = characterController.isGrounded;
        velocity = characterController.velocity;
    }
}
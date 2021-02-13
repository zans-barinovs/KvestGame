using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
    public class Animation_Control : NetworkBehaviour
    {
        Animator CurrentAnimation;
        
        // Start is called before the first frame update
        
        void Start()
        {
            CurrentAnimation = GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                CurrentAnimation.SetBool("isRunning", true);
            }
            else
            {
                CurrentAnimation.SetBool("isRunning", false);
            }
            if (Input.GetKey(KeyCode.W))
            {
                CurrentAnimation.SetBool("isWalking", true);
            }
            else if(Input.GetKey(KeyCode.S))
            {
                CurrentAnimation.SetBool("isWalking", true);
            }
            else if (Input.GetKey(KeyCode.A))
            {
                CurrentAnimation.SetBool("isWalking", true);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                CurrentAnimation.SetBool("isWalking", true);
            }
            else
            {
                CurrentAnimation.SetBool("isWalking", false);
            }

        }
    }


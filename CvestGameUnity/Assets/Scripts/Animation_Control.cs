using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
    public class Animation_Control : NetworkBehaviour
    {
        Animator anim;
        
        // Start is called before the first frame update
        
        void Start()
        {
            anim = GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                anim.SetBool("isRunning", true);
            }
            else
            {
                anim.SetBool("isRunning", false);
            }
            if (Input.GetKey("w"))
            {
                anim.SetBool("isWalking", true);
            }
            else
            {
                anim.SetBool("isWalking", false);
            }

        }
    }


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEditor;

public class EnterIntoVentilationScript : MonoBehaviour
{
    public Rigidbody ThisObjectComponentRigidbody;
    public Transform ThisObjectComponentTransform;

    private bool EnterIntoVentilation = false;
    
    private void Start() 
    {
        ScriptForEnterIntoVentilationButton.ClimbIntoVentiltionButtonOnClickEvent += WhenlimbIntoVentiltionButtonOnClickEvent;
    }
    private void WhenlimbIntoVentiltionButtonOnClickEvent() 
    {

        // Physics.IgnoreCollision( GameObject.FindGameObjectWithTag("Ventilation").GetComponent<Collider>(), this.GetComponent<Collider>());

        ThisObjectComponentTransform.position = new Vector3(1f, 2.35f, 0.0f);
        // ThisObjectComponentRigidbody.AddForce(Vector3.forward);
        ThisObjectComponentTransform.localScale = new Vector3(0.1f, 0.1f, 0.1f);

        EnterIntoVentilation = true;

        // Physics.IgnoreCollision( GameObject.FindGameObjectWithTag("Ventilation").GetComponent<BoxCollider>() , this.GetComponent<Collider>(), false);
    }

    private void Update() {
        // Debug.Log(ThisObjectComponentTransform.position);
        if (EnterIntoVentilation)
        {
            ThisObjectComponentTransform.position = new Vector3(ThisObjectComponentTransform.position.x, 2.35f, ThisObjectComponentTransform.position.z);
            // ThisObjectComponentTransform.position.y = 2.4f;
        }
    }
}
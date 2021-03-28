using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptForEnterIntoVentilationButton : MonoBehaviour
{
    public delegate void ClimbIntoVentiltionButtonUnClick();
    public static event ClimbIntoVentiltionButtonUnClick ClimbIntoVentiltionButtonOnClickEvent;


    public GameObject ThisObject;

    private float WaitForEventTime = 0.5f;
    private float TimerForEventTime = 0.0f;

    private float MaxPresedButtonTime = 0.1f;
    private float TimerForMaxPresedButtonTime = 0.0f;

    private bool ButtonPresed; 

    Ray RayFromMouse;
    RaycastHit RayFromMouseHitedObjects;

    // Start is called before the first frame update
    void Start()
    {
        VentilationEnterScript.CharecterNearVentilationEnterSegment += WhenCharecterNearVentilationEnterSegment;
        ThisObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        TimerForEventTime += Time.deltaTime;
        TimerForMaxPresedButtonTime += Time.deltaTime;

        if (TimerForEventTime > WaitForEventTime)
        {
            ThisObject.SetActive(false);
        }

        if (TimerForMaxPresedButtonTime > MaxPresedButtonTime)
        {
            ButtonPresed = false;
        }

        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(2))
        {
            TimerForMaxPresedButtonTime = 0.0f;
            ButtonPresed = true;
        }

        RayFromMouse = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(RayFromMouse, out RayFromMouseHitedObjects))
        {
            if(ButtonPresed && RayFromMouseHitedObjects.transform.position.ToString() == new Vector3(0.0f, 2.6f, 0.7f).ToString())
            {
                ClimbIntoVentiltionButtonOnClickEvent?.Invoke();
                Debug.Log("ClimbIntoVentiltionButtonOnClickEvent");
            }
        }
        
    }

    void WhenCharecterNearVentilationEnterSegment()
    {
        ThisObject.SetActive(true);
        TimerForEventTime = 0.0f;
    }
}

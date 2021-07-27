using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutItemIntoToiletScript : MonoBehaviour
{
    public delegate void PutItemIntoToiletButtonDelegate();
    public static event PutItemIntoToiletButtonDelegate PutItemIntoToiletButtonEvent;


    public GameObject ThisObject;

    private float WaitForEventTime = 0.1f;
    private float TimerForEventTime = 0.0f;

    private float MaxPresedButtonTime = 0.1f;
    private float TimerForMaxPresedButtonTime = 0.0f;

    private bool ButtonPresed;

    Ray RayFromMouse;
    RaycastHit RayFromMouseHitedObjects;

    private Camera FirstMainCharacterCamera;

    private bool CisternOpend;

    // Start is called before the first frame update
    void Start()
    {
        CharacterNearToiletScript.CharecterNearToiletEvent += WhenCharecterNearToiletEvent;
        ScriptForOpenToiletCisternButton.OpenToiletCisternButtonUnClickEvent += WhenOpenToiletCisternButtonUnClickEvent;
        ThisObject.SetActive(false);

        CisternOpend = false;
    }

    // Update is called once per frame
    void Update()
    {
        FirstMainCharacterCamera = GameObject.Find("FirstMainCharacterCamera").GetComponent<Camera>();

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

        RayFromMouse = FirstMainCharacterCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(RayFromMouse, out RayFromMouseHitedObjects))
        {
            if (ButtonPresed && RayFromMouseHitedObjects.transform.position.ToString() == new Vector3(1.2f, 1.4f, -0.98f).ToString())
            {
                PutItemIntoToiletButtonEvent?.Invoke();
                Debug.Log("PutItemIntoToiletButtonEvent");
            }
        }

    }

    void WhenCharecterNearToiletEvent()
    {
        if (CisternOpend)
        {
            ThisObject.SetActive(true);
            TimerForEventTime = 0.0f;   
        }
    }

    void WhenOpenToiletCisternButtonUnClickEvent()
    {
        CisternOpend = true;
    }
}

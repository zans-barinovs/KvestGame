using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptForOpenToiletCisternButton : MonoBehaviour
{
    public delegate void OpenToiletCisternButtonUnClick();
    public static event OpenToiletCisternButtonUnClick OpenToiletCisternButtonUnClickEvent;


    public GameObject ThisObject;

    private float WaitForEventTime = 0.1f;
    private float TimerForEventTime = 0.0f;

    private float MaxPresedButtonTime = 0.1f;
    private float TimerForMaxPresedButtonTime = 0.0f;

    private bool ButtonPresed;

    Ray RayFromMouse;
    RaycastHit RayFromMouseHitedObjects;

    private Camera FirstMainCharacterCamera;


    // Start is called before the first frame update
    void Start()
    {
        CharacterNearToiletScript.CharecterNearToiletEvent += WhenCharecterNearToiletEvent;
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
            Debug.Log("also good");
            TimerForMaxPresedButtonTime = 0.0f;
            ButtonPresed = true;
        }

        FirstMainCharacterCamera = GameObject.FindGameObjectWithTag("FirstMainCharacterCamera").GetComponent<Camera>() as Camera;

        RayFromMouse = FirstMainCharacterCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(RayFromMouse, out RayFromMouseHitedObjects))
        {
            if (ButtonPresed && (RayFromMouseHitedObjects.transform.position.ToString() == new Vector3(1.0f, 1.4f, -0.6f).ToString()))
            {
                Debug.Log("goood");
                OpenToiletCisternButtonUnClickEvent?.Invoke();
                Debug.Log("OpenToiletCisternButtonUnClickEventt");
            }
        }

    }

    void WhenCharecterNearToiletEvent()
    {
        ThisObject.SetActive(true);
        TimerForEventTime = 0.0f;
    }
}

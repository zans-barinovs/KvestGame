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
            TimerForMaxPresedButtonTime = 0.0f;
            ButtonPresed = true;
        }

        RayFromMouse = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(RayFromMouse, out RayFromMouseHitedObjects))
        {
            if (ButtonPresed && RayFromMouseHitedObjects.transform.position.ToString() == new Vector3(1.0f, 1.4f, -0.6f).ToString())
            {
                OpenToiletCisternButtonUnClickEvent?.Invoke();
                Debug.Log("OpenToiletCisternButtonUnClickEventt");
                //Hide button:
                ThisObject.GetComponent<SpriteRenderer>().enabled = false;
            }
        }

    }

    void WhenCharecterNearToiletEvent()
    {
        ThisObject.SetActive(true);
        TimerForEventTime = 0.0f;
    }
}

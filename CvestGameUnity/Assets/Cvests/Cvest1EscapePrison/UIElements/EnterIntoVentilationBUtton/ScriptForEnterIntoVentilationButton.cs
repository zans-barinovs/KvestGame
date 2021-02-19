using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptForEnterIntoVentilationButton : MonoBehaviour
{
    public GameObject ThisObject;

    private float WaitForEventTime = 2.0f;
    private float TimerForEventTime = 0.0f;

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

        if (TimerForEventTime > WaitForEventTime)
        {
            ThisObject.SetActive(false);
        }
    }

    void WhenCharecterNearVentilationEnterSegment()
    {
        Debug.Log("WhenCharecterNearVentilationEnterSegment");
        ThisObject.SetActive(true);
        TimerForEventTime = 0.0f;
    }
}

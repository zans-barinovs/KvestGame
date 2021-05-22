using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetItemFromToiletScript : MonoBehaviour
{
    public delegate void GetItemFrpmToiletCistermnEnetsDeligate();
    public static event GetItemFrpmToiletCistermnEnetsDeligate GetItemFromToiletCistermnEvnet;


    public GameObject ThisObject;
    public GameObject player;

    private float WaitForEventTime = 0.1f;
    private float TimerForEventTime = 0.0f;

    private float MaxPresedButtonTime = 0.1f;
    private float TimerForMaxPresedButtonTime = 0.0f;

    private bool ButtonPresed;

    Ray RayFromMouse;
    RaycastHit RayFromMouseHitedObjects;

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
            if (ButtonPresed && RayFromMouseHitedObjects.transform.position.ToString() == new Vector3(1.2f, 1.4f, -0.23f).ToString())
            {
                GetItemFromToiletCistermnEvnet?.Invoke();
                Debug.Log("GetItemFromToiletCistermnEvnet");

                //Get Item:
                player = GameObject.Find("Player(Clone)");
                player.GetComponent<TakeSomething>().Take();
                player.GetComponent<TakeSomething>().item = "Wrench";
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeSomething : MonoBehaviour
{
    public string item;
    public GameObject inHands;
    public GameObject hand;
    public GameObject place;
    public GameObject model;
    public bool ok = false;

    private void Start()
    {
        hand = GameObject.Find("Hand");
        model = GameObject.Find("FirstCharecterRun");
    }

    public void Take()
    {
        ok = true;
    }
    public void Update()
    {
        if (ok)
        {
            if (item == "Wrench")
            {
                inHands = GameObject.Find("wrench");
                inHands.transform.position = hand.transform.position;
                inHands.GetComponent<ObjectsRotation>().enabled = true;
                model.GetComponent<Animator>().SetBool("isWithSomething", true);
            }
        }
        else
        {

        }
    }

    public void Put()
    {
        if (item == "Wrench")
        {
            ok = false;
            model.GetComponent<Animator>().SetBool("isWithSomething", false);
            inHands.GetComponent<ObjectsRotation>().enabled = false;
            inHands.transform.position = new Vector3(1.45f, 0.8400002f, -0.45f);
            inHands.transform.rotation = Quaternion.Euler(-66.23f, 7.913f, -97.786f);
            item = "";
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHangItemScript : MonoBehaviour
{
    private string HangingItemName;

    private GameObject ItemToHang;
    private GameObject PlayersHand;
    private GameObject model;

    private bool IsHangingItem = false;

    private void Start()
    {
        Debug.Log("OH no");
        PlayersHand = GameObject.Find("Hand");
        model = GameObject.Find("FirstCharecterRun");

        GetItemFromToiletScript.GetItemFromToiletCistermnEvnet += WhenGetItemFromToiletCistermnEvnet;
    }

    public void Update()
    {
        if (IsHangingItem)
        {
            if (HangingItemName == "Wrench")
            {
                ItemToHang = GameObject.Find("wrench");
                ItemToHang.transform.position = PlayersHand.transform.position;
                ItemToHang.transform.rotation = PlayersHand.transform.rotation;
                // ItemToHang.GetComponent<ObjectsRotation>().enabled = true;
                model.GetComponent<Animator>().SetBool("IsHangingItem", true);
            }
        }
    }

    public void PutItem()
    {
        if (HangingItemName == "Wrench")
        {
            IsHangingItem = false;
            model.GetComponent<Animator>().SetBool("IsHangingItem", false);
            // ItemToHang.GetComponent<ObjectsRotation>().enabled = false;
            ItemToHang.transform.position = new Vector3(1.45f, 0.8400002f, -0.45f);
            ItemToHang.transform.rotation = Quaternion.Euler(-66.23f, 7.913f, -97.786f);
            HangingItemName = "";
        }
    }

    public void WhenGetItemFromToiletCistermnEvnet()
    {
        Debug.Log("WhenGetItemFromToiletCistermnEvnet");
        IsHangingItem = true;
        HangingItemName = "Wrench";
    }
}

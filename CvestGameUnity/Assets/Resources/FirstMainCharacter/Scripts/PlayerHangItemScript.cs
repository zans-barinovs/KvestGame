using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHangItemScript : MonoBehaviour
{
    private string HangingItemName;

    private GameObject ItemToHang;
    private GameObject PlayersHand;
    private GameObject model;

    public bool IsHangingItem = false;

    private void Start()
    {
        PlayersHand = GameObject.FindWithTag("Hand");
        model = GameObject.FindWithTag("FirstCharecterRun");
    }

    public void Update()
    {
        if (IsHangingItem)
        {
            if (HangingItemName == "Wrench")
            {
                ItemToHang = GameObject.FindWithTag("wrench");
                ItemToHang.transform.position = PlayersHand.transform.position;
                ItemToHang.GetComponent<ObjectsRotation>().enabled = true;
                model.GetComponent<Animator>().SetBool("IsHangingItem", true);
            }
        }
    }

    public void Take()
    {
        IsHangingItem = true;
    }

    public void Put()
    {
        if (HangingItemName == "Wrench")
        {
            IsHangingItem = false;
            model.GetComponent<Animator>().SetBool("IsHangingItem", false);
            ItemToHang.GetComponent<ObjectsRotation>().enabled = false;
            ItemToHang.transform.position = new Vector3(1.45f, 0.8400002f, -0.45f);
            ItemToHang.transform.rotation = Quaternion.Euler(-66.23f, 7.913f, -97.786f);
            HangingItemName = "";
        }
    }
}

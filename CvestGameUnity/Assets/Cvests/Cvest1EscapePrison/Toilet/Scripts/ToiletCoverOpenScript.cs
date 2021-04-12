using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToiletCoverOpenScript : MonoBehaviour
{
    public GameObject ThisObjext;
    private Transform ComponentTransform;

    void Start()
    {
        ScriptForOpenToiletCisternButton.OpenToiletCisternButtonUnClickEvent += WhenOpenToiletCisternButtonUnClickEvent;
        ComponentTransform = gameObject.GetComponent<Transform>();
    }

    void Update()
    {
        
    }

    private void WhenOpenToiletCisternButtonUnClickEvent()
    {
        Debug.Log("WhenOpenToiletCisternButtonUnClickEvent");
        // ThisObjext.transform.position = new Vector3(0f, 0f, 1f);
    }
}
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VentilationEnterScript : MonoBehaviour
{
    public delegate void CharecterNearVentilationEnterSegmentDelegate();
    public static event CharecterNearVentilationEnterSegmentDelegate CharecterNearVentilationEnterSegment;

    private float MaxWorkingDistanceToCharecter = 1.5f; //это расстояние при котором MainCharacterNearVentelation

    private float DistanceToCharacter;
    private bool CharecterIsNear = false;

    private GameObject MainCharacter;
    public GameObject EnterPlacePoint;

    private Transform EnterPlacePointTransform;
    private Transform MainCharacterTransform;

    private Vector3 EnterPlacePointVector3;
    private Vector3 MainCharacterVector3;

    private int UpdateCounter;

    void Start()
    {
        MainCharacter = GameObject.FindWithTag("FirstMainCharacter");

        EnterPlacePointTransform = EnterPlacePoint.GetComponent<Transform>();
    }

    void Update()
    {
        if ((int)UpdateCounter>(int)3)
        {
            EnterPlacePointTransform = EnterPlacePoint.GetComponent<Transform>();
            MainCharacterTransform = GameObject.FindWithTag("FirstMainCharacter").transform;

            EnterPlacePointVector3 = new Vector3(EnterPlacePointTransform.position.x, EnterPlacePointTransform.position.y, EnterPlacePointTransform.position.z);
            MainCharacterVector3 = new Vector3(MainCharacterTransform.position.x, MainCharacterTransform.position.y, MainCharacterTransform.position.z);

            DistanceToCharacter = Vector3.Distance(EnterPlacePointVector3, MainCharacterVector3);

            if (DistanceToCharacter < MaxWorkingDistanceToCharecter) {
                CharecterIsNear = true;
                //Debug.Log("CharecterIsNear = true");
                CharecterNearVentilationEnterSegment?.Invoke();
            }
            else
            {
                CharecterIsNear = false;
            }
        }
        else
        {
            UpdateCounter++;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VentilationEnterScript : MonoBehaviour
{
    public delegate void CharecterNearVentilationEnterSegmentDelegate();
    public static event CharecterNearVentilationEnterSegmentDelegate CharecterNearVentilationEnterSegment;

    private float MaxWorkingDistanceToCharecter = 2f; //это расстояние при котором MainCharacterNearVentelation

    private float DistanceToCharacter;
    private bool CharecterIsNear = false;

    private GameObject MainCharacter;
    public GameObject EnterPlacePoint;

    private Transform EnterPlacePointTransform;
    private Transform MainCharacterTransform;

    private Vector3 EnterPlacePointVector3;
    private Vector3 MainCharacterVector3;

    void Start()
    {
        MainCharacter = GameObject.FindWithTag("FirstMainCharacter");

        EnterPlacePointTransform = EnterPlacePoint.GetComponent<Transform>();
        MainCharacterTransform = MainCharacter.GetComponent<Transform>();
    }

    void Update()
    {
        Debug.Log("Update");
        EnterPlacePointTransform = EnterPlacePoint.GetComponent<Transform>();
        Debug.Log("Update0");
        MainCharacterTransform = GameObject.FindWithTag("FirstMainCharacter").transform;

        Debug.Log("Update1");

        EnterPlacePointVector3 = new Vector3(EnterPlacePointTransform.position.x, EnterPlacePointTransform.position.y, EnterPlacePointTransform.position.z);
        MainCharacterVector3 = new Vector3(MainCharacterTransform.position.x, MainCharacterTransform.position.y, MainCharacterTransform.position.z);

        Debug.Log("Update2");

        DistanceToCharacter = Vector3.Distance(EnterPlacePointVector3, MainCharacterVector3);
        Debug.Log("EnterPlacePointVector3: " + EnterPlacePointVector3);
        Debug.Log("MainCharacterVector3: " + MainCharacterVector3);

        Debug.Log("Update3");

        if (DistanceToCharacter < MaxWorkingDistanceToCharecter) {
            CharecterIsNear = true;
            Debug.Log("CharecterIsNear = true");
            CharecterNearVentilationEnterSegment?.Invoke();
        }
        else
        {
            CharecterIsNear = false;
        }

        Debug.Log("Update4");
    }
}

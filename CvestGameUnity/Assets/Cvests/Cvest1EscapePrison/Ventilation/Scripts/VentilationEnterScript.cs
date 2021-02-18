using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VentilationEnterScript : MonoBehaviour
{
    public delegate void CharecterNearVentilationEnterSegmentDelegate();
    public static event CharecterNearVentilationEnterSegmentDelegate CharecterNearVentilationEnterSegment;

    private float DistanceToCharacter;
    private bool CharecterIsNear = false.
    public GameObject MainCharacter;
    public GameObject EnterPlacePoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DistanceToCharacter = Vector3.Distance(MainCharacter.transform.position, EnterPlacePoint.transform.position);
        if (DistanceToCharacter < (float)1) {
            CharecterIsNear = true;
            CharecterNearVentilationEnterSegment?.Invoke();
        }
        else
        {
            CharecterIsNear = false;
        }
    }
}

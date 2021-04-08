using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BiasSet : MonoBehaviour
{
    private float ThisObjectBias;
    // Start is called before the first frame update
    void Start()
    {
        ThisObjectBias = gameObject.GetComponent<Light>().shadowBias;
        ThisObjectBias = 1f;
        gameObject.GetComponent<Light>().shadowBias = -0.03f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

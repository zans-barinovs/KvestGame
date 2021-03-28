using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Text_Spawn : MonoBehaviour
{
    public GameObject GameOverText;
    public GameObject Spaner;

    void Start()
    {
        GameOverText.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Spaner.SetActive(true);
        }
        GameOverText.SetActive(true);
    }
    private void OnTriggerExit(Collider other)
    {
        GameOverText.SetActive(false);
    }
}

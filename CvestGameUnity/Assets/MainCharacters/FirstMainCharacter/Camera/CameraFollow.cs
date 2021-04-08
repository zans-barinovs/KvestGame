using System;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Parameters")]
    [SerializeField] public Transform playerTransform;
    [SerializeField] private float movingSpeed;
    [SerializeField] public GameObject player;

    private void Awake()
    {

        this.transform.position = new Vector3()
        {
            x = this.playerTransform.position.x,
            y = this.playerTransform.position.y + 5,
            z = this.playerTransform.position.z,
        };

        if (this.playerTransform == null)
        {
            playerTransform = player.GetComponent<Transform>();
        }
    }

    private void Update()
    {
        if(this.playerTransform)
        {
            Vector3 target = new Vector3()
            {
                x = this.playerTransform.position.x,
                y = this.playerTransform.position.y + 5,
                z = this.playerTransform.position.z,
            };

            Vector3 pos = Vector3.Lerp(a: this.transform.position, b: target, t: this.movingSpeed * Time.deltaTime);

            this.transform.position = pos;
        }
    }
}

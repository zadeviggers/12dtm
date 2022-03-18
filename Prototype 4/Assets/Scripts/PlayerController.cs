using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private GameObject cameraFocusPoint;
    private Rigidbody playerRB;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        cameraFocusPoint = GameObject.Find("CameraFocusPoint");
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        playerRB.AddForce(cameraFocusPoint.transform.forward * speed * forwardInput);
    }
}

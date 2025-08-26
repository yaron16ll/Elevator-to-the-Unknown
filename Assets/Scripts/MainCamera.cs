using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public float forwardSpeed = 10;
    public float forwardScrollSpeed = 10;
    public float panSpeed = 10;
    public float rotateSpeed = 360; // degrees per second

    private Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        float panVerticalInput = Input.GetAxis("PanVertical");

        cam.transform.position += cam.transform.forward * verticalInput * forwardSpeed * Time.deltaTime;
        cam.transform.position += cam.transform.right * horizontalInput * panSpeed * Time.deltaTime;
        cam.transform.position += cam.transform.up * panVerticalInput * panSpeed * Time.deltaTime;


        if (Input.GetMouseButton(0) || Input.GetMouseButton(1))
        {
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");
            transform.eulerAngles += new Vector3(-mouseY, mouseX, 0) * rotateSpeed * Time.deltaTime;
        }

        float mouseScroll = Input.GetAxis("Mouse ScrollWheel");
        cam.transform.position += cam.transform.forward * mouseScroll * forwardScrollSpeed;

    }
}

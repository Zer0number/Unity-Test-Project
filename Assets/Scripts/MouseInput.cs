using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseInput : MonoBehaviour
{
    float xRotation;
    public float mouseSensitivity = 100f;
    public Transform playerBody;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // float mouseX = Input.GetAxis("Mouse X");
        // float mouseY = Input.GetAxis("Mouse Y");

        float mouseX = 0;
        float mouseY = 0;

        if(Mouse.current != null)
        {
            mouseX = Mouse.current.delta.ReadValue().x;
            mouseY = Mouse.current.delta.ReadValue().y;
        }

        // if(Gamepad.current != null){
        //     mouseX = Gamepad.current.rightStick.ReadValue().x;
        //     mouseY = Gamepad.current.leftStick.ReadValue().y;
        // }



        mouseX *= mouseSensitivity;
        mouseY *= mouseSensitivity;

        xRotation -= mouseY * Time.deltaTime;
        xRotation = Mathf.Clamp(xRotation, -80, 80);
        
        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        playerBody.Rotate(Vector3.up * mouseX * Time.deltaTime);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 150f;

    public Transform playerBody;

    float xRotation = 0f;

    private string directoryName = "Screenshots";

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Screenshot"))
        {

            TakeScreenShot();
        }

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
    void TakeScreenShot()
    {
        string fileName = DateTime.Now.ToString("dd-MM-yyyy HHmmss") + ".jpg";
        DirectoryInfo screenshotDirectory = Directory.CreateDirectory(directoryName);
        string screenshotPath = Path.Combine(screenshotDirectory.FullName, fileName);
        Debug.Log(screenshotPath);
        ScreenCapture.CaptureScreenshot(screenshotPath);
    }
}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;

public class Snapshot : MonoBehaviour
{
    public string directoryName = "Screenshots";
    public void TakeScreenShot()
    {
        string fileName = DateTime.Now.ToString("dd-MM-yyyy HHmmss");
        DirectoryInfo screenshotDirectory = Directory.CreateDirectory(directoryName);
        string screenshotPath = Path.Combine(screenshotDirectory.FullName, fileName);

        ScreenCapture.CaptureScreenshot(screenshotPath);
    }
}
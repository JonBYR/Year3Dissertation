using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ScreenShotSaver : MonoBehaviour
{
    int numberOfScreenshots = 0;
    string screenshotName = "FilmScreenshot";
    void Start()
    {
        string[] existingScreenshots = Directory.GetFiles("ExampleScreenshots"); //Get all files in the existing directory and remove them 
        foreach (string e in existingScreenshots)
        {
            File.Delete(e); //https://www.csharp-examples.net/delete-all-files/
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            numberOfScreenshots++;
            string screenshotPng = screenshotName + numberOfScreenshots.ToString() + ".png";
            ScreenCapture.CaptureScreenshot(Path.Combine("ExampleScreenshots", screenshotPng));
            Debug.Log("Screenshot Taken");
        }
    }
}

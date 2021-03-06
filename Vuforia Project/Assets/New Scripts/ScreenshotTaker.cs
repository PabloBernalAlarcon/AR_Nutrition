﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenshotTaker : MonoBehaviour
{
    public bool takingScreenshot = false;
    [SerializeField]
    GameObject RegularCanvas;
    [SerializeField]
    GameObject RocketCanvas;
    public void CaptureScreenshot()
    {
        StartCoroutine(TakeScreenshotAndSave());
    }

    private IEnumerator TakeScreenshotAndSave()
    {
        bool dontdoit = false;

        takingScreenshot = true;
        RegularCanvas.SetActive(false);
        if (RocketCanvas)
            RocketCanvas.SetActive(false);
        else
            dontdoit = true;
        yield return new WaitForEndOfFrame();

        Texture2D ss = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        ss.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        ss.Apply();
        
        // Save the screenshot to Gallery/Photos
        string name = string.Format("{0}_Capture{1}_{2}.png", Application.productName, "{0}", System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));
        print("Permission result: " + NativeGallery.SaveImageToGallery(ss, Application.productName + " Captures", name));
        takingScreenshot = false;
        RegularCanvas.SetActive(true);
        if (!dontdoit)
            RocketCanvas.SetActive(true);
    }
}

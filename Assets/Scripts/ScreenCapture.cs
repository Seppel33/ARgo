﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARCore;

public class ScreenCapture : MonoBehaviour
{
    private Camera arCamera;
    private static ScreenCapture instance;
    private bool takeScreenshotOnNextframe;

    private void Awake()
    {
        //Speichert die Kamera in einer Variable
        arCamera = gameObject.GetComponent<Camera>();
    }

    private void OnPostRender()
    {
        if (takeScreenshotOnNextframe)
        {
            //Erster Versuch die Screenshots zu speichern, bevor Methode mit Sharing gefunden wurde
            takeScreenshotOnNextframe = false;
            RenderTexture renderTexture = arCamera.targetTexture;
            
            Texture2D renderResult = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.ARGB32, false);
            Rect rect = new Rect(0,0, renderTexture.width, renderTexture.height);
            renderResult.ReadPixels(rect, 0, 0);

            byte[] byteArray = renderResult.EncodeToPNG();
            System.IO.File.WriteAllBytes(Application.dataPath + "/ARgoScreenshot.png", byteArray);
            Debug.Log("ARgo-Screenshot wurde aufgenommen");
            
            RenderTexture.ReleaseTemporary(renderTexture);
            arCamera.targetTexture = null;
        }
    }

    public void TakeScreenshot()
    {
        arCamera.targetTexture = RenderTexture.GetTemporary(arCamera.pixelWidth, arCamera.pixelHeight, 16);
        takeScreenshotOnNextframe = true;
    }
    
    public void CaptureScreenshot() {
        D.Log("Der Screenshot wurde gespeichert in: " + Application.persistentDataPath);
        
        UnityEngine.ScreenCapture.CaptureScreenshot("TestScreenshot.png");
    }
}



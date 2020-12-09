using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Sharing : MonoBehaviour
{
    private string shareMessage;
    public void ShareButton()
    {
        shareMessage = "Schau mal was ich mit den ARgonauten erlebt habe!";
        StartCoroutine(TakeScreenshotAndShare());
    }
    
    private IEnumerator TakeScreenshotAndShare()
    {
        yield return new WaitForEndOfFrame();

        Texture2D ss = new Texture2D( Screen.width, Screen.height, TextureFormat.RGB24, false );
        ss.ReadPixels( new Rect( 0, 0, Screen.width, Screen.height ), 0, 0 );
        ss.Apply();

        string filePath = Path.Combine( Application.temporaryCachePath, "shared img.png" );
        File.WriteAllBytes( filePath, ss.EncodeToPNG() );

        // To avoid memory leaks
        Destroy( ss );

        new NativeShare().AddFile( filePath )
            .SetSubject("ARgo").SetText(shareMessage)
            .SetCallback( ( result, shareTarget ) => Debug.Log( "Share result: " + result + ", selected app: " + shareTarget ) )
            .Share();
    }
}

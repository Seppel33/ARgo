using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Sharing : MonoBehaviour
{
    private string shareMessage;
    public void ShareButton()
    {
        //Nachricht, welche beim Absenden des Screenshots mitgegeben wird
        shareMessage = "Schau mal was ich mit den ARgonauten erlebt habe!";
        StartCoroutine(TakeScreenshotAndShare());
    }
    
    private IEnumerator TakeScreenshotAndShare()
    {
        yield return new WaitForEndOfFrame();

        Texture2D ss = new Texture2D( Screen.width, Screen.height, TextureFormat.RGB24, false );
        ss.ReadPixels( new Rect( 0, 0, Screen.width, Screen.height ), 0, 0 );
        ss.Apply();

        //Speichert das Bild auf dem Gerät
        string filePath = Path.Combine( Application.temporaryCachePath, "shared img.png" );
        //Als png
        File.WriteAllBytes( filePath, ss.EncodeToPNG() );

        //Gibt speicher wieder frei
        Destroy( ss );

        //Verwendet Nativeshare Skript um das Bild über die Android gängigen Apps zu teilen
        new NativeShare().AddFile( filePath )
            .SetSubject("ARgo").SetText(shareMessage)
            .SetCallback( ( result, shareTarget ) => Debug.Log( "Share result: " + result + ", selected app: " + shareTarget ) )
            .Share();
    }
}

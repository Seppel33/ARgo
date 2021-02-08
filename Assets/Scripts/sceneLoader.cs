using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneLoader : MonoBehaviour
{
    AsyncOperation loadingOperation;

    //Die General Scene wird im Hintergrund geladen, während die Startbildschirm Szene die Animation abspielt
    public void loadGeneral(){
        loadingOperation = SceneManager.LoadSceneAsync("GeneralScene", LoadSceneMode.Single);

        if(loadingOperation.isDone){
            SceneManager.SetActiveScene(SceneManager.GetSceneByName("GeneralScene"));
        }
    }
}

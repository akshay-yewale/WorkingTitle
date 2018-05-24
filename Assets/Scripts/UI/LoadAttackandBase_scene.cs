using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LoadAttackandBase_scene : MonoBehaviour
{

     void Update()
    {
        // Press the space key to start coroutine
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Use a coroutine to load the Scene in the background
            StartCoroutine(LoadYourAsyncScene());
        }
    }

    IEnumerator LoadYourAsyncScene()
    {
       

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Base 1");

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
    
    public void SceneLoader(int SceneIndex)
    {
        SceneManager.LoadScene(SceneIndex);
        

    }
}

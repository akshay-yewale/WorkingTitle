using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BaseLoadingScript : MonoBehaviour
{
    public string LoadingSceneName;


    [Header("DEBUG ONLY- REMOVE IN BUILD")]
    [SerializeField]
    private float f_WaitTime_Debug = 10.0f;
    private bool loadScene = false;

    // Use this for initialization
    void Start(){
    }

    // Update is called once per frame
    void Update(){
     
        // If the player has pressed the space bar and a new scene is not loading yet...
        if (Input.GetKeyUp(KeyCode.Space) && loadScene == false)
        {
            // ...set the loadScene boolean to true to prevent loading a new scene more than once...
            loadScene = true;

            // ...and start a coroutine that will load the desired scene.
            StartCoroutine(LoadNewScene(LoadingSceneName));
            
        }
        StartCoroutine(Waiting());
        //Invoke("WaitingMethod", 10f);
    }

    IEnumerator Waiting()
    {
        yield return new WaitForSeconds(f_WaitTime_Debug);
    }
    /*
    void WaitingMethod()
    {
        SceneManager.LoadScene(LoadingSceneName);
    }
    */

    // The coroutine runs on its own at the same time as Update() and takes an integer indicating which scene to load.
    IEnumerator LoadNewScene(string sceneName)
    {
        // Start an asynchronous operation to load the scene that was passed to the LoadNewScene coroutine.
        AsyncOperation async = SceneManager.LoadSceneAsync(sceneName);

        // While the asynchronous operation to load the new scene is not yet complete, continue waiting until it's done.
        while (!async.isDone)
        {
            float progress = Mathf.Clamp01(async.progress / 10.0f);

            yield return null;
        }
        //yield return WaitForSeconds(10f);
    }
}
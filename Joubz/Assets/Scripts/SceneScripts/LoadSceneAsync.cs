using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadSceneAsync : MonoBehaviour
{
    //public GameObject fadeScreen;
    public GameObject loadingScreen;
    public Slider slider;

    void Start()
    {        
        StartCoroutine(LoadScene_Coroutine("Main_Seb"));  
    }

    IEnumerator LoadScene_Coroutine(string sceneName)
    {
        // Fade to black
        yield return new WaitForSeconds(1);


        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);

        while (operation.isDone == false)
        {
            float pct = Mathf.Clamp01(operation.progress / .9f);
            slider.value = pct;

            yield return null;
        }
        SceneManager.UnloadSceneAsync("LoadSceneAsync");
        loadingScreen.SetActive(false);
        
    }
}

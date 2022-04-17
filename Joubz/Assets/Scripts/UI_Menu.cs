using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Menu : MonoBehaviour
{ 
    public void Play()
    {
        SceneManager.LoadScene("LoadSceneAsync", LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync("Scene_UI");
    }

    public void Quit()
    {
        Application.Quit();
    }
}

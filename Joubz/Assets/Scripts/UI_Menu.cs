using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class UI_Menu : MonoBehaviour
{
    public void Start()
    {
        GameObject.Find("EventSystem").GetComponent<EventSystem>().firstSelectedGameObject = GameObject.Find("Play");
        GameObject.Find("EventSystem").GetComponent<EventSystem>().SetSelectedGameObject(GameObject.Find("Play"));
    }
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

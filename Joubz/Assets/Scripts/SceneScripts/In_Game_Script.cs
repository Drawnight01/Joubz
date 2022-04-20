using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class In_Game_Script : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("EventSystem").GetComponent<EventSystem>().firstSelectedGameObject = GameObject.Find("Continue");
        GameObject.Find("EventSystem").GetComponent<EventSystem>().SetSelectedGameObject(GameObject.Find("Continue"));
    }

    public void Continue()
    {
        SceneManager.UnloadSceneAsync("In_Game");
    }

    public void Menu()
    {
        SceneManager.LoadSceneAsync("Scene_Ui", LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync("In_Game");
        SceneManager.UnloadSceneAsync("Stairs");
    }

    
}

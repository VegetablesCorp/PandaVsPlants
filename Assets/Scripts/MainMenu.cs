using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    void OnMouseUpAsButton()
    {
        switch(gameObject.name)
        {
            case "play_button": SceneManager.LoadScene("Level1");break;
            case "ranking_button": Debug.Log("Ranking");break;
            case "shop_button": Debug.Log("Shop"); break;
            case "set_button": Debug.Log("Settings"); break;
            case "exit_button": Debug.Log("Exit"); break;
            case "return": SceneManager.LoadScene(SceneManager.GetActiveScene().name); break;
            case "home": SceneManager.LoadScene("MainMenu"); break;
            case "check": Debug.Log("Next Level"); break;
        }
    }
}

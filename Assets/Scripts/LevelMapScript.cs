using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMapScript : MonoBehaviour
{
public void OnMouseUpAsButton()
    {
        Debug.Log("plod");
        Debug.Log(gameObject.name);
        switch (gameObject.name)
        {
            case "Level1":
                {
                    Debug.Log("jk");
                    SceneManager.LoadScene(2); break;
                }
            case "Level2":
                {
                    Debug.Log("jk");
                    SceneManager.LoadScene(3); break;
                }
            case "Level3":
                {
                    Debug.Log("jk");
                    SceneManager.LoadScene(4); break;
                }
            case "Level4":
                {
                    Debug.Log("jk");
                    SceneManager.LoadScene(5); break;
                }
            case "Level5":
                {
                    Debug.Log("jk");
                    SceneManager.LoadScene(6); break;
                }
        }
    }
}

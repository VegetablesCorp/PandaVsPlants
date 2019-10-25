using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMapScript : MonoBehaviour
{
   public void OnMouseUpAsButton()
    {
        switch (gameObject.name)
        {
            case "Level 1":
                {
                    Debug.Log("jk");
                    SceneManager.LoadScene(2); break;
                }
            case "Level 2":
                {
                    Debug.Log("jk");
                    SceneManager.LoadScene(3); break;
                }
            case "Level 3":
                {
                    Debug.Log("jk");
                    SceneManager.LoadScene(4); break;
                }
            case "Level 4":
                {
                    Debug.Log("jk");
                    SceneManager.LoadScene(5); break;
                }
            case "Level 5":
                {
                    Debug.Log("jk");
                    SceneManager.LoadScene(6); break;
                }
        }
    }
}

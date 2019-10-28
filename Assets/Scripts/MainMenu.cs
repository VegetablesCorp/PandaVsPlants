using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    Scene scene;
    public SystemControlScript SystemControl;
    public GameObject PanelPause;
    private bool paused = false;

    void OnMouseUpAsButton()
    {
        switch (gameObject.name)
        {
            case "play_button":
                {
                    SceneManager.LoadScene(1); break;
                }

            case "ranking_button":
                {
                    Debug.Log("Ranking"); break;
                }

            case "shop_button":
                {
                    Debug.Log("Shop"); break;
                }

            case "set_button":
                {
                    Debug.Log("Settings"); break;
                }

            case "exit_button":
                {
                    Debug.Log("Exit");
                    Application.Quit();
                    break;
                }
            case "return":
                {
                    SystemControl.setPause(false);
                    Time.timeScale = 1;
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name); break;
                }
            case "home":
                {
                    SystemControl.setPause(false);
                    Time.timeScale = 1;
                    SceneManager.LoadScene("MainMenu"); break;
                }
            case "pauseButton":
                {
                    Time.timeScale = 0;
                    SystemControl.setPause(true);
                    PanelPause.SetActive(true);
                    paused = SystemControl.getPause();
                    Debug.Log(paused);
                    break;
                }
            case "check":
                {
                    paused = SystemControl.getPause();
                    if (paused == true)
                    {
                        Time.timeScale = 1;
                        Debug.Log("paused = true");
                        SystemControl.setPause(false);
                        PanelPause.SetActive(false);
                        
                    }
                    else 
                        {
                        scene = SceneManager.GetActiveScene();
                        int sceneIndex = scene.buildIndex;
                        sceneIndex++;
                        if (sceneIndex > 5)
                           {
                              sceneIndex = 0;
                           }
                        SceneManager.LoadScene(sceneIndex);
                       }
                    break;
                }
                
        }
    }
}

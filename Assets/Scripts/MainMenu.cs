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

    private Animator anim;

    private bool startAnim = false;
    private bool endAnim = false;

    private void EndAnimation() {
       endAnim = true;
    }

    void OnMouseUpAsButton()
    {
        endAnim = false;

        anim = gameObject.GetComponent<Animator>();
        
        Debug.Log(gameObject);

        startAnim = true;
        anim.SetBool("StartAnim", startAnim);

        StartCoroutine(ButtonPlay());
    }
    IEnumerator ButtonPlay()
    {
        while (endAnim == false)
        {
            yield return null;
        }
        startAnim = false;
        anim.SetBool("StartAnim", startAnim);

        switch(gameObject.name)
        {
            case "play_button":
                {
                    SceneManager.LoadScene(1);
                    break;
                }

            case "ranking_button":
                {
                    Debug.Log("Ranking");
                    break;
                }

            case "shop_button":
                {
                    Debug.Log("Shop");
                    break;
                }

            case "set_button":
                {
                    Debug.Log("Settings");
                    break;
                }

            case "exit_button":
                {
                    Debug.Log("Exit");
                    Application.Quit();
                    break;
                }
            case "return":
                {
                    Time.timeScale = 1;
                    SystemControl.setPause(false);
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                    break;
                }
            case "home":
                {
                    Time.timeScale = 1;
                    SystemControl.setPause(false);
                    SceneManager.LoadScene("MainMenu");
                    break;
                }
            case "pauseButton":
                {
                    Time.timeScale = 0;
                    SystemControl.setPause(true);
                    PanelPause.SetActive(true);
                    paused = SystemControl.getPause();
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
                        if (sceneIndex > 6)
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

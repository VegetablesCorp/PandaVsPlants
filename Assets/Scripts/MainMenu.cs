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

    private float lenghtAnimation;


 

    void OnMouseUpAsButton()
    {
        Animation animation = GetComponent<Animation>();
       
        switch (gameObject.name)
        {
            
            case "play_button":
                {
                    animation.Play("AnimationPlay");
                    lenghtAnimation = animation.clip.length;
                    StartCoroutine(ButtonPlay(lenghtAnimation));
                    break;
                }

            case "ranking_button":
                {
                    animation.Play("ButtonAnimation");
                    lenghtAnimation = animation.clip.length;
                    StartCoroutine(RankingButton(lenghtAnimation));
                    break;
                }

            case "shop_button":
                {
                    animation.Play("ButtonAnimation");
                    lenghtAnimation = animation.clip.length;
                    StartCoroutine(ShopButton(lenghtAnimation));
                    break;
                }

            case "set_button":
                {
                    animation.Play("ButtonAnimation");
                    lenghtAnimation = animation.clip.length;
                    StartCoroutine(SetButton(lenghtAnimation));
                    break;
                }

            case "exit_button":
                {
                    animation.Play("ButtonAnimation");
                    lenghtAnimation = animation.clip.length;
                    StartCoroutine(ExitButton(lenghtAnimation));
                    break;
                }
            case "return":
                {
                    animation.Play("ButtonsWinLooseAnimation");
                    lenghtAnimation = animation.clip.length;
                    StartCoroutine(ReturnButton(lenghtAnimation));
                    break;
                }
            case "home":
                {
                    animation.Play("ButtonsWinLooseAnimation");
                    lenghtAnimation = animation.clip.length;
                    StartCoroutine(HomeButton(lenghtAnimation));
                     break;
                }
            case "pauseButton":
                {
                    animation.Play("PauseAnimation");
                    lenghtAnimation = animation.clip.length;
                    StartCoroutine(PauseButton(lenghtAnimation));
                    break;
                }
            case "check":
                {
                    animation.Play("ButtonsWinLooseAnimation");
                    lenghtAnimation = animation.clip.length;
                    StartCoroutine(CheckButton(lenghtAnimation));
                    break;
                }
                
        }
    }
    IEnumerator ButtonPlay(float lenghtAnimation)
    {
        yield return new WaitForSeconds(lenghtAnimation);
        SceneManager.LoadScene(1);
    }

    IEnumerator RankingButton(float lenghtAnimation)
    {
        yield return new WaitForSeconds(lenghtAnimation);
        Debug.Log("Ranking");
    }

    IEnumerator ShopButton(float lenghtAnimation)
    {
        yield return new WaitForSeconds(lenghtAnimation);
        Debug.Log("Shop");
    }

    IEnumerator SetButton(float lenghtAnimation)
    {
        yield return new WaitForSeconds(lenghtAnimation);
        Debug.Log("Settings");
    }

    IEnumerator ExitButton(float lenghtAnimation)
    {
        yield return new WaitForSeconds(lenghtAnimation);
        Debug.Log("Exit");
        Application.Quit();
    }

    IEnumerator ReturnButton(float lenghtAnimation)
    {
        yield return new WaitForSeconds(lenghtAnimation);
        SystemControl.setPause(false);
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    IEnumerator HomeButton(float lenghtAnimation)
    {
        yield return new WaitForSeconds(lenghtAnimation);
        SystemControl.setPause(false);
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }

    IEnumerator PauseButton(float lenghtAnimation)
    {
        yield return new WaitForSeconds(lenghtAnimation);
        Time.timeScale = 0;
        SystemControl.setPause(true);
        PanelPause.SetActive(true);
        paused = SystemControl.getPause();
        Debug.Log(paused);
    }

    IEnumerator CheckButton(float lenghtAnimation)
    {
        yield return new WaitForSeconds(lenghtAnimation);
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
    }
}

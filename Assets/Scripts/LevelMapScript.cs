using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMapScript : MonoBehaviour
{

    private float lenghtAnimation;
    public void OnMouseUpAsButton()
    {
        Animation animation = GetComponent<Animation>();

        switch (gameObject.name)
        {
            case "Level1":
                {
                    animation.Play("MapLevelAnimation");
                    lenghtAnimation = animation.clip.length;
                    StartCoroutine(ButtonLevel1(lenghtAnimation));
                    break;
                }
            case "Level2":
                {
                    animation.Play("MapLevelAnimation");
                    lenghtAnimation = animation.clip.length;
                    StartCoroutine(ButtonLevel2(lenghtAnimation));
                    break;
                }
            case "Level3":
                {
                    animation.Play("MapLevelAnimation");
                    lenghtAnimation = animation.clip.length;
                    StartCoroutine(ButtonLevel3(lenghtAnimation));
                    break;
                }
            case "Level4":
                {
                    animation.Play("MapLevelAnimation");
                    lenghtAnimation = animation.clip.length;
                    StartCoroutine(ButtonLevel4(lenghtAnimation));
                    break;
                }
            case "Level5":
                {
                    animation.Play("MapLevelAnimation");
                    lenghtAnimation = animation.clip.length;
                    StartCoroutine(ButtonLevel5(lenghtAnimation));
                    break;
                }
        }
    }

    IEnumerator ButtonLevel1(float lenghtAnimation)
    {
        yield return new WaitForSeconds(lenghtAnimation);
        SceneManager.LoadScene(2);
    }

    IEnumerator ButtonLevel2(float lenghtAnimation)
    {
        yield return new WaitForSeconds(lenghtAnimation);
        SceneManager.LoadScene(3);
    }

    IEnumerator ButtonLevel3(float lenghtAnimation)
    {
        yield return new WaitForSeconds(lenghtAnimation);
        SceneManager.LoadScene(4);
    }

    IEnumerator ButtonLevel4(float lenghtAnimation)
    {
        yield return new WaitForSeconds(lenghtAnimation);
        SceneManager.LoadScene(5);
    }

    IEnumerator ButtonLevel5(float lenghtAnimation)
    {
        yield return new WaitForSeconds(lenghtAnimation);
        SceneManager.LoadScene(6);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMapScript : MonoBehaviour
{
    private Animator anim;

    private bool startAnim = false;
    private bool endAnim = false;

    private void EndAnimation()
    {
        endAnim = true;
    }

        public void OnMouseUpAsButton()
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

        switch (gameObject.name)
        {
            case "Level1":
                {
                    SceneManager.LoadScene(2);
                    break;
                }

            case "Level2":
                {
                    SceneManager.LoadScene(3);
                    break;
                }

            case "Level3":
                {
                    SceneManager.LoadScene(4);
                    break;
                }

            case "Level4":
                {
                    SceneManager.LoadScene(5);
                    break;
                }

            case "Level5":
                {
                    SceneManager.LoadScene(6);
                    break;
                }
        }
    }

}


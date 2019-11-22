using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMapScript : MonoBehaviour
{
    private Animator anim;
    private int LevelComplete;
    private bool startAnim = false;
    private bool endAnim = false;

    private SpriteRenderer SpriteRend;
    public GameObject Levels;

    

    //private GameObject Canvas;


    private void EndAnimation()
    {
        endAnim = true;
    }

    private void Awake()
    {
        
/*
        if (PlayerPrefs.HasKey("Level")) { Debug.Log("Level № "); }
        else {
            LevelComplete = 1;
            Debug.Log("Level 1");
            PlayerPrefs.SetFloat("Level", LevelComplete); // т.к. автоматической работы 
        }

        Levels.SetActive(true);
        for (int i = 0; i < Levels.transform.childCount; i++)
            {
            SpriteRend = Levels.transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>(); // Выключаем или включаем каждого полученного ребёнка по порядку.
            var colorObject = SpriteRend.color;
            colorObject.a = 100.0f;
            }

*/
            switch (LevelComplete)
        {
            case 1:
                {

                    break;
                }
        }
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


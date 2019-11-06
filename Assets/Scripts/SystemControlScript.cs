using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemControlScript : MonoBehaviour
{
    public GameObject Lives;
    public GameObject PanelLoose;
    public GameObject PanelWin;

    private GameObject Stars;
    private GameObject Explosion;
    private Animator ExplosionAnim;

    private GameObject PandaStar;
    private Animator PandaAnim;

    private bool paused;
    private bool loose;
    private bool win;
    private int playerLives;
    private int maxPoints;
    private int playerPoints;

    private bool startAnim = false;
    private bool endAnim = false;

    private bool endCouroutine = false;
    private int op = 1;

    private void EndAnimation()
    {
        endAnim = true;
    }

    void Start()
    {
        Time.timeScale = 1;

        playerPoints = 0;
        playerLives = 3;

        loose = false;
        win = false;

        Stars = PanelWin.transform.Find("Stars").gameObject;
        Stars.SetActive(true);
        for (int i = 0; i < Stars.transform.childCount; i++)
        {
            Stars.transform.GetChild(i).gameObject.SetActive(false); // Выключаем или включаем каждого полученного ребёнка по порядку.
        }

        Explosion = Stars.transform.Find("Explosion").gameObject;

        ExplosionAnim = Explosion.GetComponent<Animator>();

        PandaStar = Stars.transform.Find("pandaStar1").gameObject;
        PandaAnim = PandaStar.GetComponent<Animator>();

        setWin(true);
    }

    public bool getPause()
    {
        return this.paused;
    }

    public void setPause(bool paused)
    {
        this.paused = paused;
    }

    public bool getLoose()
    {
        return this.loose;
    }

    public void setLoose(bool loose)
    {
        this.loose = loose;
    }

    public bool getWin()
    {
        return this.win;
    }

    public void setWin(bool win)
    {
        this.win = win;
        if (this.win == true)
        {
            PanelWin.SetActive(true);
            Stars.transform.Find("factoryStar1").gameObject.SetActive(true);
            Stars.transform.Find("factoryStar2").gameObject.SetActive(true);
            Stars.transform.Find("factoryStar3").gameObject.SetActive(true);
            Explosion.SetActive(true);



            startAnim = true;
            ExplosionAnim.SetBool("StartAnim", startAnim);

            StartCoroutine(ExplosionDelay());

            if (this.playerPoints > this.maxPoints*70/100)
            {
                //Stars.transform.Find("pandaStar1").gameObject.SetActive(true);
                Stars.transform.Find("pandaStar2").gameObject.SetActive(true);
                Stars.transform.Find("pandaStar3").gameObject.SetActive(true);
                //Debug.Log("Max Points = " + this.maxPoints + " Player Points = " + this.playerPoints + " - 3 stars");
            }
            else if(this.playerPoints <= this.maxPoints * 50 / 100)
            {
                //Stars.transform.Find("pandaStar1").gameObject.SetActive(true);
                Stars.transform.Find("factoryStar2").gameObject.SetActive(true);
                Stars.transform.Find("factoryStar3").gameObject.SetActive(true);
                //Debug.Log("Max Points = " + this.maxPoints + " Player Points = " + this.playerPoints + " - 1 star");
            }
            else
            {
                //Stars.transform.Find("pandaStar1").gameObject.SetActive(true);
                Stars.transform.Find("pandaStar2").gameObject.SetActive(true);
                Stars.transform.Find("factoryStar3").gameObject.SetActive(true);
               // Debug.Log("Max Points = " + this.maxPoints + " Player Points = " + this.playerPoints + " - 2 stars");
            }
            Time.timeScale = 0;
        }
    }

    IEnumerator ExplosionDelay()
    {
        Debug.Log("Start Explosion");
        while (endAnim == false)
        {
            yield return null;
        }

        Debug.Log("End Explosion");
        startAnim = false;
        endAnim = false;
        ExplosionAnim.SetBool("StartAnim", startAnim);
        Explosion.SetActive(false);
        Stars.transform.Find("factoryStar1").gameObject.SetActive(false);

        Stars.transform.Find("pandaStar1").gameObject.SetActive(true);
        PandaAnim.SetBool("PandaStarAnim", true);

        Debug.Log("Start Panda");
        while (endAnim == false)
        {
            yield return null;
        }
        Debug.Log("End Panda");
        PandaAnim.SetBool("PandaStarAnim", false);
    }

    /*IEnumerator PandaDelay()
    {
            Stars.transform.Find("pandaStar1").gameObject.SetActive(true);
            PandaAnim.SetBool("PandaStarAnim", true);

        Debug.Log("Start Panda");
        while (endAnim == false)
        {
            yield return null;
        }
        Debug.Log("End Panda");
        PandaAnim.SetBool("PandaStarAnim", false);
    }
    */
    public void TakeLife(int playerLives)
    {
        this.playerPoints -= (30 * this.playerPoints) / 100;
        switch (playerLives)
        {
            case 0:
                {
                    Lives.transform.GetChild(0).gameObject.SetActive(false);
                    setLoose(true);
                    PanelLoose.SetActive(true);
                    Time.timeScale = 0;
                    break;
                }
            case 1:
                {
                    Lives.transform.GetChild(1).gameObject.SetActive(false);
                    break;
                }
            case 2:
                {
                    Lives.transform.GetChild(2).gameObject.SetActive(false);
                    break;
                }
        }
    }

    public int getLife()
    {
        return this.playerLives;
    }
    public void setMaxPoints(int maxPoints)
    {
        this.maxPoints += maxPoints;
    }

    public void addPoints(int points)
    {
        this.playerPoints += points;
    }
    void OnGUI()
    {
        PlayerPrefs.SetInt("Score", this.playerPoints);
    }
}

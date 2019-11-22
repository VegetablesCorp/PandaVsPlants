using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemControlScript : MonoBehaviour
{
    public GameObject Lives;
    public GameObject PanelLoose;
    public GameObject PanelWin;

    private GameObject Stars;
    private GameObject Explosion_1;
    private GameObject Explosion_2;
    private GameObject Explosion_3;

    private Animator ExplosionAnim_1;
    private Animator ExplosionAnim_2;
    private Animator ExplosionAnim_3;

    private GameObject PandaStar_1;
    private GameObject PandaStar_2;
    private GameObject PandaStar_3;

    private Animator PandaAnim_1;
    private Animator PandaAnim_2;
    private Animator PandaAnim_3;

    private bool paused;
    private bool loose;
    private bool win;
    private int playerLives;
    private int maxPoints;
    private int playerPoints;

    public int stars = 0;

    void Start()
    {
        Time.timeScale = 1;

        playerPoints = 0;
        playerLives = 3;
        Debug.Log("*************************************************************");

        loose = false;
        win = false;

        Stars = PanelWin.transform.Find("Stars").gameObject;
        Stars.SetActive(true);
        for (int i = 0; i < Stars.transform.childCount; i++)
        {
            Stars.transform.GetChild(i).gameObject.SetActive(false); // Выключаем или включаем каждого полученного ребёнка по порядку.
        }

        Explosion_1 = Stars.transform.Find("Explosion1").gameObject;
        Explosion_2 = Stars.transform.Find("Explosion2").gameObject;
        Explosion_3 = Stars.transform.Find("Explosion3").gameObject;

        ExplosionAnim_1 = Explosion_1.GetComponent<Animator>();
        ExplosionAnim_2 = Explosion_2.GetComponent<Animator>();
        ExplosionAnim_3 = Explosion_3.GetComponent<Animator>();

        PandaStar_1 = Stars.transform.Find("pandaStar1").gameObject;
        PandaStar_2 = Stars.transform.Find("pandaStar2").gameObject;
        PandaStar_3 = Stars.transform.Find("pandaStar3").gameObject;

        PandaAnim_1 = PandaStar_1.GetComponent<Animator>();
        PandaAnim_2 = PandaStar_2.GetComponent<Animator>();
        PandaAnim_3 = PandaStar_3.GetComponent<Animator>();
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

            if (this.playerPoints > this.maxPoints*70/100)
            {
                Debug.Log("3");
                stars = 3;
                //Stars.transform.Find("pandaStar1").gameObject.SetActive(true);
                //Stars.transform.Find("pandaStar2").gameObject.SetActive(true);
               // Stars.transform.Find("pandaStar3").gameObject.SetActive(true);
                //Debug.Log("Max Points = " + this.maxPoints + " Player Points = " + this.playerPoints + " - 3 stars");
            }
            else if(this.playerPoints <= this.maxPoints * 50 / 100)
            {
                Debug.Log("1");
                stars = 1;
                //Stars.transform.Find("pandaStar1").gameObject.SetActive(true);
               // Stars.transform.Find("factoryStar2").gameObject.SetActive(true);
               // Stars.transform.Find("factoryStar3").gameObject.SetActive(true);
                //Debug.Log("Max Points = " + this.maxPoints + " Player Points = " + this.playerPoints + " - 1 star");
            }
            else
            {
                stars = 2;
                Debug.Log("2");
                //Stars.transform.Find("pandaStar1").gameObject.SetActive(true);
                //   Stars.transform.Find("pandaStar2").gameObject.SetActive(true);
                //   Stars.transform.Find("factoryStar3").gameObject.SetActive(true);
                // Debug.Log("Max Points = " + this.maxPoints + " Player Points = " + this.playerPoints + " - 2 stars");
            }
            StartCoroutine(ExplosionPanda(stars));
            Time.timeScale = 0;
        }
    }

    IEnumerator ExplosionPanda(int stars)
    {
            Explosion_1.SetActive(true);
            ExplosionAnim_1.SetBool("StartAnim", true);

            yield return new WaitForSecondsRealtime(1.1f);

            ExplosionAnim_1.SetBool("StartAnim", false);
            Explosion_1.SetActive(false);
            Stars.transform.Find("factoryStar1").gameObject.SetActive(false);
            Stars.transform.Find("pandaStar1").gameObject.SetActive(true);

            PandaAnim_1.SetBool("PandaStarAnim", true);

            yield return new WaitForSecondsRealtime(0.50f);

            PandaAnim_1.SetBool("PandaStarAnim", false);

        if (stars > 1)
        {
            Explosion_2.SetActive(true);
            ExplosionAnim_2.SetBool("StartAnim", true);

            yield return new WaitForSecondsRealtime(1.1f);

            ExplosionAnim_2.SetBool("StartAnim", false);
            Explosion_2.SetActive(false);
            Stars.transform.Find("factoryStar2").gameObject.SetActive(false);
            Stars.transform.Find("pandaStar2").gameObject.SetActive(true);

            PandaAnim_2.SetBool("PandaStarAnim", true);

            yield return new WaitForSecondsRealtime(0.50f);

            PandaAnim_2.SetBool("PandaStarAnim", false);
        }

        if (stars == 3)
        {
            Explosion_3.SetActive(true);
            ExplosionAnim_3.SetBool("StartAnim", true);

            yield return new WaitForSecondsRealtime(1.1f);

            ExplosionAnim_3.SetBool("StartAnim", false);
            Explosion_3.SetActive(false);
            Stars.transform.Find("factoryStar3").gameObject.SetActive(false);
            Stars.transform.Find("pandaStar3").gameObject.SetActive(true);

            PandaAnim_3.SetBool("PandaStarAnim", true);

            yield return new WaitForSecondsRealtime(0.50f);

            PandaAnim_3.SetBool("PandaStarAnim", false);
        }
    }

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

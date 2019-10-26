using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemControlScript : MonoBehaviour
{
    public GameObject Lives;
    public GameObject PanelLoose;
    public GameObject PanelWin;

    private bool paused;
    private bool loose;
    private bool win;
    private int playerLives;
    private int maxPoints;
    private int playerPoints;

    void Start()
    {
        Time.timeScale = 1;

        playerPoints = 0;
        playerLives = 3;

        loose = false;
        win = false;
    }

    void Update()
    {
        
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
        if (win == true)
        {
            PanelWin.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void TakeLife(int playerLives)
    {
        playerPoints -= (30 * playerPoints) / 100;
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
        playerPoints += points;
    }
    void OnGUI()
    {
        PlayerPrefs.SetInt("Score", playerPoints);
    }
}

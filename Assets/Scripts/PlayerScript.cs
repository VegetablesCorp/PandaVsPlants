using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    public float playerSpeed;   
    private Vector3 playerPosition;
    public float boundary;

    private int playerLives;
    private int playerPoints;
    private int maxPoints;

    public GameObject PanelLoose;
    public GameObject PanelWin;

    public GameObject Lives;

    public SystemControlScript SystemControl;

    private bool checkWin;
    private bool loose;
    private bool win;
    // Start is called before the first frame update
    void Start()
    {
    // получим начальную позицию платформы
    playerPosition = gameObject.transform.position;

        playerLives = 2;
        playerPoints = 0;

        checkWin = false;

        SystemControl.setLoose(false);
        SystemControl.setWin(false);
    }

    void addPoints(int points)
    {
        playerPoints += points;
    }

    public void setMaxPoints(int maxPoints)
    {
        this.maxPoints += maxPoints;
    }

    void TakeLife()
    {
        if(playerLives != 0)
        {
            playerLives--;
            playerPoints = playerPoints - (30 * playerPoints) / 100;
            switch (playerLives)
            {
                case 0:
                    {
                        Lives = GameObject.Find("Live2");
                        Lives.SetActive(false);
                        break;
                    }
                case 1:
                    {
                        Lives = GameObject.Find("Live3");
                        Lives.SetActive(false);
                        break;
                    }
            }
        }
        else {
            Lives = GameObject.Find("Live1");
            Lives.SetActive(false);
            SystemControl.setLoose(true);
            PanelLoose.SetActive(true);
        }
    }

    void OnGUI()
    {
        PlayerPrefs.SetInt("Score", playerPoints);
        if ((win == true)&&(checkWin == false))
        {
            Debug.Log(maxPoints);
            PanelWin.SetActive(true);
            checkWin = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        win = SystemControl.getWin();
        loose = SystemControl.getLoose();
 
        if ((loose == false) && (win == false))
        {
            {
                // горизонтальное движение
                playerPosition.x += Input.GetAxis("Mouse X") * playerSpeed * Time.deltaTime;

                // обновим позицию платформы
                transform.position = playerPosition;

                // проверка выхода за границы
                if (playerPosition.x < -boundary)
                {
                    transform.position = new Vector3(-boundary, playerPosition.y, playerPosition.z);
                }
                if (playerPosition.x > boundary)
                {
                    transform.position = new Vector3(boundary, playerPosition.y, playerPosition.z);
                }

                playerPosition = transform.position;
            }
        }
    }
}

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

    public GameObject PanelLoose;
    public GameObject PanelWin;

    private bool loose;
    private bool win;
    // Start is called before the first frame update
    void Start()
    {
    // получим начальную позицию платформы
    playerPosition = gameObject.transform.position;

        playerLives = 2;
        playerPoints = 0;

        loose = false;
        win = false;
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
    }

    void addPoints(int points)
    {
        playerPoints += points;
    }

    void TakeLife()
    {
        if(playerLives != 0)
        {
            playerLives--;
        }
        else {
            loose = true;
            PanelLoose.SetActive(true);
        }
    }

    void OnGUI()
    {
        GUI.Label(new Rect(5.0f, 3.0f, 200.0f, 200.0f), "Live's: " + playerLives + "  Score: " + playerPoints);
        if(win == true)
        {
            PanelWin.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if ((loose == false) && (win == false))
        {
            {
                // горизонтальное движение
                playerPosition.x += Input.GetAxis("Mouse X") * playerSpeed * Time.deltaTime;

                // выход из игры
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    Application.Quit();
                }

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

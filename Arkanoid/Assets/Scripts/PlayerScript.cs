using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float playerSpeed;   
    private Vector3 playerPosition;
    public float boundary;

    private int playerLives;
    private int playerPoints;

    // Start is called before the first frame update
    void Start()
    {
    // получим начальную позицию платформы
    playerPosition = gameObject.transform.position;

        playerLives = 3;
        playerPoints = 0;
    }

    void addPoints(int points)
    {
        playerPoints += points;
    }

    void TakeLife()
    {
        playerLives--;
    }

    void OnGUI()
    {
        GUI.Label(new Rect(5.0f, 3.0f, 200.0f, 200.0f), "Live's: " + playerLives + "  Score: " + playerPoints);
    }

    // Update is called once per frame
    void Update()
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

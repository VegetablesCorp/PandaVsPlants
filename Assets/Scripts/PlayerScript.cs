using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    public float playerSpeed;   
    private Vector3 playerPosition;
    public float boundary;

    // Start is called before the first frame update
    void Start()
    {
        // получим начальную позицию платформы
        playerPosition = gameObject.transform.position;
    }
    
    // Update is called once per frame
    void Update()
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

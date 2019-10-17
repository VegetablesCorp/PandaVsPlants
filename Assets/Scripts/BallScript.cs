using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    private bool ballIsActive;
    private Vector3 ballPosition;
    private Vector2 ballInitialForce;
    public GameObject playerObject;

    public bool ballStopped;
    public float prevPositionBall;
    public float currentPositionBall;
    public float drag_ball;

    private bool Prev;
    private float prevDeviationY;
    private float currentDeviationY;
    private float prevDeviationX;
    private float currentDeviationX;

    private Rigidbody2D ballRigidBody;

    int frameCounter = 0;

    // Start is called before the first frame update
    void Start()
    {
        Prev = true;
        ballStopped = false;
                         
        // создаем силу
        ballInitialForce = new Vector2(100.0f, 300.0f);

        // переводим в неактивное состояние
        ballIsActive = false;

        // запоминаем положение
        ballPosition = transform.position;

        ballRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // проверка нажатия на пробел
        if (Input.GetButtonDown("Jump") == true)
        {
            if (!ballIsActive)
            {
                ballStopped = false;

                // сброс всех сил
                ballRigidBody.isKinematic = false;

                // применим силу
                ballRigidBody.AddForce(ballInitialForce);

                // зададим активное состояние
                ballIsActive = !ballIsActive;

            }
        }
  
        if (!ballIsActive && playerObject != null)
        {
            // задаем новую позицию шарика
            ballPosition.x = playerObject.transform.position.x;

            // устанавливаем позицию шара
            transform.position = ballPosition;
        }

        // проверка падения шара
        if (ballIsActive && transform.position.y < -4)
        {
            //Замедление шара
            drag_ball = 5.0f;
            ballRigidBody.drag = drag_ball;

            //-----------Проверка положений шара по оси У через кадр--------------
            //Предыдущее положение шара
            if (Prev) prevPositionBall = transform.position.y;
            //Текущее положение шара
            else currentPositionBall = transform.position.y;
   
            //обеспечение считывания положения шара через кадр
            //Prev = !Prev;

            if (prevPositionBall == currentPositionBall)
            {
                ballStopped = true;
            }
            else
            {
                ballStopped = false;
            }
        }
               

        if (ballStopped == true)
        {
            drag_ball = 0.0f;
            ballRigidBody.drag = drag_ball;
            ballIsActive = !ballIsActive;
            ballPosition.x = playerObject.transform.position.x;
            ballPosition.y = -2.8f;
            transform.position = ballPosition;
            ballRigidBody.isKinematic = true;

            //добавили вызов метода
            playerObject.SendMessage("TakeLife");
            ballStopped = false;
        }

        Deviation();

    }

    private void Deviation()
    {
        //Предыдущее положение шара
        if (frameCounter == 1) prevDeviationY = transform.position.y;
        //Текущее положение шара
        if (frameCounter == 8) currentDeviationY = transform.position.y;


        if (prevDeviationY == currentDeviationY && ballIsActive)
        {
            ballPosition.x = transform.position.x;
            ballPosition.y = currentDeviationY + 2;
            ballRigidBody.AddForce(new Vector2(-2.1f, 0.1f), ForceMode2D.Impulse);
            Debug.Log("y");
        }

        //Предыдущее положение шара
        if (frameCounter == 1) prevDeviationX = transform.position.x;
        //Текущее положение шара
        if(frameCounter == 8) currentDeviationX = transform.position.x;

        frameCounter++;
        if (frameCounter > 9) frameCounter = 0;
        
        Prev = !Prev;

        if (prevDeviationX == currentDeviationX && ballIsActive)
        {
            ballPosition.x = transform.position.x;
            ballPosition.y = currentDeviationX + 2;
            ballRigidBody.AddForce(new Vector2(0.1f, -2.1f), ForceMode2D.Impulse);
            Debug.Log("x");

        }

        Debug.Log(ballRigidBody.velocity);


    }
}

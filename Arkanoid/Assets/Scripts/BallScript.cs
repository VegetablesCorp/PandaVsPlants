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
    public float drag_ball;

    private Rigidbody2D ballRigidBody;

    private int hitTimeOut;
    private float hitTimeOutPositionX;
    private float hitTimeOutPositionY;

    private float speed_X;
    private float speed_Y;
    private const float Z = 316.0f;
    private float koef;
    private int idc;

    // Start is called before the first frame update
    void Start()
    {
        ballStopped = false;

        speed_X = 0.0f;
        speed_Y = 0.0f;
        koef = 0;
        idc = 0;

        // создаем силу
        ballInitialForce = new Vector2(speed_X, speed_Y);

        // переводим в неактивное состояние
        ballIsActive = false;

        // запоминаем положение
        ballPosition = transform.position;

        ballRigidBody = GetComponent<Rigidbody2D>();

        hitTimeOut = 0;
        hitTimeOutPositionX = 0;
        hitTimeOutPositionY = 0;

        drag_ball = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // проверка нажатия на пробел
        if (Input.GetMouseButton(0) == true)
        {
            if (!ballIsActive)
            {
                ballStopped = false;

                // сброс всех сил
                ballRigidBody.isKinematic = false;

                // применим силу
                RandomAngle();
                ballInitialForce = new Vector2(speed_X, speed_Y);
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
        if (ballIsActive && transform.position.y < -4.0)
        {
            //Замедление шара
            drag_ball = 7.0f;
            ballRigidBody.drag = drag_ball;

            speed_X = Mathf.Abs(ballRigidBody.velocity.x);
            speed_Y = Mathf.Abs(ballRigidBody.velocity.y);

            if((speed_X == 0)&&(speed_Y == 0)) {
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
            ballPosition.y = playerObject.transform.position.y + 0.36f;
            transform.position = ballPosition;
            ballRigidBody.isKinematic = true;

            //добавили вызов метода
            playerObject.SendMessage("TakeLife");
            ballStopped = false;
        }

        idc++;
        if(idc == 30) {
            idc = 0;
        if ((ballIsActive == true)&&(drag_ball == 0))
        {
            // Ограничение скорости по осям Х и Y
            speed_X = Mathf.Abs(ballRigidBody.velocity.x);
            speed_Y = Mathf.Abs(ballRigidBody.velocity.y);
            koef = Mathf.Sqrt(speed_X * speed_X + speed_Y * speed_Y);
            if (koef != 0)
            {
                koef = Z / koef;
            }
                if ((speed_X == 0) && (speed_Y == 0))
                {
                    RandomAngle();
                }
                else
                {
                    speed_X = speed_X * koef;
                    speed_Y = speed_Y * koef;
                }

            ballRigidBody.velocity = new Vector2(Mathf.Sign(ballRigidBody.velocity.x) * speed_X / 70f, (Mathf.Sign(ballRigidBody.velocity.y)) * speed_Y / 70f);
        }
    }
 }

 void OnCollisionEnter2D(Collision2D coll)
    {
        // Если шарик "залипнет" на оси Х, то будет добавлена сила, чтобы изменить траекторию
        if (hitTimeOutPositionX != transform.position.x)
        {
            hitTimeOutPositionX = transform.position.x;
        }
        else
        {
            hitTimeOut++;
            if (hitTimeOut == 2)
            {
                hitTimeOut = 0;
                if (hitTimeOutPositionX < 0)
                {
                    ballRigidBody.AddForce(new Vector2(10.0f, Random.Range(-10.0f, 10.0f)));
                }
                else
                {
                    ballRigidBody.AddForce(new Vector2(-10.0f, Random.Range(-10.0f, 10.0f)));
                }
            }
        }
        // Тоже самое для Y
        if (hitTimeOutPositionY != transform.position.y)
        {
            hitTimeOutPositionY = transform.position.y;
        }
        else
        {
            hitTimeOut++;
            if (hitTimeOut == 2)
            {
                hitTimeOut = 0;
                if (hitTimeOutPositionY < 0)
                {
                    ballRigidBody.AddForce(new Vector2(Random.Range(-10.0f, 10.0f), 10.0f));
                }
                else
                {
                    ballRigidBody.AddForce(new Vector2(Random.Range(-10.0f, 10.0f), -10.0f));
                }
            }
        }
    }

    void RandomAngle ()
    {
        speed_X = 280.0f;
        speed_X = Random.Range(-speed_X, speed_X);
        speed_Y = Mathf.Sqrt(Z * Z - speed_X * speed_X);
    }
}

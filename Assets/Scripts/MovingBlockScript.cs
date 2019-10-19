using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBlockScript : MonoBehaviour
{
    //число ударов по блоку, чтобы разрушить его
    public int hitsToKill;

    //Число очков за разрушенный блок
    public int points;

    //Число ударов, которые получил блок
    private int numberOfHits;

    private Vector2 blockPosition;
    public float blockSpeed;
    public int signBlockSpeed;

    public int getSign()
    {
        return this.signBlockSpeed;
    }

    public void setSign(int sign)
    {
        this.signBlockSpeed = sign;
    }

    // Start is called before the first frame update
    void Start()
    {
        numberOfHits = 0;
        blockPosition.x = transform.position.x;
        blockPosition.y = transform.position.y;
        signBlockSpeed = 1;
    }

    // Update is called once per frame
   
    void FixedUpdate()
    {

        blockPosition.x += blockSpeed * signBlockSpeed * Time.deltaTime;

        // обновим позицию блока
        transform.position = blockPosition;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //print(collision.gameObject.name);
        if(collision.gameObject.tag == "Block")
        {
            Debug.Log("Block");
            getSign();
            setSign(signBlockSpeed * (-1));
            }

        if(collision.gameObject.tag == "Border")
        {
            Debug.Log("Border");
            getSign();
            setSign(signBlockSpeed * (-1));
        }

        if (collision.gameObject.tag == "Ball")
        {
            numberOfHits++;
        }
         if (numberOfHits == hitsToKill)
        {
            //получаем ссылку на платформу
            GameObject player = GameObject.FindGameObjectsWithTag("Player")[0];

            // выполняем метод из другого скрипта
            player.SendMessage("addPoints", points);

            Destroy(this.gameObject);
        }
    }
}

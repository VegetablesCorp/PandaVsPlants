using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BlockScript : MonoBehaviour
{

    //число ударов по блоку, чтобы разрушить его
    public int hitsToKill;
    
    //Число очков за разрушенный блок
    public int points;

    //Число ударов, которые получил блок
    private int numberOfHits;

    // Start is called before the first frame update
    void Start()
    {
        numberOfHits = 0;
    }

    //Переопределение метода OnCollisionEnter2D
    //tag задается в инспекторе для шара
    void OnCollisionEnter2D(Collision2D collision)
    {
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

    // Update is called once per frame
    void Update()
    {
        
    }
}



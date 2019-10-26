using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BlockScript : MonoBehaviour
{
    public SystemControlScript SystemControl;
    //число ударов по блоку, чтобы разрушить его
    public int hitsToKill;
    
    //Число очков за разрушенный блок
    public int points;

    //Число ударов, которые получил блок
    private int numberOfHits;

    void Start()
    {
        numberOfHits = 0;
        SystemControl.setMaxPoints(points);
    }

    //Переопределение метода OnCollisionEnter2D
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            numberOfHits++;
        }
        if (numberOfHits == hitsToKill)
            {
                SystemControl.addPoints(points);
                Destroy(this.gameObject);
            }
    }
}



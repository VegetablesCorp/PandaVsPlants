using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllBlocksScript : MonoBehaviour

{
    //Создание связи со скриптом игрока
    public SystemControlScript SystemControl;

    //подсчёт блоков на уровне
    private int changeCountBlocks;

    public Transform[] waypoints;
    public Transform[] diamonds;

    //количество дочерних объектов у объекта Blocks
    private int countChildObjects;

    //public bool Contains(string value, StringComparison comparisonType);
    // Start is called before the first frame update

    

    void Start()
    {
        countChildObjects = 0;

        //Получение всех дочерних объектов для объекта Blocks
        waypoints = new Transform[transform.childCount];

        int i = 0;
//        string sk;
//        string ad = "polygon";
//        string da = "grey polygon";
//        int lklk = 0;

        foreach (Transform t in transform)
        {
            waypoints[i++] = t;
            //Debug.Log(t);
            countChildObjects++;
        }

    /*    i = 0;
        for(i = 0; i < 5; i++) {
        foreach (Transform child in waypoints[i])
        {
            sk = child.name;
            lklk = child.BlockScript;
                Debug.Log("Points" + lklk);
            }
        }
        */

        // Debug.Log(waypoints[0]);
        //Число дочерних объектов у объекта Blocks
        countChildObjects++;

        //transform.hierarchyCount - всего объектов в иерархии Blocks включая сам объект Blocks
        changeCountBlocks = transform.hierarchyCount - countChildObjects;
    }

    // Update is called once per frame
    void Update()
    {
        //вывод количества блоков на уровне при уничтожении какого-либо из блоков
         if (changeCountBlocks > transform.hierarchyCount - countChildObjects)
        {
            changeCountBlocks = transform.hierarchyCount - countChildObjects;
        }

        //проверка на победу игрока (разрушены ли все блоки на уровни)
        if (transform.hierarchyCount == countChildObjects)
        {
            SystemControl.setWin(true);
            Destroy(gameObject);
        }
    }
}

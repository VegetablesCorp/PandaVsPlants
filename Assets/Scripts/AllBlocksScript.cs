using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllBlocksScript : MonoBehaviour

{
    //Создание связи со скриптом игрока
    public PlayerScript winPlayer;

    //подсчёт блоков на уровне
    private int changeCountBlocks;

    public Transform[] waypoints;

    //количество дочерних объектов у объекта Blocks
    private int countChildObjects;

    // Start is called before the first frame update
    void Start()
    {
        countChildObjects = 0;

        //Получение всех дочерних объектов для объекта Blocks
        waypoints = new Transform[transform.childCount];

        int i = 0;

        foreach (Transform t in transform)
        {
            waypoints[i++] = t;
            countChildObjects++;
        }

        //Число дочерних объектов у объекта Blocks
        countChildObjects++;

        //transform.hierarchyCount - всего объектов в иерархии Blocks включая сам объект Blocks
        changeCountBlocks = transform.hierarchyCount - countChildObjects;
        Debug.Log(changeCountBlocks);
    }

    // Update is called once per frame
    void Update()
    {
        //вывод количества блоков на уровне при уничтожении какого-либо из блоков
         if (changeCountBlocks > transform.hierarchyCount - countChildObjects)
        {
            changeCountBlocks = transform.hierarchyCount - countChildObjects;
            Debug.Log(gameObject.name + "= " + (transform.hierarchyCount - countChildObjects));
        }

        //проверка на победу игрока (разрушены ли все блоки на уровни)
        if (transform.hierarchyCount == countChildObjects)
        {
            winPlayer.setWin(true);
            Destroy(gameObject);
        }
    }
}

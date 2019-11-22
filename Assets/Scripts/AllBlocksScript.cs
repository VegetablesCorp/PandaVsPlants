using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllBlocksScript : MonoBehaviour

{
    //Создание связи со скриптом игрока
    public SystemControlScript SystemControl;

    public Transform[] blockTypes;

    //количество дочерних объектов у объекта Blocks
    private int countBlocksType;
    private int countBlocks;
    private int blocksDestroyed;

   void Start()
    {
        countBlocksType = 0;
        countBlocks = 0;

        //Получение всех дочерних объектов для объекта Blocks
        blockTypes = new Transform[transform.childCount];

        int i = 0;

        foreach (Transform t in transform)
        {
            blockTypes[i++] = t;
            countBlocksType++;
        }

        //Получение всех дочерних объектов каждой группы блоков
        for (i = 0; i < countBlocksType; i++)
        {
            foreach (Transform child in blockTypes[i])
            {
               countBlocks++;
            }
        }
    }

    //Проверка уничтожения игроком всех блоков на уровне
    public void blockDestroy(int blocksDestroyed)
    {
        this.blocksDestroyed += blocksDestroyed;
        if (this.blocksDestroyed == countBlocks)
        {
            SystemControl.setWin(true);
        }
    }
}

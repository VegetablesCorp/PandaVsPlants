using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllBlocksScript : MonoBehaviour

{
    public PlayerScript winPlayer;
    private bool loose;
    private bool win;

    private int changeCountBlocks;
    public Transform[] waypoints;
    private int countChildObjects;

    // Start is called before the first frame update
    void Start()
    {
        countChildObjects = 0;
        waypoints = new Transform[transform.childCount];

        int i = 0;

        foreach (Transform t in transform)
        {
            waypoints[i++] = t;
            countChildObjects++;
        }
        countChildObjects++;
        changeCountBlocks = transform.hierarchyCount - countChildObjects;
        Debug.Log(changeCountBlocks);
    }

    // Update is called once per frame
    void Update()
    {
         if (changeCountBlocks > transform.hierarchyCount - countChildObjects)
        {
            changeCountBlocks = transform.hierarchyCount - countChildObjects;
            Debug.Log(gameObject.name + "= " + (transform.hierarchyCount - countChildObjects));
        }

        if (transform.hierarchyCount == countChildObjects)
        {
            winPlayer.setWin(true);
            Destroy(gameObject);
        }
    }
}

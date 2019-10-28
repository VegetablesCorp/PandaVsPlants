using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBlockScript : MonoBehaviour
{
    public SystemControlScript SystemControl;
    public AllBlocksScript Block;

    private int blocksDestroyed;

    //число ударов по блоку, чтобы разрушить его
    public int hitsToKill;

    //Число очков за разрушенный блок
    public int points;

    //Число ударов, которые получил блок
    private int numberOfHits;

    private Vector2 overlap_1;
    private Vector2 overlap_2;
    private Vector2 overlap_3;
    private Vector2 overlap_4;


    private Vector2 blockPosition;
    public float blockSpeed;
    public int signBlockSpeed;

    private float x1;
    private float x2;
    private float y1;
    private float y2;

    private float x3;
    private float x4;
    private float y3;
    private float y4;

    private bool isMoving;
 
    private string s;
    private Vector2 sizeCollider;

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
        blocksDestroyed = 1;

        isMoving = false;
        x1 = x2 = y1 = y2 = 0.0f;
        x3 = x4 = y3 = y4 = 0.0f;

        s = gameObject.tag;

        if((s == "MoveRectangle") || (s == "MoveSquare"))
        {
            sizeCollider = gameObject.GetComponent<BoxCollider2D>().size;
            x1 = transform.position.x + 0.10f + sizeCollider.x / 2.0f;
            y1 = transform.position.y + sizeCollider.y / 2.0f;
            x2 = x1 + 0.5f;
            y2 = transform.position.y - sizeCollider.y / 2.0f;

            x3 = transform.position.x - 0.10f - sizeCollider.x / 2.0f;
            y3 = transform.position.y + sizeCollider.y / 2.0f;
            x4 = x1 - 0.5f;
            y4 = transform.position.y - sizeCollider.y / 2.0f;

            s = "box";
        }
       
        numberOfHits = 0;
        overlap_1 = new Vector2(x1, y1);
        overlap_2 = new Vector2(x2, y2);
        overlap_3 = new Vector2(x3, y3);
        overlap_4 = new Vector2(x4, y4);

        blockPosition.x = transform.position.x;
        blockPosition.y = transform.position.y;
        signBlockSpeed = 1;
    }

    void Update()
    {
        if ((isMoving == false)&&(s == "box")) {
            if ((Physics2D.OverlapArea(overlap_1, overlap_2) == null))
            {
                Debug.Log("No Collider_Right");
                isMoving = true;
                signBlockSpeed = 1;
            }
            else if((Physics2D.OverlapArea(overlap_3, overlap_4) == null))
            {
                Debug.Log("No Collider_Left");
                isMoving = true;
                signBlockSpeed = -1;
            }
        }
        else { 
        blockPosition.x += blockSpeed * signBlockSpeed * Time.deltaTime;

        // обновим позицию блока
        transform.position = blockPosition;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        switch(collision.gameObject.tag)
        {
            case "Block":
                {
                    getSign();
                    setSign(signBlockSpeed * (-1));
                    break;
                }
            case "Border":
                {
                    getSign();
                    setSign(signBlockSpeed * (-1));
                    break;
                }
            case "MoveRectangle":
                {
                    getSign();
                    setSign(signBlockSpeed * (-1));
                    break;
                }
            case "Ball":
                {
                    numberOfHits++;
                    if (numberOfHits == hitsToKill)
                    {
                        SystemControl.addPoints(points);
                        Block.blockDestroy(blocksDestroyed);
                        Destroy(this.gameObject);
                    }
                    break;
                }
        }
    }
}

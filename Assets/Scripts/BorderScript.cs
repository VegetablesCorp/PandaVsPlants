using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderScript : MonoBehaviour
{
    public MovingBlockScript MoveBlock;
    private int sign;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "MoveBlock")
        {
            sign = MoveBlock.getSign();
            MoveBlock.setSign(sign*(-1));
        }
     }
    // Update is called once per frame
    void Update()
    {
        
    }
}

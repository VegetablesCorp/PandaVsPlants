using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball_move : MonoBehaviour
{
    Rigidbody2D rig;
    public float power_ball;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        rig.AddForce(new Vector3(0.5f, 1.2f) * Time.deltaTime * power_ball);
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.transform.position.y <= -6.0f)
        {
            //Time.timeScale = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}

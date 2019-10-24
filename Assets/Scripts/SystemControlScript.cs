using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemControlScript : MonoBehaviour
{
    private bool paused;

    public bool getPause()
    {
        return this.paused;
    }

    public void setPause(bool paused)
    {
        this.paused = paused;
    }

}

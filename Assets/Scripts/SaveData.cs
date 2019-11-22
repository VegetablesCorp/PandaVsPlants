using UnityEngine;

public class SaveData : MonoBehaviour
{
    private static GameObject SceneAccess;

    public static GameObject Prefab
    {
        get
        {
            return SceneAccess;
        }
        set
        {
            SceneAccess = value;
        }
    }
}


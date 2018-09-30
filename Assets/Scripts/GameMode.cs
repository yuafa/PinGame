using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Mode
{
    Normal,
    Auto
}

public class GameMode : MonoBehaviour
{
    public static GameMode instance;

    public Mode mode = Mode.Normal;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

}

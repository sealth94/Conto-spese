using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoadManager : MonoBehaviour {

    public static SaveLoadManager instance = null;
    public static string actualGameName = null;
    public static bool mustLoad = false;

    private void Awake()
    {
        #region DontDestroyOnLoad
        if (instance == null)
        { instance = this; }

        else if (instance != this)
        { Destroy(gameObject); }

        DontDestroyOnLoad(gameObject);
        #endregion
    }
}

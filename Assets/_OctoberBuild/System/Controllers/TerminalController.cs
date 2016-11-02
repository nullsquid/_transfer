using UnityEngine;
using System.Collections;

public class TerminalController : MonoBehaviour {

    #region Instance
    public static TerminalController instance;
    #endregion

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

    }
}

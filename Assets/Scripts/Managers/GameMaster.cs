using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour {
    private static GameMaster _instance;
    
    public static GameMaster Instance { get { return _instance; } }
    public UserSettings userSettings;

    private void Awake()
    {
        //Singleton -------------------------------
        if (_instance != null && _instance != this)
            Destroy(this.gameObject);
        else
            _instance = this;
        // ----------------------------------------
        // Init UserSettings ----------------------
        userSettings = UserSettings.Load();
        // ----------------------------------------
    }
}

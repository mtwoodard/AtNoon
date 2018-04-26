using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour {
    enum GameStates { Menu, Match}
    private static GameMaster _instance;
    
    public static GameMaster Instance { get { return _instance; } }
    public UserSettings userSettings;
    public MatchMaster matchMasterPrefab;

    GameStates gameState; 
    MatchMaster matchMaster;
    void Awake()
    {
        gameState = GameStates.Menu;
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

    void Update()
    {
        switch (gameState)
        {
            case GameStates.Menu:
                break;
            case GameStates.Match:
                break;
            default:
                break;
        }
    }

    public void OnLoad(string sceneToLoad)
    {
        if(sceneToLoad == "Menu")
        {
            if (matchMaster)
            {
                Destroy(matchMaster.gameObject);
            }
            gameState = GameStates.Menu;
        }
        else
        {
            matchMaster = Instantiate(matchMasterPrefab).GetComponent<MatchMaster>();
            gameState = GameStates.Match;
        }
    }
}

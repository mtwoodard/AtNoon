using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MatchMaster : MonoBehaviour {
    enum MatchStates { Start, Play, GameOver, LostConnection}
    struct PlayerMatchStats
    {
        public int kills, deaths;
        public string name, team;
    }

    public Text timeLeft;
    public Text draw;

    MatchStates matchState;
    ArrayList matchStats = new ArrayList();
    Timer timer;
    SmoothMouseLook mainCamera;
    // Use this for initialization
    void Start () {
        matchState = MatchStates.Start;
        timer = gameObject.AddComponent<Timer>();
        mainCamera = Globals.Instance.Global("MainCamera").GetComponent<SmoothMouseLook>();
        mainCamera.cameraLock = true;
	}

    void Update()
    {
        switch (matchState)
        {
            case MatchStates.Start: // Spawn players in and initialize their data
                //Init Players Code Here
                StartCoroutine(StartMatch());
                matchState = MatchStates.Play;
                break;
            case MatchStates.Play: //Run timer update match stats update gui
                timeLeft.text = "" + (int)timer.timeLeft;
                break;
            case MatchStates.GameOver: //Show ending score card
                break;
            case MatchStates.LostConnection: 
            default: //Kick out to menu
                break;

        }
    }
	
    private IEnumerator StartMatch()
    {
        timeLeft.gameObject.SetActive(false);
        yield return new WaitForSeconds(Random.Range(2f, 6f));
        draw.gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        timer.Begin(60);
        draw.gameObject.SetActive(false);
        timeLeft.gameObject.SetActive(true);
        mainCamera.cameraLock = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MatchMaster : MonoBehaviour {
    public Text timeLeft;
    public Text draw;
    Timer timer;
    SmoothMouseLook mainCamera;
    // Use this for initialization
    void Start () {
        timer = gameObject.AddComponent<Timer>();
        timeLeft.gameObject.SetActive(false);
        StartCoroutine(StartMatch());
        mainCamera = Globals.Instance.Global("MainCamera").GetComponent<SmoothMouseLook>();
        mainCamera.cameraLock = true;
	}

    void Update()
    {
        timeLeft.text = "" + (int)timer.timeLeft;
    }
	
    private IEnumerator StartMatch()
    {
        yield return new WaitForSeconds(Random.Range(2f, 6f));
        draw.gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        timer.Begin(60);
        draw.gameObject.SetActive(false);
        timeLeft.gameObject.SetActive(true);
        mainCamera.cameraLock = false;
    }
}

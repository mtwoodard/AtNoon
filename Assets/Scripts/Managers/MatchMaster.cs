using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MatchMaster : MonoBehaviour {
    public Text timeLeft;
    public Image draw;
    Timer timer;

    // Use this for initialization
    void Start () {
        timer = gameObject.AddComponent<Timer>();
        timeLeft.text = "" + (int)timer.timeLeft;
        StartCoroutine(StartMatch());
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
    }
}

/*
*   Timer.cs
*   Created by Michael Woodard
*   Simple Timer Class - Begin/Stop/Pause/Resume/Restart functionality
*   Created for use by the Video Game Developer's Club of Okstate
*   Licensed under the MIT license
*/
using UnityEngine;
/*
*   Note - Since this is a MonoBehaviour you can't intialize it by simply calling "new Timer()"
*   Instead do something like this in another script's Awake/Start methods
*   ---------------------------------------------
*   timer = gameObject.AddComponent<Timer>();
*   ---------------------------------------------
*   This will add the timer as a component from the script
*/
public class Timer : MonoBehaviour
{

    public float timeLeft { get; private set; }
    public bool isTimerRunning { get; private set; }
    float originalValue = -1f; //Used for 

    void Awake()
    {
        timeLeft = 0f;
        isTimerRunning = false;
        hideFlags = HideFlags.HideInInspector; //since there is nothing needing to be changed in the inspector we can hide it
    }

    void Update()
    {
        if (isTimerRunning)
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft <= 0f)
            {
                isTimerRunning = false;
                timeLeft = 0f;
            }
        }
    }

    public Timer() { }

    /// <summary>
    /// Starts timer running for x amount of seconds. Only accepts positive values. WARNING: calling this function twice will
    /// reset the timer to a new countdown.
    /// </summary>
    /// <param name="seconds">Seconds until timer ends</param>
    public void Begin(float seconds)    // cant be called Start due to some function overloading with Unity
    {
        timeLeft = Mathf.Abs(seconds);
        originalValue = Mathf.Abs(seconds);
        isTimerRunning = true;
    }

    /// <summary>
    /// Pauses timer. Can be resumed with ResumeTimer.
    /// </summary>
    public void Pause()
    {
        isTimerRunning = false;
    }

    /// <summary>
    /// Resumes the timer after being paused by PauseTimer.
    /// </summary>
    public void Resume()
    {
        isTimerRunning = true;
    }

    /// <summary>
    /// Restarts timer at previously called timer value. If the timer
    /// has not been ran, the timer will not restart.
    /// </summary>
    public void Restart()
    {
        if (originalValue != -1)
        {
            isTimerRunning = true;
            timeLeft = originalValue;
        }
    }

    /// <summary>
    /// Stops Timer completely. Timer can be restarted.
    /// </summary>
    public void Stop()
    {
        timeLeft = 0f;
        isTimerRunning = false;
    }

}
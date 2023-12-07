using System;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public event Action OnRetryEvent;
    public event Action OnPauseEvent;
    public event Action OnResumeEvent;
    public event Action OnInitBestScoreKeyEvent;

    public void CallRetry()
    {
        //Debug.Log("CallRetry");
        OnRetryEvent?.Invoke();
    }

    public void CallPause()
    {
        //Debug.Log("CallPause");
        OnPauseEvent?.Invoke();
    }

    public void CallResume()
    {
        //Debug.Log("CallResume");
        OnResumeEvent?.Invoke();
    }

    public void CallInitScore()
    {
        //Debug.Log("CallInitScore");
        OnInitBestScoreKeyEvent?.Invoke();
    }
}

using UnityEngine;

public class GameInputController : GameController
{
    public void OnRetry()
    {
        Debug.Log("OnRetry");
        CallRetry();
    }

    public void OnPause()
    {
        Debug.Log("OnPause");
        CallPause();
    }

    public void OnResume()
    {
        Debug.Log("OnResume");
        CallResume();
    }
}

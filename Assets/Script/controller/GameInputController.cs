
public class GameInputController : GameController
{
    public void OnRetry()
    {
        //Debug.Log("OnRetry");
        if(!GameManager.Instance.IsRunning)
        {
            CallRetry();
        }
    }

    public void OnPause()
    {
        //Debug.Log("OnPause");
        if (GameManager.Instance.IsRunning)
        {
            CallPause();
        }
    }

    public void OnResume()
    {
        //Debug.Log("OnResume");
        if (GameManager.Instance.IsRunning)
        {
            CallResume();
        }
    }
}

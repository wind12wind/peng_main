using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryBtn : MonoBehaviour
{
    private GameController _controller;

    private void Start()
    {
        _controller.OnRetryEvent += ReGame;
    }

    public void ReGame()
    {
        SceneManager.LoadScene("MainScene");
    }
}

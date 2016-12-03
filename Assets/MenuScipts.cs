using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuScipts : MonoBehaviour {

    public void Play()
    {
        SceneManager.LoadScene("HostJoin");
    }
    public void Rules()
    {
        SceneManager.LoadScene("Rules");
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Back()
    {
        SceneManager.LoadScene("Main");
    }
}

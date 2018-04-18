using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScript : MonoBehaviour
{
    bool winlost;
    string mensaje;

    // Use this for initialization
    void Start()
    {
    }


    public void ButtonSurrendPressed()
    {
        SceneManager.LoadScene("Main");
    }

    public void ButtonReplayPressed()
    {
        SceneManager.LoadScene("Game");
    }
}

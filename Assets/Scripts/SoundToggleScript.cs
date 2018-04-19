
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SoundToggleScript : MonoBehaviour
{
    public static SoundToggleScript soundToggleScript;

    public void StartGameButton()
    {
        SceneManager.LoadScene("Game");
    }

    public void ButtonOutPressed()
    {
        Application.Quit();
    }

}

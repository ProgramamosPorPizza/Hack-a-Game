
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SoundToggleScript : MonoBehaviour
{
    public Toggle soundToggle;
    public AudioSource _audio;
    private bool isPlaying = true;

    public void ActiveToggle()
    {
        if (soundToggle.isOn)
        {
            AudioListener.volume = 1F;
        }
        else
        {
            AudioListener.volume = 0F;
        }
    }

    public void StartGameButton()
    {
        SceneManager.LoadScene("Game");
    }

    public void ChangeVolume()
    {
        if (isPlaying)
        {
            _audio.Stop();
            isPlaying = false;
        }
        else
        {
            _audio.Play();
            isPlaying = true;
        }
    }
}

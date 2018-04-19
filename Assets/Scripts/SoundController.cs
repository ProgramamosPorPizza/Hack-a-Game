using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundController : MonoBehaviour {

    public static SoundController soundController;

    public AudioSource _audio;
    private static bool isPlaying = true;
    public Button audioBtn;

    public Sprite audioOn;
    public Sprite audioOff;

    private static int destroy = 1;

    // Use this for initialization
    void Start () {
        if (!isPlaying)
        {
            _audio.Pause();
            isPlaying = false;
            audioBtn.image.sprite = audioOff;
        }
        else
        {
            _audio.Play();
            isPlaying = true;
            audioBtn.image.sprite = audioOn;
        }
    }

    void Awake()
    {
        if (soundController == null && destroy == 1)
        {
            soundController = this;
            DontDestroyOnLoad(gameObject);
            destroy--;
        }
        else
        {
            Destroy(soundController);
            soundController = this;
        }
    }

    public void ChangeVolume()
    {
        if (isPlaying)
        {
            _audio.Pause();
            isPlaying = false;
            audioBtn.image.sprite = audioOff;
        }
        else
        {
            _audio.Play();
            isPlaying = true;
            audioBtn.image.sprite = audioOn;
        }
    }
}

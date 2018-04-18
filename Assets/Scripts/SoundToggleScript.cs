
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SoundToggleScript : MonoBehaviour {
    public Toggle soundToggle;

	public void ActiveToggle()
    {
        if (soundToggle.isOn){
            AudioListener.volume = 1F;
        }
        else
        {
            AudioListener.volume = 0F;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InteractionController : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	public void ButtonBackClicked()
	{
		SceneManager.LoadScene("Main");
	}

}
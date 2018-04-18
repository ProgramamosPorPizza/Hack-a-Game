using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SenseTextController : MonoBehaviour {

	private Text uiText;

	// Use this for initialization
	void Start () {
		uiText = gameObject.GetComponent<Text> ();
		HideHint ();
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButtonDown (0))
			this.ShowHint ("Hello");

	}

	public void ShowHint (string hint) {
		uiText.text = hint;
	}

	public void HideHint () {
		uiText.text = "???";
	}

	public void Write() {

	}

}

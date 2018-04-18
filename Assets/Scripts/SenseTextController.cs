using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SenseTextController : MonoBehaviour {

	private string hint = "";

	private Text uiText;
	public int framesPerCharacter;

	private TextAnimation anim = null;

	// Use this for initialization
	void Start () {
		uiText = gameObject.GetComponentInChildren<Text> ();
		//HideHint ();
	}
	
	// Update is called once per frame
	void Update () {

		if (this.anim != null)
			this.uiText.text = anim.Continue ();

	}

	public void SetHint(string hint) {
		this.hint = hint;
	}

	public void ShowHint () {
		this.anim = new TextAnimation (this.hint);
	}

	public void HideHint () {
        Write("???");
	}

	public void Write(string str) {
		this.anim = new TextAnimation (str);
	}

}

public class TextAnimation {

	private string text;
	private int c = 0;

	public TextAnimation(string text) {
		this.text = text;
	}

	public string Continue() {

		string result = "";

		if (!isFinished ())
			result = text.Substring (0, c);
		else
			result = text;

		c++;
		return result;

	}

	public bool isFinished() {
		return c >= text.Length;
	}

}
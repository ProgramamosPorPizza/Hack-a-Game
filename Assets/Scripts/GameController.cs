using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	/* GUI */
	public GUIText sightGUIText;
	public GUIText hearGUIText;
	public GUIText smellGUIText;
	public GUIText touchGUIText;

	/* DATA */
	private List<Chamber> chambers;
	private Chamber currentChamber;

	// Use this for initialization
	void Start () {

		// TODO: Game initialization goes here.
		Chamber testChamber = new Chamber ("Description", "Sight", "Hearing", "Smell", "Touch");
		chambers.Add (testChamber);

		ShowChamber (testChamber);

	}

	// Update is called once per frame
	void Update () {

	}

	// Parse all permanent storage data from JSON files
	private void ParseDataFromJSON() {

	}

	private void ShowChamber(Chamber chamber) {

		// Set chamber as current chamber
		this.currentChamber = chamber;

		// Hide all hints
		this.sightGUIText.GetComponent<SenseTextController>().HideHint();
		this.hearGUIText.GetComponent<SenseTextController>().HideHint();
		this.smellGUIText.GetComponent<SenseTextController>().HideHint();
		this.touchGUIText.GetComponent<SenseTextController>().HideHint();

	}

}

// Class defining an individual Chamber.
public class Chamber {

	// Chamber info
	private string description;

	// Senses
	private Sense sight;
	private Sense hear;
	private Sense smell;
	private Sense touch;

	// Events
	private List<Event> events;

	// Stats
	private int nActionsPerformed;

	// Travel
	private Chamber rightChamber;
	private Chamber leftChamber;

	public Chamber (string description, string sightText, string hearText, string smellText, string touchText) {

		this.description = description;

		this.sight = new Sense (sightText);
		this.hear = new Sense (hearText);
		this.smell = new Sense (smellText);
		this.touch = new Sense (touchText);

	}

	/* USE SENSES */

	public string UseSight() {
		ActionPerformed ();
		return this.sight.GetText ();
	}

	public string UseHear() {
		ActionPerformed ();
		return this.hear.GetText ();
	}

	public string UseSmell() {
		ActionPerformed ();
		return this.smell.GetText ();
	}

	public string UseTouch() {
		ActionPerformed ();
		return this.touch.GetText ();
	}

	/* TRAVELING */

	private Chamber GetRightChamber() {
		return this.rightChamber;
	}

	private Chamber GetLeftChamber() {
		return this.leftChamber;
	}

	/* USE ITEMS */
	// TODO
	private void UseItem(Item item) {

		switch (item.GetName()) {

		case "Match":
			
			break;

		}

		ActionPerformed ();

	}

	private void ActionPerformed () {

		// An action (use sense, use object, etc) has been performed by the player.
		// Trigger next event.

		if (events.Count >= nActionsPerformed) events [nActionsPerformed].Trigger ();
		nActionsPerformed++;

	}

}

// Defines a sense
public class Sense {

	private string text;

	public Sense(string text) {
		this.text = text;
	}

	public string GetText() {
		return this.text;
	}

}
			
// Defines an usable item
public class Item {

	private string name;

	public Item(string name) {

	}

	public string GetName() {
		return this.name;
	}

}

// Defines an event
public class Event {

	private string text;

	public Event (string text) {
		this.text = text;
	}

	// Trigger event action
	public void Trigger() {

	}

}
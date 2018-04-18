using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	/* GUI */
	public Button sightButton;
	public Button hearButton;
	public Button smellButton;
	public Button touchButton;

	public Text descriptionText;

	private Text sightText;
	private Text hearText;
	private Text smellText;
	private Text touchText;

	/* DATA */
	private List<Chamber> chambers;
	private Chamber currentChamber;

	// Use this for initialization
	void Start () {

		// TODO: Game initialization goes here.
		sightText = sightButton.GetComponentsInChildren<Text>()[0];
		hearText = hearButton.GetComponentsInChildren<Text>()[0];
		smellText = smellButton.GetComponentsInChildren<Text>()[0];
		touchText = touchButton.GetComponentsInChildren<Text>()[0];

		Chamber testChamber = new Chamber ("You're stuck. Everything is dark. Maybe this wasn't such a good idea.", "Sight", "Hearing", "Smell", "Touch");

		ShowChamber (testChamber);
		print ("Initializing chamber");

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

		// Update description
		this.descriptionText.GetComponent<SenseTextController>().Write(currentChamber.GetDescription());

		// Hide all hints
		this.sightText.GetComponent<SenseTextController>().HideHint();
		this.hearText.GetComponent<SenseTextController>().HideHint();
		this.smellText.GetComponent<SenseTextController>().HideHint();
		this.touchText.GetComponent<SenseTextController>().HideHint();

		// Update hint info
		this.sightText.GetComponent<SenseTextController>().SetHint(currentChamber.GetSight());
		this.hearText.GetComponent<SenseTextController>().SetHint(currentChamber.GetHear());
		this.smellText.GetComponent<SenseTextController>().SetHint(currentChamber.GetSmell());
		this.touchText.GetComponent<SenseTextController>().SetHint(currentChamber.GetTouch());

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

	public string GetDescription() {
		return this.description;
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

	/* GET SENSES */

	public string GetSight() {
		return this.sight.GetText ();
	}

	public string GetHear() {
		return this.hear.GetText ();
	}

	public string GetSmell() {
		return this.smell.GetText ();
	}

	public string GetTouch() {
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
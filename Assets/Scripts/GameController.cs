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

	public Text sightText;
	public Text hearText;
	public Text smellText;
	public Text touchText;

	public Button rightChamberButton;
	public Button leftChamberButton;

	/* DATA */
	private List<Chamber> chambers;
	private Chamber currentChamber;

	private int ch = 0;
	private int cerillas = 16;
    
    private int sightTimes = 1;
    private int hearTimes = 1;
    private int smellTimes = 1;
    private int touchTimes = 1;

    private bool deathState = false;

    public Text cerillaCounter;

	// Use this for initialization
	void Start () {

        cerillaCounter.GetComponent<Text>().text = cerillas.ToString();
		chambers = new List<Chamber>();

		ParseCSV ();
		print (chambers.Count);

		Chamber testChamber = new Chamber ("You're stuck. Everything is dark. Maybe this wasn't such a great idea.", "Darkness.", "You don't hear anything in particular.", "Smells... damp?", "The walls are wet. It's not pleasant.", chambers[0], chambers[1]);

		ShowChamber (testChamber);

		print ("Initializing chamber");

	}

	// Update is called once per frame
	void Update () {

        if (cerillas <= 0 && !deathState)
        {
            Chamber death = new Chamber("You ran out of matches. You die.", "You feel nothing", "You feel nothing", "You feel nothing", "You feel nothing", null, null);
            ShowChamber(death);
            cerillas = 0;
            cerillaCounter.GetComponent<Text>().text = cerillas.ToString();
            deathState = true;
        }

	}

    public void ButtonClicked(Button b)
    {
        if (cerillas > 0) {
            if (b.gameObject.name == "HearButton" && hearTimes > 0)
            {
                cerillas--;
                hearTimes--;
                cerillaCounter.GetComponent<Text>().text = cerillas.ToString();
                SenseTextController t = b.transform.GetChild(0).GetComponent<SenseTextController>();
                t.ShowHint();
            }
            else if(b.gameObject.name == "SmellButton" && smellTimes > 0)
            {
                cerillas--;
                smellTimes--;
                cerillaCounter.GetComponent<Text>().text = cerillas.ToString();
                SenseTextController t = b.transform.GetChild(0).GetComponent<SenseTextController>();
                t.ShowHint();
            }
            else if(b.gameObject.name == "TouchButton" && touchTimes > 0)
            {
                cerillas--;
                touchTimes--;
                cerillaCounter.GetComponent<Text>().text = cerillas.ToString();
                SenseTextController t = b.transform.GetChild(0).GetComponent<SenseTextController>();
                t.ShowHint();
            }
            else if (b.gameObject.name == "SightButton" && sightTimes > 0)
            {
                cerillas--;
                sightTimes--;
                cerillaCounter.GetComponent<Text>().text = cerillas.ToString();
                SenseTextController t = b.transform.GetChild(0).GetComponent<SenseTextController>();
                t.ShowHint();
            }
        }
        else
        {
            cerillas = 0;
            cerillaCounter.GetComponent<Text>().text = cerillas.ToString();
            SenseTextController t = b.transform.GetChild(0).GetComponent<SenseTextController>();
            t.ShowHint();
        }
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

        if (cerillas > 0)
        {
            cerillas--;
            cerillaCounter.GetComponent<Text>().text = cerillas.ToString();
        }

        touchTimes = 1;
        smellTimes = 1;
        hearTimes = 1;
        sightTimes = 1;
    }


	public void GoToLeft() {
        if (!deathState)
        {
            ShowChamber(chambers[ch + 1]);
            ch++;
        }
	}

	public void GoToRight() {
        if (!deathState)
        {
            ShowChamber(chambers[ch + 4]);
            ch++;
        }
	}

	// Parse all permanent storage data from CSV files
	private void ParseCSV() {

		List<Dictionary<string,object>> data = CSVReader.Read ("historiasoficial");

		for(var i=0; i < data.Count; i++) {
			string description = (string) data [i] ["description"];
			string sight = (string) data [i] ["sight"];
			string hear = (string) data [i] ["hear"];
			string smell = (string) data [i] ["smell"];
			string touch = (string) data [i] ["touch"];

			Chamber c = new Chamber (description, sight, hear, smell, touch, null, null);
			chambers.Add (c);

		}

		/*for (var i = 0; i < chambers.Count - 10; i++) {
			chambers [0].setLeft (chambers[i + 1]);
		}

		for (var i = 0; i < chambers.Count; i++) {
			chambers [0].setRight (chambers[i + 5]);
		}*/

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

	public Chamber (string description, string sightText, string hearText, string smellText, string touchText, Chamber left, Chamber right) {

		this.description = description;

		this.sight = new Sense (sightText);
		this.hear = new Sense (hearText);
		this.smell = new Sense (smellText);
		this.touch = new Sense (touchText);

		this.leftChamber = left;
		this.rightChamber = right;

	}

	public void setRight(Chamber r) {
		this.rightChamber = r;
	}

	public void setLeft(Chamber l) {
		this.leftChamber = l;
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

	public Chamber GetRightChamber() {
		return this.rightChamber;
	}

	public Chamber GetLeftChamber() {
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
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackInitializer : MonoBehaviour {
	public GameObject[] attacks;
	public GameObject spawnPoint;

	public Vector3 previousLocation;
	public Vector3 newLocation;
	public WaitTimer waitTimer;
	public Text helpText;

	// Use this for initialization
	void Start () {
		waitTimer = FindObjectOfType<WaitTimer> ();
		InvokeRepeating ("listenForSpells", 0f, 0.2f);

	}
	
	// Update is called once per frame
	void Update () {
		if (GvrController.State != GvrConnectionState.Connected) {
			// TODO: Pause Game
		}

		if (GvrController.ClickButtonUp) {
			GameObject spell = (GameObject) Instantiate (attacks [4], spawnPoint.transform.position, spawnPoint.transform.rotation);
			Object.Destroy(spell, 2f);
		}

		//listenForSpells(); // Too sensitive. Spells cast too frequently.
	}

	private void listenForSpells() {
		waitTimer.StartCoroutine ();
		checkSpellCasting ();
	}

	private void checkSpellCasting() {
		int spellToCast = -1;
		float timeWaited = 1f;
		// X related calculations.
		bool increaseInX = (newLocation.x > previousLocation.x);
		float xVelocity = Mathf.Abs(newLocation.x - previousLocation.x) / timeWaited;
	
		// Y related calculations.
		bool increaseInY = (newLocation.y > previousLocation.y);
		float yVelocity = Mathf.Abs(newLocation.y - previousLocation.y) / timeWaited;

		if (xVelocity >= yVelocity) { // Choose the greater of the two. 
			if (xVelocity > 13f) {
				if (increaseInX) {
					// cast spell 1;  // Moved the controller to the right.
					spellToCast = 0;
					helpText.text = "Casting Icebolt.";
				} else { // decrease in x.
					// cast spell 5; // Moved the controller to the left.
					spellToCast = 1;
					helpText.text = "Casting Poison";
				}
			} 			
		} else { // Y is greater.
			if (yVelocity > 13f) {
				if (increaseInY) {
					// cast spell 1;  // Moved the controller to the right.
					spellToCast = 2;
					helpText.text = "Casting Firebolt.";
				} else {
					// cast spell 5; // Moved the controller to the left.
					spellToCast = 3;
					helpText.text = "Casting Ghost";
				}
			} 
		}


		if (spellToCast != -1) {
			GameObject spell = (GameObject)Instantiate (attacks [spellToCast], spawnPoint.transform.position, spawnPoint.transform.rotation);
			Object.Destroy (spell, 2f);
		} 
	}

}

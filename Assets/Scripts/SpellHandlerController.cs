using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellHandlerController : MonoBehaviour {

	// Observers
	public List<ICastable> spellHandlers;

	// Data for Spell Handlers
	public GameObject spawnPoint;
//	private List<Vector3> previousPositions;
	private Vector3 previousPosition;
	private Vector3 currentPosition;
	private float xVelocity;
	private bool increaseInX;
	private float yVelocity;
	private bool increaseInY;

	void Awake () {
		// Set default starting positions.
		previousPosition = new Vector3 (0, 0, 0);
		currentPosition = new Vector3 (0, 0, 0);

		// Add SpellHandlers.
//		spellHandlers.Add(new FireBoltSpellHandler());
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnNotify(Text helpText) {
		// Set the previousPosition with the old currentPosition data.
		previousPosition = currentPosition;

		// Update the currentPosition with new data.
		currentPosition = GvrController.Orientation.eulerAngles;

		// Calculate velocities and boolean valuees.
		float timeWaited = 0.2f;
			// X related calculations.
		increaseInX = (currentPosition.x > previousPosition.x);
		xVelocity = Mathf.Abs(currentPosition.x - previousPosition.x) / timeWaited;

			// Y related calculations.
		increaseInY = (currentPosition.y > previousPosition.y);
		yVelocity = Mathf.Abs(currentPosition.y - previousPosition.y) / timeWaited;

		// Notify all spell handlers.
		foreach(ICastable spellHandler in spellHandlers) {
			spellHandler.cast (spawnPoint, previousPosition, currentPosition, xVelocity, increaseInX, yVelocity, increaseInY); // Pass in all necessary data.
		}

		helpText.text = "xVelocity = " + xVelocity + " increaseInX = " + increaseInX.ToString ();

	}
}

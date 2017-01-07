using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBoltSpellHandler : MonoBehaviour, ICastable {
	public GameObject spellEffect;

	// This spell will cast when a user moves the controller to the right.
	public void cast (GameObject spawnPoint, Vector3 previousPosition, Vector3 currentPosition, float xVelocity, bool increaseInX, float yVelocity, bool increaseInY) {
		// Decide whether to cast the spell.
		if ((xVelocity >= yVelocity) && (xVelocity > 13f) && increaseInX) { 
			GameObject spell = (GameObject)Instantiate (spellEffect, spawnPoint.transform.position, spawnPoint.transform.rotation);
			Object.Destroy (spell, 2f);
		}
	}

}
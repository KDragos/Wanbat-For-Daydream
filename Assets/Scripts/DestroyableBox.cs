using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyableBox : MonoBehaviour {
	public string elementType;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnParticleCollision(GameObject other) {
		if(other.GetComponentInParent<Spell>().getSpellType().Equals(elementType)) {
			Destroy (gameObject);
		}
	}
}

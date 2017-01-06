using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitTimer : MonoBehaviour {

	public void StartCoroutine (){
		StartCoroutine (UpdatePositionEverySecond ());
	}

	IEnumerator UpdatePositionEverySecond() {
		AttackInitializer attackInitializer = FindObjectOfType<AttackInitializer>();
		attackInitializer.previousLocation = GvrController.Orientation.eulerAngles;
		yield return new WaitForSecondsRealtime (0.2f);
		attackInitializer.newLocation = GvrController.Orientation.eulerAngles;
	}
}

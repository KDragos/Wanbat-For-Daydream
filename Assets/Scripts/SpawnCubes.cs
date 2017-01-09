using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCubes : MonoBehaviour {
	public GameObject[] cubes;
	public GameObject player;
	private int numCubes = 0;
	private int maxCubes;

	// Use this for initialization
	void Start () {
		maxCubes = 100;
		InvokeRepeating ("CreateCube", 0, 1f);
	}
	
	// Update is called once per frame
	void Update () {
		if (numCubes >= maxCubes) {
			CancelInvoke ();
		}
	}

	private void CreateCube() {
		Vector3 spawnPoint = GenerateSpawnPoint ();
		int randomCube = (int) Random.Range(0f, cubes.Length);

		Instantiate (cubes [randomCube], spawnPoint, Quaternion.identity);
		numCubes++;
	}

	private Vector3 GenerateSpawnPoint() {
		return new Vector3 (Random.Range(-10f, 10f), 10, Random.Range(-10f, 10f));
	}

	public void ResetCubes() {
		numCubes = 0;
		InvokeRepeating ("CreateCube", 0, 1f);
	}
}

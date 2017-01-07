using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICastable {

	void cast (GameObject spawnPoint, Vector3 previousPosition, Vector3 currentPosition, float xVelocity, bool increaseInX, float yVelocity, bool increaseInY);
}

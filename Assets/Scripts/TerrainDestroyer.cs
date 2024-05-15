using UnityEngine;
using System.Collections;

public class TerrainDestroyer : MonoBehaviour {

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag != "Bounds") {
			Destroy (other.gameObject);
		}
	}

}

using UnityEngine;
using System.Collections;

public class MMCameraMovement : MonoBehaviour {

	public float speed=2;

	void Update () {
		transform.Translate(0,0,speed*Time.deltaTime);
	}
}

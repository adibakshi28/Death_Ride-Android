using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour {

	public float rotSpeed = 10;
	public bool x, y, z;

	private float xRotSpeed, yRotSpeed, zRotSpeed;

	void Start(){
		if (x) {
			xRotSpeed = rotSpeed;
		}
		else {
			xRotSpeed = 0;
		}
		if (y) {
			yRotSpeed = rotSpeed;
		}
		else {
			yRotSpeed = 0;
		}
		if (z) {
			zRotSpeed = rotSpeed;
		} 
		else {
			zRotSpeed = 0;
		}

	}

	void Update () {
		transform.Rotate (xRotSpeed * Time.deltaTime, yRotSpeed * Time.deltaTime, zRotSpeed * Time.deltaTime);
	}
}

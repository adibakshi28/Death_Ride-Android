using UnityEngine;
using System.Collections;

public class Ossilator : MonoBehaviour {

	public float speed=10;

	void Update () {
		transform.Translate (speed * Time.deltaTime, 0, 0);
	}

	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "Enemy") {
			speed = (-1) * speed;
		}
	}


}

using UnityEngine;
using System.Collections;

public class Bounds : MonoBehaviour {

	public float scrollSpeed=10;

//	int dir = 1;
	Vector3 pos;
	GameObject jet;
//	Renderer rend;
	LevelDataController levelControllerScript;

	void Start () {
		jet = GameObject.FindGameObjectWithTag ("Player");
		levelControllerScript = GameObject.FindGameObjectWithTag ("LevelDataController").GetComponent<LevelDataController> ();
//		rend = GetComponent<Renderer> ();

/*		if (transform.position.x > 0) {
			dir = -1;
		} else {
			dir = 1;
		}*/

	}

	void LateUpdate () {
		if (!levelControllerScript.gameOver) {
			pos = transform.localPosition;
			pos.z = jet.transform.position.z;
			transform.localPosition = pos;

//			float offset = Time.time * scrollSpeed * dir;
//			float offset = Time.time * scrollSpeed ;
//			rend.material.mainTextureOffset = new Vector2 (offset, 0);
		}
	}
}

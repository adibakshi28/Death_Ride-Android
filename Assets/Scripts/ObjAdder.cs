using UnityEngine;
using System.Collections;

public class ObjAdder : MonoBehaviour {

	public GameObject diamond, sphere, pyramid, capsule;
	public GameObject[] collectables;
	public int type = 1,collType=0;
	public float heightAbove = 1, sizeMultiplier = 1, ossSpeed;
	[HideInInspector]
	public Material mat;

	void Start () {
		switch (type) {
		case 1:
			Vector3 pos = new Vector3 (transform.position.x, transform.position.y + transform.localScale.y  + heightAbove, transform.position.z);
			GameObject dia;
			dia = Instantiate (diamond, pos, Quaternion.identity)as GameObject;
			Vector3 sz = dia.transform.localScale;
			sz = sz * sizeMultiplier;
			dia.transform.localScale = sz;
			dia.transform.GetChild (0).GetComponent<Renderer> ().material = mat;
			dia.transform.GetChild (1).GetComponent<Renderer> ().material = mat;
			dia.transform.parent = this.gameObject.transform;
			break;
		case 2:
			pos = new Vector3 (transform.position.x, transform.position.y + transform.localScale.y + heightAbove, transform.position.z);
			GameObject sph;
			sph = Instantiate (sphere, pos, Quaternion.identity)as GameObject;
			sz = sph.transform.localScale;
			sz = sz * sizeMultiplier;
			sph.transform.localScale = sz;
			sph.GetComponent<Renderer> ().material = mat;
			sph.transform.parent = this.gameObject.transform;
			break;
		case 3:
			pos = new Vector3 (transform.position.x, transform.position.y + transform.localScale.y + heightAbove, transform.position.z);
			GameObject pyra;
			pyra = Instantiate (pyramid, pos, Quaternion.identity)as GameObject;
			sz = pyra.transform.localScale;
			sz = sz * sizeMultiplier;
			pyra.transform.localScale = sz;
			pyra.GetComponent<Renderer> ().material = mat;
			pyra.transform.parent = this.gameObject.transform;
			break;
		case 4:
			pos = new Vector3 (transform.position.x, 0, transform.position.z);
			GameObject cap;
			cap = Instantiate (capsule, pos, Quaternion.identity)as GameObject;
			sz = cap.transform.localScale;
			sz = sz * sizeMultiplier;
			cap.transform.localScale = sz;
			cap.transform.GetChild (0).transform.gameObject.GetComponent<Renderer> ().material = mat;
			cap.GetComponent<Ossilator> ().speed = ossSpeed;
			cap.transform.parent = this.gameObject.transform;
			break;
		case 5:
			pos = new Vector3 (transform.position.x, collectables[collType].transform.localScale.y/2, transform.position.z);
			GameObject coll;
			coll = Instantiate (collectables[collType], pos, Quaternion.identity)as GameObject;
			coll.transform.parent = this.gameObject.transform;
			break;
		
		}

	}
}

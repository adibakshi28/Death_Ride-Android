using UnityEngine;
using System.Collections;

public class CreateAlongMesh : MonoBehaviour {

	public Mesh mesh;
	public GameObject objects;

	private float frontZ=0;

	void Start () {
		Vector3[] verts = mesh.vertices;
		for (int i = 0; i < verts.Length; i++) {
			GameObject obj;
			Vector3 pos = verts [i] + transform.position;
			obj=Instantiate (objects,pos , Quaternion.identity)as GameObject;
//			InstObs (pos, 5, objects);
			obj.transform.parent = this.gameObject.transform;
			if (frontZ < pos.z) {
				frontZ = pos.z;
			}
		}
		Debug.Log (verts.Length);
		Debug.Log (frontZ);
	}


	void InstObs(Vector3 loc,float dist,GameObject obs ){
		float x, y, c, a, b, z, det;
		a = loc.x;
		b = loc.y;
		z = loc.z;
		c = ((a * a) + (b * b));
		det = (dist * Mathf.Pow (c, 0.5f));
		y = (b * (c + det)) / c;
		x = (a * (c + det)) / c;
		Vector3 pos = new Vector3 (x, y, z);
		GameObject obje = Instantiate (obs, pos, Quaternion.identity)as GameObject;
		obje.transform.parent = this.gameObject.transform;
	}

}

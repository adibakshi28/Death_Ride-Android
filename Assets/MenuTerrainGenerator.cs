using UnityEngine;
using System.Collections;

public class MenuTerrainGenerator : MonoBehaviour {

	public GameObject cube;
	public Vector2 heightRandomRange;
	public int perColumn = 10, changeDistanceThreshold=500;
	public Transform terrainGenerationPoint;
	public Material[] cubeMaterials, altMaterial;
	public Material altObsMaterial, altCommonMaterial;

	private Vector3 lastCubePos;
	private int e=0;
	void Start () {

		ChangeTerrain (PlayerPrefs.GetInt ("TerrainType"));

		for (int i = 0; i < 50; i++) {   // total rows	

			for (int j = 1; j < perColumn+1; j++) {  // total columns
				Vector3 pos= new Vector3((j*cube.transform.localScale.x)-((cube.transform.localScale.x*perColumn)/2)+transform.position.x,transform.position.y,i*cube.transform.localScale.z+transform.position.z);
				GameObject obj0= Instantiate (cube, pos, Quaternion.identity)as GameObject;
				GameObject obj1= Instantiate (cube, pos, Quaternion.identity)as GameObject;
				if (i % 2 == 0) {
					if (j % 2 == 0) {
						obj0.GetComponent<Renderer> ().material = altCommonMaterial;
					} else {
						obj0.GetComponent<Renderer> ().material = altMaterial [0];
					}
				} else {
					if (j % 2 == 0) {
						obj0.GetComponent<Renderer> ().material = altMaterial [0];
					} else {
						obj0.GetComponent<Renderer> ().material = altCommonMaterial;
					}
				}
				obj1.GetComponent<Renderer> ().material = cubeMaterials[0];
				Vector3 size0 = obj0.transform.localScale;
				Vector3 size1 = obj1.transform.localScale;
				if ((j == 1) || (j == perColumn)) {
					ObjSizeModifier objModScript0,objModScript1;

					objModScript0=obj0.GetComponent<ObjSizeModifier> ();
					objModScript0.speed = Random.Range (5f, 10f);
					objModScript0.maxHeight = Random.Range (50, 70);
					objModScript0.minHeight = Random.Range (30, 40);
					objModScript0.enabled = true;
					obj0.GetComponent<Renderer> ().material = altObsMaterial;

					objModScript1=obj1.GetComponent<ObjSizeModifier> ();
					objModScript1.speed = Random.Range (5f, 10f);
					objModScript1.maxHeight = Random.Range (50, 70);
					objModScript1.minHeight = Random.Range (30, 40);
					objModScript1.enabled = true;
				} 
				else {
					size0.y = Random.Range (heightRandomRange.x, heightRandomRange.y);
					size1.y = Random.Range (heightRandomRange.x, heightRandomRange.y);
				}

				obj0.transform.localScale = size0;
				obj0.transform.parent = this.gameObject.transform.GetChild (0).transform;

				obj1.transform.localScale = size1;
				obj1.transform.parent = this.gameObject.transform.GetChild (1).transform;

				lastCubePos = obj1.transform.position;
			}
		}
	}
	

	void Update () {
		if (terrainGenerationPoint.position.z > lastCubePos.z) {
			e++;
			for (int j = 1; j < perColumn + 1; j++) {
				Vector3 pos= new Vector3((j*cube.transform.localScale.x)-((cube.transform.localScale.x*perColumn)/2)+transform.position.x,transform.position.y,(lastCubePos.z+cube.transform.localScale.z)+transform.position.z);
				GameObject obj0= Instantiate (cube, pos, Quaternion.identity)as GameObject;
				GameObject obj1= Instantiate (cube, pos, Quaternion.identity)as GameObject;

				int ind = ((int)(terrainGenerationPoint.position.z / changeDistanceThreshold))%cubeMaterials.Length;

				if (e % 2 == 0) {
					if (j % 2 == 0) {
						obj0.GetComponent<Renderer> ().material = altCommonMaterial;
					} else {
						obj0.GetComponent<Renderer> ().material = altMaterial [ind];
					}
				} else {
					if (j % 2 == 0) {
						obj0.GetComponent<Renderer> ().material = altMaterial [ind];
					} else {
						obj0.GetComponent<Renderer> ().material = altCommonMaterial;
					}
				}

				obj1.GetComponent<Renderer> ().material = cubeMaterials [ind];

				Vector3 size0 = obj0.transform.localScale;
				Vector3 size1 = obj1.transform.localScale;

				if ((j == 1) || (j == perColumn)) {
					ObjSizeModifier objModScript0,objModScript1;

					objModScript0=obj0.GetComponent<ObjSizeModifier> ();
					objModScript0.speed = Random.Range (5f, 10f);
					objModScript0.maxHeight = Random.Range (50, 70);
					objModScript0.minHeight = Random.Range (30, 40);
					objModScript0.enabled = true;
					obj0.GetComponent<Renderer> ().material = altObsMaterial;

					objModScript1=obj1.GetComponent<ObjSizeModifier> ();
					objModScript1.speed = Random.Range (5f, 10f);
					objModScript1.maxHeight = Random.Range (50, 70);
					objModScript1.minHeight = Random.Range (30, 40);
					objModScript1.enabled = true;
				} 
				else {
					size0.y = Random.Range (heightRandomRange.x, heightRandomRange.y);
					size1.y = Random.Range (heightRandomRange.x, heightRandomRange.y);
				}

				obj0.transform.localScale = size0;
				obj0.transform.parent = this.gameObject.transform.GetChild (0).transform;

				obj1.transform.localScale = size1;
				obj1.transform.parent = this.gameObject.transform.GetChild (1).transform;

				if (j == perColumn) {
					lastCubePos = obj1.transform.position; 
				}
			}  
		}
	}

	public void ChangeTerrain(int terrain){   // 1:Sci Fi  ,,, 0:Alt Color 
		if(terrain==1){
			this.transform.GetChild (1).gameObject.SetActive (true);
			this.transform.GetChild (0).gameObject.SetActive (false);
		}
		else{
			this.transform.GetChild (0).gameObject.SetActive (true);
			this.transform.GetChild (1).gameObject.SetActive (false);
		}
	}

}

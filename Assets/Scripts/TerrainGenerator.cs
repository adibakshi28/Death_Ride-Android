using UnityEngine;
using System.Collections;
           // To increase overall size of Terrain generated ust increase size of prefab used to generate terain
public class TerrainGenerator : MonoBehaviour {

	public GameObject cube; //, tunnelOverhead;
	public Vector2 heightRandomRange;
	public bool altMaterial=false;
	public int perColumn = 10, obsticalFrequency = 4, collectableFrequency=100,matChangeDistance=20000,obsChangeDistance=5000 ,obsStartDistance=20;
	public Transform terrainGenerationPoint;
	public Material[] cubeMaterials, pyramidMaterials, sphereMaterials, capsuleMaterials, altCubeMaterials;
	public Material altCommonMaterial, altObsMaterial;

	private Vector3 lastCubePos;
	private long x, e, x2;
	private GameObject tunnel;
	LevelDataController levelControllerScript;


	void Awake () {

		levelControllerScript = GameObject.FindGameObjectWithTag ("LevelDataController").GetComponent<LevelDataController> ();
		levelControllerScript.currentColor = cubeMaterials [0].color;
		obsticalFrequency = PlayerPrefs.GetInt ("Toughness");
		perColumn = perColumn + (PlayerPrefs.GetInt ("Toughness") - 4);

		if (PlayerPrefs.GetInt ("TerrainType") == 0) {
			altMaterial = true;
		} 
		else {
			altMaterial = false;
		}

		for (int i = 0; i < 200; i++) {   // total rows	

			x = Random.Range (3, perColumn-1);

			for (int j = 1; j < perColumn+1; j++) {  // total columns
				Vector3 pos= new Vector3((j*cube.transform.localScale.x)-((cube.transform.localScale.x*perColumn)/2)+transform.position.x-(cube.transform.localScale.x/2),transform.position.y,i*cube.transform.localScale.z+transform.position.z);
				GameObject obj= Instantiate (cube, pos, Quaternion.identity)as GameObject;

				if (altMaterial) {
					if (i % 2 == 0) {
						if (j % 2 == 0) {
							obj.GetComponent<Renderer> ().material = altCommonMaterial;
						} else {
							obj.GetComponent<Renderer> ().material = altCubeMaterials [0];
						}
					} else {
						if (j % 2 == 0) {
							obj.GetComponent<Renderer> ().material = altCubeMaterials [0];
						} else {
							obj.GetComponent<Renderer> ().material = altCommonMaterial;
						}
					}
				}

				else {
					obj.GetComponent<Renderer> ().material = cubeMaterials[0];
				}
			
				Vector3 size = obj.transform.localScale;
				if ((j == 1) || (j == perColumn)) {
					size.y = Random.Range (25, 30);
					if (altMaterial) {
						obj.GetComponent<Renderer> ().material = altObsMaterial;
					}
				} 
				else {
					if(((x==j)&&(i%obsticalFrequency==0))&&(i>obsStartDistance)){
						if (altMaterial) {
							obj.GetComponent<Renderer> ().material = altObsMaterial;
						}
						size.y = Random.Range (30, 35);
					}
					else{
						size.y = Random.Range (heightRandomRange.x, heightRandomRange.y);
					}
				}
				obj.transform.localScale = size;
				obj.transform.parent = this.gameObject.transform;
				lastCubePos = obj.transform.position;
			}
		}
	}

	void Update(){
		if (terrainGenerationPoint.position.z > lastCubePos.z) {
			e++;
			x = Random.Range (3, perColumn-1);
			x2 = Random.Range ((int)0, (int)3);
			for (int j = 1; j < perColumn + 1; j++) {
				Vector3 pos= new Vector3((j*cube.transform.localScale.x)-((cube.transform.localScale.x*perColumn)/2)+transform.position.x-(cube.transform.localScale.x/2),transform.position.y,(lastCubePos.z+cube.transform.localScale.z)+transform.position.z);
				GameObject obj= Instantiate (cube, pos, Quaternion.identity)as GameObject;

				int ind = ((int)(terrainGenerationPoint.position.z / matChangeDistance)) % cubeMaterials.Length;

				if (altMaterial) {
					if (e % 2 == 0) {
						if (j % 2 == 0) {
							obj.GetComponent<Renderer> ().material = altCommonMaterial;
						} else {
							obj.GetComponent<Renderer> ().material = altCubeMaterials [ind];
						}
					} else {
						if (j % 2 == 0) {
							obj.GetComponent<Renderer> ().material = altCubeMaterials [ind];
						} else {
							obj.GetComponent<Renderer> ().material = altCommonMaterial;
						}
					}
				}

				else {
					obj.GetComponent<Renderer> ().material = cubeMaterials [ind];
				}
					
				int currentColorInd = ((int)(terrainGenerationPoint.parent.transform.position.z / matChangeDistance)) % cubeMaterials.Length;
				levelControllerScript.currentColor = cubeMaterials [currentColorInd].color;

				Vector3 size = obj.transform.localScale;

				switch ((int)(terrainGenerationPoint.position.z / obsChangeDistance) % 7) {

				case 0:
					// ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ TYPE 1 ~~~~~~~~~~~~~~~~~~~~~~~~~~~~(Static longated cubiods)

					if ((j == 1) || (j == perColumn)) {
						ObjSizeModifier objModScript;
						objModScript=obj.GetComponent<ObjSizeModifier> ();
						objModScript.speed = Random.Range (3f, 7f);
						objModScript.maxHeight = Random.Range (25, 30);
						objModScript.minHeight = Random.Range (15, 20);
						objModScript.enabled = true;
						if (altMaterial) {
							obj.GetComponent<Renderer> ().material = altObsMaterial;
						}
					} 
					else {
						if((x==j)&&(e%obsticalFrequency==0)){
							if (altMaterial) {
								obj.GetComponent<Renderer> ().material = altObsMaterial;
							}
							size.y = Random.Range (30, 35);
							e=0;
						}
						else{
							size.y = Random.Range (heightRandomRange.x, heightRandomRange.y);
						}
					}
					break;

				case 1:
					// ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ TYPE 2 ~~~~~~~~~~~~~~~~~~~~~~~~~~~~(Static divide)

					if ((j == 1) || (j == perColumn)) {
						ObjSizeModifier objModScript;
						objModScript=obj.GetComponent<ObjSizeModifier> ();
						objModScript.speed = Random.Range (3f, 7f);
						objModScript.maxHeight = Random.Range (25, 30);
						objModScript.minHeight = Random.Range (15, 20);
						objModScript.enabled = true;
						if (altMaterial) {
							obj.GetComponent<Renderer> ().material = altObsMaterial;
						}
					} 
					else {
						if((((j+x2)%4==0))&&(e%(obsticalFrequency+6)==0)){
							size.y = Random.Range (30, 35);
							if (altMaterial) {
								obj.GetComponent<Renderer> ().material = altObsMaterial;
							}
						}
						else{
							size.y = Random.Range (heightRandomRange.x, heightRandomRange.y);
						}
					}
					break;

				case 2:
					// ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ TYPE 3 ~~~~~~~~~~~~~~~~~~~~~~~~~~~~(Divide Dynamic)

					if ((j == 1) || (j == perColumn)) {
						ObjSizeModifier objModScript;
						objModScript=obj.GetComponent<ObjSizeModifier> ();
						objModScript.speed = Random.Range (3f, 7f);
						objModScript.maxHeight = Random.Range (25, 30);
						objModScript.minHeight = Random.Range (15, 20);
						objModScript.enabled = true;
						if (altMaterial) {
							obj.GetComponent<Renderer> ().material = altObsMaterial;
						}
					} 
					else {
						if((((j+x2)%4==0))&&(e%(obsticalFrequency+10)==0)){
							ObjSizeModifier objModScript;
							objModScript = obj.GetComponent<ObjSizeModifier> ();
							objModScript.speed = Random.Range (20f, 35f);
							objModScript.maxHeight = Random.Range (55, 60);
							objModScript.minHeight = Random.Range (10, 20);
							objModScript.enabled = true;
							if (altMaterial) {
								obj.GetComponent<Renderer> ().material = altObsMaterial;
							}
						}
						else{
							size.y = Random.Range (heightRandomRange.x, heightRandomRange.y);
						}
					}
					break;

		/*		case 3:
					// ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ TYPE 4 ~~~~~~~~~~~~~~~~~~~~~~~~~~~~(hale in the wall)

					if ((j == 1) || (j == perColumn)) {
						size.y = Random.Range (40, 45);
						if (altMaterial) {
							obj.GetComponent<Renderer> ().material = altObsMaterial;
						}
					} 
					else {
						if((j!=(x-1))&&(j!=x)&&(j!=(x+1))&&(e%(obsticalFrequency+20)==0)){
							//	size.y = 40;
							ObjSizeModifier objModScript;
							objModScript = obj.GetComponent<ObjSizeModifier> ();
							objModScript.speed = x*2;
							objModScript.maxHeight = 45;
							objModScript.minHeight = 20;
							objModScript.enabled = true;
							if (altMaterial) {
								obj.GetComponent<Renderer> ().material = altObsMaterial;
							}
						}
						else{
							size.y = Random.Range (heightRandomRange.x, heightRandomRange.y);
						}
					}
					break;*/


				case 3:
					// ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ TYPE 5 ~~~~~~~~~~~~~~~~~~~~~~~~~~~~(static spheres)

					if ((j == 1) || (j == perColumn)) {
						ObjSizeModifier objModScript;
						objModScript=obj.GetComponent<ObjSizeModifier> ();
						objModScript.speed = Random.Range (3f, 7f);
						objModScript.maxHeight = Random.Range (25, 30);
						objModScript.minHeight = Random.Range (15, 20);
						objModScript.enabled = true;
						if (altMaterial) {
							obj.GetComponent<Renderer> ().material = altObsMaterial;
						}
					} else {
						if ((x == j) && (e % obsticalFrequency == 0)) {
							ObjAdder objModScript;
							objModScript = obj.GetComponent<ObjAdder> ();
							objModScript.type = 2;
							objModScript.heightAbove = Random.Range (3, 7);
							objModScript.sizeMultiplier = Random.Range (0.75f, 1);
							objModScript.enabled = true;
							e = 0;
							if (altMaterial) {
								obj.GetComponent<Renderer> ().material = altObsMaterial;
								objModScript.mat = altObsMaterial;
							} 
							else {
								objModScript.mat = sphereMaterials [ind];
							}
						} else {
							size.y = Random.Range (heightRandomRange.x, heightRandomRange.y);
						}
					}
					break;

				case 4:   
					// ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ TYPE 6 ~~~~~~~~~~~~~~~~~~~~~~~~~~~~ (dynamic capsules)

					if ((j == 1) || (j == perColumn)) {
						ObjSizeModifier objModScript;
						objModScript=obj.GetComponent<ObjSizeModifier> ();
						objModScript.speed = Random.Range (3f, 7f);
						objModScript.maxHeight = Random.Range (40, 55);
						objModScript.minHeight = Random.Range (15, 25);
						objModScript.enabled = true;
						if (altMaterial) {
							obj.GetComponent<Renderer> ().material = altObsMaterial;
						}
					} 
					else {
						if ((x == j) && (e % obsticalFrequency == 0)) {
							ObjAdder objModScript;
							objModScript = obj.GetComponent<ObjAdder> ();
							objModScript.type = 4;
							objModScript.sizeMultiplier = 1;
							objModScript.ossSpeed = Random.Range (-50, 50);
							objModScript.enabled = true;
							e = 0;
							if (altMaterial) {
								obj.GetComponent<Renderer> ().material = altObsMaterial;
								objModScript.mat = altObsMaterial;
							} 
							else {
								objModScript.mat = capsuleMaterials [ind];
							}
						} else {
							size.y = Random.Range (heightRandomRange.x, heightRandomRange.y);
						}
					}
					break;

				case 5:
					// ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ TYPE 7 ~~~~~~~~~~~~~~~~~~~~~~~~~~~~(dynamic pyramids)

					if ((j == 1) || (j == perColumn)) {
						ObjSizeModifier objModScript;
						objModScript=obj.GetComponent<ObjSizeModifier> ();
						objModScript.speed = Random.Range (3f, 7f);
						objModScript.maxHeight = Random.Range (25, 30);
						objModScript.minHeight = Random.Range (15, 20);
						objModScript.enabled = true;
						if (altMaterial) {
							obj.GetComponent<Renderer> ().material = altObsMaterial;
						}
					} 
					else {
						if((x==j)&&(e%obsticalFrequency==0)){
							ObjAdder objModScript;
							objModScript=obj.GetComponent<ObjAdder> ();
							objModScript.type=3;
							objModScript.heightAbove = Random.Range (-1,1);
							objModScript.enabled = true;
							ObjSizeModifier objModScript2;
							objModScript2 = obj.GetComponent<ObjSizeModifier> ();
							objModScript2.speed = Random.Range (10, 20);
							objModScript2.maxHeight = Random.Range (20, 30);
							objModScript2.minHeight = Random.Range (10, 15);
							objModScript2.enabled = true;
							obj.GetComponent<Renderer> ().enabled = false;
							e=0;
							if (altMaterial) {
								obj.GetComponent<Renderer> ().material = altObsMaterial;
								objModScript.mat = altObsMaterial;
							}
							else {
								objModScript.mat = pyramidMaterials [ind];
							}
						}
						else{
							size.y = Random.Range (heightRandomRange.x, heightRandomRange.y);
						}
					}
					break;

				case 6:
					// ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ TYPE 8 ~~~~~~~~~~~~~~~~~~~~~~~~~~~~ (static diamonds)

					if ((j == 1) || (j == perColumn)) {
						ObjSizeModifier objModScript;
						objModScript=obj.GetComponent<ObjSizeModifier> ();
						objModScript.speed = Random.Range (3f, 7f);
						objModScript.maxHeight = Random.Range (25, 30);
						objModScript.minHeight = Random.Range (15, 20);
						objModScript.enabled = true;
						if (altMaterial) {
							obj.GetComponent<Renderer> ().material = altObsMaterial;
						}
					} else {
						if ((x == j) && (e % obsticalFrequency == 0)) {
							ObjAdder objModScript;
							objModScript = obj.GetComponent<ObjAdder> ();
							objModScript.type = 1;
							objModScript.heightAbove = Random.Range (17, 20);
							objModScript.sizeMultiplier = Random.Range (2, 3);
							objModScript.enabled = true;
							e = 0;
							if (altMaterial) {
								obj.GetComponent<Renderer> ().material = altObsMaterial;
								objModScript.mat = altObsMaterial;
							}
							else {
								objModScript.mat = pyramidMaterials [ind];
							}
						} else {
							size.y = Random.Range (heightRandomRange.x, heightRandomRange.y);
						}
					}
					break;

				}  
					
				obj.transform.localScale = size;
				obj.transform.parent = this.gameObject.transform;
				if (j == perColumn) {
					lastCubePos = obj.transform.position; 
				}
			}  
		}
	}
		
}

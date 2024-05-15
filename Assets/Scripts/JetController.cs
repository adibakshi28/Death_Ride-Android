using UnityEngine;
using System.Collections;

public class JetController : MonoBehaviour {

	public float forwardVelocity=100;
	public float steeringVelocity=2.5f;
	public float accleration = 0.5f;
//	public float steeringRotFactor = 25;
	public GameObject explosion;

	private bool gameOver = false;

	Rigidbody rb;
	ConstantForce constFor;
	GameObject jetModel;

	LevelDataController levelControllerScript;

	void Awake(){
		levelControllerScript = GameObject.FindGameObjectWithTag ("LevelDataController").GetComponent<LevelDataController> ();
	}

	void Start () {
		rb = GetComponent<Rigidbody> ();
		constFor = GetComponent<ConstantForce> ();
		jetModel = this.gameObject.transform.GetChild (0).transform.gameObject;
	}

	void FixedUpdate () {
		if (levelControllerScript.gameStart) {
			if (Application.platform==RuntimePlatform.Android) {
				if (Mathf.Abs (Input.acceleration.x) > 0.025f) {
					transform.Translate (-Input.acceleration.x * steeringVelocity * Time.deltaTime, 0, 0);
					Vector3 temp = transform.position;
					temp.y = 0;
					transform.position = temp;

					/*		float zRotation = Input.acceleration.x * Time.deltaTime * steeringRotFactor;
				this.gameObject.transform.Rotate (0, 0, zRotation);
				Vector3 rot = transform.eulerAngles;
				rot.z = (Mathf.Asin (Mathf.Clamp (Mathf.Sin (rot.z / 57.3f), -0.95f, 0.95f))) * 57.3f;
				// -0.25881 and 0.25881 are sin of -15 and 15 degree resp. 57.3 is used to convert deg to rad and vice verse
				transform.eulerAngles = rot;*/

					Vector3 rot = transform.eulerAngles;
					rot.z = 90 * Input.acceleration.x;
					transform.eulerAngles = rot;
				} 
				else {
					Vector3 rot = transform.eulerAngles;
					rot.z = 0;
					transform.eulerAngles = rot;
				}
			} 
			else {
				if (Mathf.Abs (Input.GetAxis("Horizontal")) > 0.05f) {
					transform.Translate(-Input.GetAxis("Horizontal") * steeringVelocity*Time.deltaTime,0,0);
					Vector3 temp = transform.position;
					temp.y = 0;
					transform.position = temp;

					Vector3 rot = transform.eulerAngles;
					rot.z = 45 * Input.GetAxis ("Horizontal");
					transform.eulerAngles = rot;
				}
				else {
					Vector3 rot = transform.eulerAngles;
					rot.z = 0;
					transform.eulerAngles = rot;
				}
			}
		}

	  }


	public void GameStart(){
		rb.velocity = new Vector3 (0, 0, forwardVelocity);
		constFor.force = new Vector3 (0, 0, accleration);
	}
		
	void GameOver(){
		rb.isKinematic = true;
		GameObject blast;
		blast = Instantiate (explosion, transform.position, Quaternion.identity)as GameObject;
		if (PlayerPrefs.GetInt ("SoundEnabled") == 1) {
			blast.GetComponent<AudioSource> ().Play ();
		}
		Destroy (jetModel);
		levelControllerScript.GameOver ();
		this.gameObject.GetComponent<JetController> ().enabled = false;
	}


	void OnCollisionEnter(Collision collision)
	{
		if (((collision.gameObject.tag == "Enemy")||(collision.gameObject.tag == "Bounds"))&&(!gameOver)) {
			gameOver = true;
			GameOver ();
		}
	}

/*	void OnTriggerEnter(Collider other) {
		if ((other.gameObject.tag == "Collectable")&&(!gameOver)) {
			other.gameObject.GetComponent<BoxCollider> ().enabled = false;
			other.gameObject.GetComponent<AudioSource> ().Play ();
		}
	}*/
}

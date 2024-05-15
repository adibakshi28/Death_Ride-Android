using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Cinamatic : MonoBehaviour {

	public GameObject jet, bkMusicController;
	public Transform cameraTransform;
	public int jetSpeed = 100;
	public float sceneChangeTime=20, volumeVariationSpeed = 0.02f, pitchvariationSpeed = 0.02f,finalBkAudioVolume=0.1f;
	public Vector2 volumeVariation, pitchVariation;

	private GameObject jetObject;

	AudioSource exhaustAud,bkAudio;

	void Start () {
		Vector3 pos = new Vector3 (cameraTransform.position.x, cameraTransform.position.y - 5, cameraTransform.position.z - 10);
		jetObject = Instantiate (jet, pos, Quaternion.identity)as GameObject;
		bkAudio = bkMusicController.GetComponent<AudioSource> ();
		exhaustAud = jetObject.transform.GetChild (0).GetComponent<AudioSource> ();
		if (PlayerPrefs.GetInt ("SoundEnabled") == 1) {
			exhaustAud.Play ();
		} 
		else {
			exhaustAud.Stop ();
		}
		exhaustAud.volume = volumeVariation.x;
		exhaustAud.pitch = pitchVariation.x;
		StartCoroutine (SceneChange());
		Handheld.Vibrate ();
	}

	void Update () {
		jetObject.transform.Translate (0, 0, jetSpeed * Time.deltaTime);
		if (exhaustAud.volume > volumeVariation.y) {
			exhaustAud.volume = exhaustAud.volume - (Time.deltaTime * volumeVariationSpeed);
		} 
		else {
			exhaustAud.volume = volumeVariation.y;
		}
		if (exhaustAud.pitch > pitchVariation.y) {
			exhaustAud.pitch = exhaustAud.pitch - (Time.deltaTime * pitchvariationSpeed);
		} 
		else {
			exhaustAud.pitch = pitchVariation.y;
		}
		if (bkAudio.volume > finalBkAudioVolume) {
			bkAudio.volume = bkAudio.volume - (Time.deltaTime * volumeVariationSpeed);
		} 
		else {
			bkAudio.volume = finalBkAudioVolume;
		}


	}

	IEnumerator SceneChange(){
		yield return new WaitForSeconds (sceneChangeTime);
		SimpleSceneFader.ChangeSceneWithFade("Game_Static 2");
	}

}

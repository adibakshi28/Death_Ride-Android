using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelDataController : MonoBehaviour {

	public GameObject bkMusicController, lvlCanvas, Camera1, Camera2, Camera3, startCamera,exhaust, scoreTextObject, musicOnBtn, musicOffBtn, soundOnBtn, soundOffBtn, terrainGenerator;
	public int scoreMultiplier = 2;
	public float GameStartDelay=1.5f;

	[HideInInspector]
	public int score = 0;
	[HideInInspector]
	public Color currentColor;
	[HideInInspector]
	public bool gameOver=false,gameStart=false;

	Text scoreTxt;
	AudioSource exhaustAud,bkAud,aud;
	GameObject jet;
	CanvasController canvasScript;
//	GPGSController gpsScript;
//	GameDataController gameDataScript;

	void Awake(){
//		gpsScript = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GPGSController> ();
//		gameDataScript = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameDataController> ();
		jet = GameObject.FindGameObjectWithTag ("Player");
		scoreMultiplier = scoreMultiplier + 4 - PlayerPrefs.GetInt ("Toughness");
	}

	void Start () {
		canvasScript = lvlCanvas.GetComponent<CanvasController> ();
		exhaustAud = exhaust.GetComponent<AudioSource> ();
		bkAud = bkMusicController.GetComponent<AudioSource> ();
		aud = GetComponent<AudioSource> ();
		scoreTxt = scoreTextObject.GetComponent<Text> ();

		scoreTxt.text = " ";

		StartCoroutine (StartGame ());

	}


	public void CameraChange(){
		if (PlayerPrefs.GetInt ("SoundEnabled") == 1) {
			aud.Play ();
		}
		PlayerPrefs.SetInt ("CameraView", (PlayerPrefs.GetInt ("CameraView") + 1) % 3);
		CameraSet ();
	}

	void CameraSet(){
		switch (PlayerPrefs.GetInt ("CameraView")) {
		case 0:
			Camera1.GetComponent<Camera> ().enabled = true;
			Camera1.GetComponent<AudioListener> ().enabled = true;
			Camera2.GetComponent<Camera> ().enabled = false;
			Camera2.GetComponent<AudioListener> ().enabled = false;
			Camera3.GetComponent<Camera> ().enabled = false;
			Camera3.GetComponent<AudioListener> ().enabled = false;
			break;
		case 1:
			Camera1.GetComponent<Camera> ().enabled = false;
			Camera1.GetComponent<AudioListener> ().enabled = false;
			Camera2.GetComponent<Camera> ().enabled = true;
			Camera2.GetComponent<AudioListener> ().enabled = true;
			Camera3.GetComponent<Camera> ().enabled = false;
			Camera3.GetComponent<AudioListener> ().enabled = false;
			break;
		case 2:
			Camera1.GetComponent<Camera> ().enabled = false;
			Camera1.GetComponent<AudioListener> ().enabled = false;
			Camera2.GetComponent<Camera> ().enabled = false;
			Camera2.GetComponent<AudioListener> ().enabled = false;
			Camera3.GetComponent<Camera> ().enabled = true;
			Camera3.GetComponent<AudioListener> ().enabled = true;
			break;
		}
	}

	void Update(){
		if (gameStart) {
			if(!gameOver){
				score = (int)(jet.transform.position.z) * scoreMultiplier;
				scoreTxt.text = score.ToString ();

				if (Input.GetKeyDown (KeyCode.Escape)) {
					Pause ();
				}
				//			StartCoroutine (CheckGamePlayAchievement ());
			}

			canvasScript.OutlineColourMatch (currentColor);
		}
	}


	public void GameOver (){
		gameOver = true;

//		StartCoroutine (CheckGameOverAchievement ());
//		gpsScript.PostScoreInLeaderBoard (score);

		bool newHighScore = false;
		Camera1.GetComponent<CameraShake> ().enabled = true;
		Camera2.GetComponent<CameraShake> ().enabled = true;
		Camera3.GetComponent<CameraShake> ().enabled = true;
		Handheld.Vibrate ();
		if (PlayerPrefs.GetInt ("Highscore") < score) {
			PlayerPrefs.SetInt ("Highscore", score);
			newHighScore = true;
		}
		bkAud.volume = bkAud.volume / 2;
		canvasScript.GameOver (currentColor,newHighScore);
//		StartCoroutine (GameOverAdShow ());
	}

	public void Menu(){
		if (PlayerPrefs.GetInt ("SoundEnabled") == 1) {
			aud.Play ();
		}
		Time.timeScale = 1;
		SimpleSceneFader.ChangeSceneWithFade("Menu");
	}

	public void Restart (){
		if (PlayerPrefs.GetInt ("SoundEnabled") == 1) {
			aud.Play ();
		}
		Time.timeScale = 1;
		SceneManager.LoadScene ("Game_Static 2");
	}

	public void Pause(){
		if (PlayerPrefs.GetInt ("SoundEnabled") == 1) {
			aud.Play ();
		}
		exhaustAud.Stop ();
		canvasScript.Pause(currentColor);
	}

	public void Resume(){
		if (PlayerPrefs.GetInt ("SoundEnabled") == 1) {
			aud.Play ();
			exhaustAud.Play ();
		}
		canvasScript.Resume ();
	}

	public void MusicControl(){
		if (PlayerPrefs.GetInt ("SoundEnabled") == 1) {
			aud.Play ();
		}
		if (PlayerPrefs.GetInt ("MusicEnabled") == 1) {
			PlayerPrefs.SetInt ("MusicEnabled", 0);
			bkAud.Stop ();
			musicOffBtn.SetActive (false);
			musicOnBtn.SetActive (true);
		}
		else {
			PlayerPrefs.SetInt ("MusicEnabled", 1);
			bkAud.Play ();
			musicOffBtn.SetActive (true);
			musicOnBtn.SetActive (false);
		}
	}

	public void SoundControl(){
		if (PlayerPrefs.GetInt ("SoundEnabled") == 1) {
			PlayerPrefs.SetInt ("SoundEnabled", 0);
			soundOffBtn.SetActive (false);
			soundOnBtn.SetActive (true);
		}
		else {
			PlayerPrefs.SetInt ("SoundEnabled", 1);
			aud.Play ();
			soundOffBtn.SetActive (true);
			soundOnBtn.SetActive (false);
		}
	}

	IEnumerator StartGame(){
		if (PlayerPrefs.GetInt ("MusicEnabled") == 1) {
			bkAud.Play ();
			musicOffBtn.SetActive (true);
			musicOnBtn.SetActive (false);
		}
		else {
			bkAud.Stop ();
			musicOffBtn.SetActive (false);
			musicOnBtn.SetActive (true);
		}

		yield return new WaitForSeconds (GameStartDelay);

		startCamera.GetComponent<Camera> ().enabled = false;
		startCamera.GetComponent<AudioListener> ().enabled = false;
		CameraSet ();
		scoreTxt.text = score.ToString();

		if (PlayerPrefs.GetInt ("SoundEnabled") == 1) {
			exhaustAud.Play ();
			soundOffBtn.SetActive (true);
			soundOnBtn.SetActive (false);
		}
		else {
			exhaustAud.Stop ();
			soundOffBtn.SetActive (false);
			soundOnBtn.SetActive (true);
		}

		jet.GetComponent<JetController> ().GameStart ();

		gameStart = true;

	}

/*		
	IEnumerator CheckGamePlayAchievement(){
		gpsScript.ScoreAchievements (score);
		yield return null;
	}

	IEnumerator CheckGameOverAchievement(){
		gpsScript.GameOverAchievements (score);
		yield return null;
	} 
		
	IEnumerator GameOverAdShow(){
		yield return new WaitForSeconds (3);
		gameDataScript.showInterstitialAd ();   // Display Ads
	}*/

}

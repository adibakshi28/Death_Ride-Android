using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour {

	public GameObject bkAudioController, cinamaticController, musicOnBtn, musicOffBtn, soundOnBtn, soundOffBtn, menuCanvas, easyBtn, mediumBtn, hardBtn, achievementsUIBtn, leaderboardUIBtn;
	public Text highScoreTxt;
	public Color toughnessBtnSelectColor;

	AudioSource aud,bkAud;
	Animator canvasAnim;
	GPGSController gpsScript;

	void Start () {
		gpsScript = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GPGSController> ();
		aud = GetComponent<AudioSource> ();
		bkAud = bkAudioController.GetComponent<AudioSource> ();
		canvasAnim = menuCanvas.GetComponent<Animator> ();

		highScoreTxt.text = "HIGHSCORE :" + PlayerPrefs.GetInt ("Highscore");
		SetToughnessUI ();

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

		if (PlayerPrefs.GetInt ("SoundEnabled") == 1) {
			soundOffBtn.SetActive (true);
			soundOnBtn.SetActive (false);
		}
		else {
			soundOffBtn.SetActive (false);
			soundOnBtn.SetActive (true);
		}

		Login ();
	}

	void Update(){
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.Quit ();
		}
	}


	public void Play (){
		if (PlayerPrefs.GetInt ("SoundEnabled") == 1) {
			aud.Play ();
		}
		StartCoroutine (PlayCina ());
	}
	IEnumerator PlayCina(){
		canvasAnim.SetTrigger ("Play");
		yield return new WaitForSeconds (0.5f);
		cinamaticController.GetComponent<Cinamatic> ().enabled = true;
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
		Debug.Log ("sound function called");
		if (PlayerPrefs.GetInt ("SoundEnabled") == 1) {
			Debug.Log ("In if");
			PlayerPrefs.SetInt ("SoundEnabled", 0);
			soundOffBtn.SetActive (false);
			soundOnBtn.SetActive (true);
		}
		else {
			Debug.Log ("In else");
			PlayerPrefs.SetInt ("SoundEnabled", 1);
			aud.Play ();
			soundOffBtn.SetActive (true);
			soundOnBtn.SetActive (false);
		}
	}

	public void Toughness(int obsticalFrequency){
		if (PlayerPrefs.GetInt ("SoundEnabled") == 1) {
			aud.Play ();
		}
		PlayerPrefs.SetInt ("Toughness", obsticalFrequency); 
		SetToughnessUI ();
	}

	void SetToughnessUI(){
		switch(PlayerPrefs.GetInt ("Toughness") ){
		case 4:
			PlayerPrefs.SetInt ("Toughness", 4);
			easyBtn.GetComponent<RectTransform> ().sizeDelta = new Vector2 (112.5f, 50f);
			easyBtn.GetComponent<Image> ().color = Color.white;
			mediumBtn.GetComponent<RectTransform> ().sizeDelta = new Vector2 (112.5f, 50f);
			mediumBtn.GetComponent<Image> ().color = Color.white;
			hardBtn.GetComponent<RectTransform> ().sizeDelta = new Vector2 (112.5f, 60f);
			hardBtn.GetComponent<Image> ().color = toughnessBtnSelectColor;
			break;
		case 5:
			PlayerPrefs.SetInt ("Toughness", 5);
			easyBtn.GetComponent<RectTransform> ().sizeDelta = new Vector2 (112.5f, 50f);
			easyBtn.GetComponent<Image> ().color = Color.white;
			mediumBtn.GetComponent<RectTransform> ().sizeDelta = new Vector2 (112.5f, 60f);
			mediumBtn.GetComponent<Image> ().color = toughnessBtnSelectColor;
			hardBtn.GetComponent<RectTransform> ().sizeDelta = new Vector2 (112.5f, 50f);
			hardBtn.GetComponent<Image> ().color = Color.white;
			break;
		case 6:
			PlayerPrefs.SetInt ("Toughness", 6);
			easyBtn.GetComponent<RectTransform> ().sizeDelta = new Vector2 (112.5f, 60f);
			easyBtn.GetComponent<Image> ().color = toughnessBtnSelectColor;
			mediumBtn.GetComponent<RectTransform> ().sizeDelta = new Vector2 (112.5f, 50f);
			mediumBtn.GetComponent<Image> ().color = Color.white;
			hardBtn.GetComponent<RectTransform> ().sizeDelta = new Vector2 (112.5f, 50f);
			hardBtn.GetComponent<Image> ().color = Color.white;
			break;
		default:
			PlayerPrefs.SetInt ("Toughness", 5);
			SetToughnessUI ();
			break;
		}
	}

	public void MatChangeBtn(){
		if (PlayerPrefs.GetInt ("TerrainType") == 0) {
			PlayerPrefs.SetInt("TerrainType",1);
			GetComponent<MenuTerrainGenerator> ().ChangeTerrain (1);
		} 
		else {
			PlayerPrefs.SetInt("TerrainType",0);
			GetComponent<MenuTerrainGenerator> ().ChangeTerrain (0);
		}
	}

	public void Login(){
		gpsScript.Signup (achievementsUIBtn,leaderboardUIBtn);
	}

	public void ShowAchievementUI(){
		gpsScript.ShowAchievementsUI ();
	}

	public void ShowLeaderboardUI(){
		gpsScript.ShowLeaderBoard ();
	}


}

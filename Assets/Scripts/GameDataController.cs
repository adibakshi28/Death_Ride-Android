using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using GoogleMobileAds.Api;
                                                       // Remember to De-Comment production ad code n comment out Test ad code
public class GameDataController : MonoBehaviour {

	public int currentVersion;                       // increment this field by 1 in every newer versions of the game release
	public string instiantialID;

	InterstitialAd interstitial;

	void Start () {
		if (PlayerPrefs.GetInt ("hasPlayed") < 50) {                  // (50 is used to ensure hasPlayed has a value less than 100 which indicates that the game has been played previously...... expect that 100 and 50 as numbers ha no other significance)
			PlayerPrefs.SetInt("hasPlayed",100);
			Debug.Log ("Application Running for the first time");
			PlayerPrefs.SetInt ("SoundEnabled",1);    // 1:Enabled   ,,,   0: Disabled
			PlayerPrefs.SetInt("MusicEnabled",1);     // 1:Enabled   ,,,   0: Disabled
			PlayerPrefs.SetInt("CameraView",1);        // 0,1,2 resp.
			PlayerPrefs.SetInt("Highscore",0);
			PlayerPrefs.SetInt("TerrainType",0);       // 1:Sci Fi  ,,, 0:Alt Color 
			PlayerPrefs.SetInt ("Toughness", 6);       // 4,5,6  (Obstical Frequency)   (it determines obstical score multiplier,freq,check hardcore achievement and perColumn attributes of Terrain Generator) 
			//Game Default Settings
		} 
	
		PlayerPrefs.SetInt("timesLaunched",(PlayerPrefs.GetInt("timesLaunched")+1));     //  incriments by 1 every time the application is launched 

		if (!(PlayerPrefs.GetInt ("version") == currentVersion)) {
			PlayerPrefs.SetInt ("version", currentVersion);
			//  put all the new player pref statements or changes to previously existant in future versions here eg. new players , coin gifts etc

		}

		DontDestroyOnLoad (this.gameObject);

		RequestInterstitialAds();

		Screen.sleepTimeout = SleepTimeout.NeverSleep;

		Screen.autorotateToLandscapeLeft = true;
		Screen.autorotateToLandscapeRight = true;
		Screen.autorotateToPortrait = false;
		Screen.autorotateToPortraitUpsideDown = false;

		SceneManager.LoadScene ("Menu");

	}

	private void RequestInterstitialAds()
	{
		// Initialize an InterstitialAd.
		interstitial = new InterstitialAd(instiantialID);

		//***Test***
	/*	AdRequest request = new AdRequest.Builder()
			.AddTestDevice(AdRequest.TestDeviceSimulator)       // Simulator.
			.AddTestDevice("2077ef9a63d2b398840261c8221a0c9b")  // My test device.
			.Build();  */

		//***Production***
			AdRequest request = new AdRequest.Builder().Build();

		// Load the interstitial with the request.
		interstitial.LoadAd(request);
	}


	public void showInterstitialAd()
	{
		//Show Ad
		if (interstitial.IsLoaded ()) {
			interstitial.Show ();
		} 
		else {
			RequestInterstitialAds ();
		}
	}
}




/* Release notes:
 * remove comments in LDC and MDC about GPS code
 * Put version no.
 * put ad id
 * de-commect test ad code an comment out test ad code
 *
 */
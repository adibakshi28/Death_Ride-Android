using UnityEngine;
using System.Collections;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;

public class GPGSController : MonoBehaviour {

	[HideInInspector]
	public bool connectedToGooglePlaySevice=false,gameAddictAchievementCalled=false;

	void Start () {
		PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();
		PlayGamesPlatform.InitializeInstance(config);
		// Activate the Google Play Games platform
		PlayGamesPlatform.Activate();
	}

	public void Signup( GameObject achievementsUIBtn,GameObject leaderboardUIBtn){
		if (!connectedToGooglePlaySevice) {
			Debug.Log ("Tring to Sign user up");
			// authenticate user:
			Social.localUser.Authenticate((bool success) => {
				connectedToGooglePlaySevice=success;
				if (success) {
					achievementsUIBtn.SetActive (true);
					leaderboardUIBtn.SetActive (true);
				}
				else{
					achievementsUIBtn.SetActive (false);
					leaderboardUIBtn.SetActive (false);
				}
				if(!gameAddictAchievementCalled){
					gameAddictAchievementCalled=true;
					GameAddictAchievement(); // Call the number of times launched achievement function
				}
			});
		}
		else {
			achievementsUIBtn.SetActive (true);
			leaderboardUIBtn.SetActive (true);
		}
	}

	public void ShowAchievementsUI(){
		// show achievements UI
		Debug.Log("Showing Achievement Login");
		Social.ShowAchievementsUI();
	}

	public void ShowLeaderBoard(){
		// show leaderboard UI
		Debug.Log("Showing Leader Board");
		Social.ShowLeaderboardUI();
	}


	public void PostScoreInLeaderBoard(int score){
		Debug.Log ("Posting Score in leader board");
		Social.ReportScore(score, GPGSIds.leaderboard_all_time_best, (bool success) => {
			// handle success or failure
		});
	}



	// Indivudial Achievements Functions 

	public void GameBeginsAchievement(){    // Done
		Social.ReportProgress(GPGSIds.achievement_game_begins, 100.0f, (bool success) => {
			// handle success or failure
		});
	}

	public void ShameLessAchievement(){    // Done
		Social.ReportProgress(GPGSIds.achievement_shame_less, 100.0f, (bool success) => {
			// handle success or failure
		});
	}

	public void Run150Achievement(){     // Done
		Social.ReportProgress(GPGSIds.achievement_150k_run, 100.0f, (bool success) => {
			// handle success or failure
		});
	}

	public void Run250Achievement(){    // Done
		Social.ReportProgress(GPGSIds.achievement_250k_run, 100.0f, (bool success) => {
			// handle success or failure
		});
	}

	public void Run350Achievement(){    // Done
		Social.ReportProgress(GPGSIds.achievement_350k_run, 100.0f, (bool success) => {
			// handle success or failure
		});
	}

	public void HardCoreAchievement(){   //Done
		Social.ReportProgress(GPGSIds.achievement_hard_core, 100.0f, (bool success) => {
			// handle success or failure
		});
	}

	public void GameAddictAchievement(){   // Done
		PlayGamesPlatform.Instance.IncrementAchievement(
			GPGSIds.achievement_game_addict, 1, (bool success) => {
				// handle success or failure
			});
	}
		
	public void CrashMasterAchievement(){   // Done
		PlayGamesPlatform.Instance.IncrementAchievement(
			GPGSIds.achievement_crash_master, 1, (bool success) => {
				// handle success or failure
			});
	}


	// Achievements Helper Functions 

	public void ScoreAchievements(int score){
		if ((PlayerPrefs.GetInt ("Toughness") == 4) && (score > 100000)) {
			HardCoreAchievement ();
		}
		if (score > 150000) {
			Run150Achievement ();
			if (score > 250000) {
			    Run250Achievement ();
				if (score > 350000) {
					Run350Achievement ();
				}
			}
		}
	}

	public void GameOverAchievements (int score){
		if (score < 10000) {
			ShameLessAchievement ();
		}
		if (PlayerPrefs.GetInt ("timesLaunched") > 0) {
			GameBeginsAchievement ();
		}
		CrashMasterAchievement ();
	}
		
}

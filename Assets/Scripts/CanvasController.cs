using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour {

	public GameObject pauseBtn,viewBtn,scoreTextObject;     // UI elements visible during game play
	public GameObject[] UIElementsOutline;                  // UI elements not visible during game play

	Animator anim;
	Outline pauseTxtOutline,pauseBtnOutline,viewBtnOutline,scoreTxtOutline;

	void Start(){
		anim = GetComponent<Animator> ();
		pauseBtnOutline = pauseBtn.GetComponent<Outline> ();
		viewBtnOutline = viewBtn.GetComponent<Outline> ();
		scoreTxtOutline = scoreTextObject.GetComponent<Outline> ();
	}

	public void GameOver(Color col,bool highScore){
		OutlineColorMatchComplete (col);
		if (!highScore) {
			anim.SetTrigger ("Lose");
		} 
		else {
			anim.SetTrigger ("LoseHigh");
		}
	}

	public void Pause(Color col){
		OutlineColorMatchComplete (col);
		anim.SetTrigger ("Pause");
		Time.timeScale = 0;
	}

	public void Resume(){
		Time.timeScale = 1;
		anim.SetTrigger ("Resume");
	}
		
	public void OutlineColourMatch(Color col){
		pauseBtnOutline.effectColor = col;
		viewBtnOutline.effectColor = col;
		scoreTxtOutline.effectColor = col;
	}

	void OutlineColorMatchComplete(Color col){
		for (int i = 0; i < UIElementsOutline.Length; i++) {
			UIElementsOutline [i].GetComponent<Outline> ().effectColor = col;
		}
	}

}

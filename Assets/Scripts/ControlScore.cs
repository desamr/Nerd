using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlScore : MonoBehaviour {
	public Text ScoreText; 
	public Text ScoreLevel;
	public Text HiScoreText;

	void Start () {
		ScoreText.text = "0";
		ScoreLevel.text = "1";
	}

	public void ActualizaScore(){
		ScoreText.text = GameController.score.ToString();
		ScoreLevel.text = GameController.level.ToString ();
	}
	public void ActualizaHiScore(){
		HiScoreText.text = GameController.hiscore.ToString ();
	}
}

using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Score : MonoBehaviour {

	public Text display;
	public GameObject umpire;
	public AudioSource sound;
	public AudioClip scoreSound;
	public AudioClip foulSound;
	int score = 0;

	void SetScore(int newScore) {

		score = newScore;
	}

	void Update () {
	
		display.text = score.ToString ();
	}

	void ScorePoint() {

		sound.PlayOneShot (scoreSound);
		score++;
		umpire.SendMessage ("Continue");
	}

	void AddScore(List<int> scores) {
		
		scores.Add (score);
	}

	void Foul() {

		score--;
		sound.PlayOneShot (foulSound);
		umpire.SendMessage ("Continue");
	}
}

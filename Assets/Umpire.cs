using UnityEngine;
using System.Collections.Generic;

public class Umpire : MonoBehaviour {

	public GameObject[] players;
	int turn = 0;
	int shots = 2;
	bool tiebreak = false;

	void Start () {
	
		shots = 2;
		tiebreak = false;
		turn = Random.Range (0, players.Length);
		PlayerServe ();
	}

	void PlayerServe() {
		
		players [turn].SendMessage ("Service");
	}

	void Continue() {

		List<int> scores = new List<int> ();
		foreach (GameObject player in players) {

			player.SendMessage ("AddScore", scores);
		}

		scores.Sort ((a, b) => b.CompareTo(a));

		bool gameover = scores [0] >= 11 && scores [1] < scores [0] - 1;
		if (scores [0] >= 10 && scores [1] >= 10 && scores [1] >= scores [0] - 1) {

			tiebreak = true;
		}
		if (!gameover) {

			shots--;
			if (shots == 0 || tiebreak) {

				shots = 2;
				turn++;
				if (turn == players.Length) {

					turn = 0;
				}
			}
			Invoke ("PlayerServe", 1.0f);
		}
	}
}

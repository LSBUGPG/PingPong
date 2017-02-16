using UnityEngine;

public class ScoringZone : MonoBehaviour {

	public GameObject player;

	void OnTriggerEnter(Collider ball) {

		player.SendMessage ("ScorePoint");
		Destroy (ball.gameObject);
	}
}

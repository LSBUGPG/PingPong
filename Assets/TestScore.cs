using UnityEngine;

public class TestScore : MonoBehaviour {

	public int testScore = 0;

	void Start () {

		SendMessage ("SetScore", testScore);
	}
}

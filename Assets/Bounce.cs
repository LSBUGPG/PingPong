using UnityEngine;

public class Bounce : MonoBehaviour {

	public AudioSource sound;

	GameObject lastHit = null;

	void OnCollisionEnter(Collision collision) {

		if (collision.collider.CompareTag ("Player")) {

			if (lastHit == collision.gameObject) {

				collision.gameObject.SendMessage ("Foul");
				Destroy (gameObject);

			} else {
		
				lastHit = collision.gameObject;
				sound.Play ();
			}
		
		} else {

			sound.Play ();
		}
	}
}

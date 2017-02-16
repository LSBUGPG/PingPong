using UnityEngine;

public class Serve : MonoBehaviour {

	public Transform ball;
	public Transform target;
	public float force = 0.5f;

	void Service() {

		Transform newBall = Instantiate (ball);
		Vector3 ballPosition = transform.position;
		Vector3 targetPosition = target.position + Random.onUnitSphere * 50.0f;
		targetPosition.y = target.position.y;
		newBall.position = Vector3.MoveTowards (ballPosition, targetPosition, 5.0f);
		Rigidbody ballPhysics = newBall.GetComponent<Rigidbody> ();
		ballPhysics.AddForce ((targetPosition - ballPosition) * force, ForceMode.Impulse);
	}
}

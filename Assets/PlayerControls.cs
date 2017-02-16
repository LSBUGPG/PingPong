using UnityEngine;

public class PlayerControls : MonoBehaviour {

	public Rigidbody physics;
	public string axisName;
	float speed = 200.0f;
	float range = 50.0f;

	void Update () {

		float move = Input.GetAxis(axisName);
		Vector3 position = physics.position;
		position.z = Mathf.Clamp(position.z + move * speed * Time.deltaTime, -range, range);
		physics.MovePosition (position);
	}
}

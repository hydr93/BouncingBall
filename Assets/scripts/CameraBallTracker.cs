using UnityEngine;
using System.Collections;

public class CameraBallTracker : MonoBehaviour {

	private Transform ball;
	private float offset_y;

	void Start () {
		GameObject ball_object = GameObject.FindGameObjectWithTag ("Ball");

		if (ball_object == null) {
			Debug.LogError ("Couldn't find a game object with tag \"Ball\"");
			return;
		}
			
		ball = ball_object.transform;

		offset_y = transform.position.y - ball.position.y;
	}
	
	// Track Ball
	void Update () {
		if ( ball != null ){
			Vector3 possibleposition = transform.position;
			possibleposition.y = ball.position.y + offset_y;
			if (transform.position.y < possibleposition.y) {
			transform.position = possibleposition;
			}
		}
	}
}

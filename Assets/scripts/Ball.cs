using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	public PauseController pauseController;
	private float speed = 0;
	private float defaultSpeed = 3;
	private float timeLeft = 0f;
	private const float SPEEDPERDELTATIME = 0.001f;
	private const float MAXTIME = 10.0f;
	// Use this for initialization
	void Start () {
		speed = defaultSpeed;
		Vector3 v = Quaternion.AngleAxis(Random.Range(30.0f, 150.0f), Vector3.forward) * Vector3.right;
 		gameObject.GetComponent<Rigidbody2D>().velocity = v * speed;
	}

	// Calculations are done here
	void Update () {
		// default speed increases over time
		defaultSpeed += SPEEDPERDELTATIME;
		timeLeft = timeLeft - Time.deltaTime;
		if ( timeLeft < 0 ){
			timeLeft = 0;
		}
		// current speed can be adjusted with OnMouseDown
		speed = defaultSpeed*((timeLeft / MAXTIME)+1);
	}

	// Actions of calculations are done here
	void FixedUpdate () {
		gameObject.GetComponent<Rigidbody2D>().velocity = gameObject.GetComponent<Rigidbody2D>().velocity.normalized * speed; 
	}

	void OnMouseDown (){
		if ( Time.timeScale == 1 && Input.GetMouseButtonDown(0)){
			speed = (float)2 * defaultSpeed;
			timeLeft = MAXTIME;
		}
	}

	void OnTriggerEnter2D (Collider2D coll){
		if (coll.gameObject.tag == "Finish" ){
			Destroy(gameObject, 0.2f);
			pauseController.Pause(true);
		}
	}
}

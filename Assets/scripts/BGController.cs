using UnityEngine;
using System.Collections;

public class BGController : MonoBehaviour {

	private const float  SIZE = ((float)16.0) / 10;

	public int numberOfBGs;

	public Bricks Bricks1;
	public Bricks Bricks2;
	public Bricks Bricks3;
	public Bricks Bricks0; 
	private int level = 1;
	private const int numberOfLevelsToIncreaseOpenBrickSize = 5;

	void Start(){

		// TODO: Scaling for Screen size
		// float multiplier = SIZE/(((float)Screen.height)/Screen.width);
		// Bricks1.transform.localScale = new Vector3(Bricks1.transform.localScale.x * multiplier, Bricks1.transform.localScale.y * multiplier, Bricks1.transform.localScale.z);
		// Bricks2.transform.localScale = new Vector3(Bricks2.transform.localScale.x * multiplier, Bricks2.transform.localScale.y * multiplier, Bricks2.transform.localScale.z);
		// Bricks3.transform.localScale = new Vector3(Bricks3.transform.localScale.x * multiplier, Bricks3.transform.localScale.y * multiplier, Bricks3.transform.localScale.z);
		// Bricks4.transform.localScale = new Vector3(Bricks4.transform.localScale.x * multiplier, Bricks4.transform.localScale.y * multiplier, Bricks4.transform.localScale.z);

		//Assign the current states of Bricks
		Bricks1.RandomBricks(level,numberOfLevelsToIncreaseOpenBrickSize);
		level++;
		Bricks2.RandomBricks(level,numberOfLevelsToIncreaseOpenBrickSize);
		level++;
		Bricks3.RandomBricks(level,numberOfLevelsToIncreaseOpenBrickSize);
		level++;
	}

	void OnTriggerEnter2D( Collider2D collider){
		if ( collider.tag == "BG"){
			// Handle the background image
			float backgroundHeight = ((BoxCollider2D)collider).size.y * collider.transform.lossyScale.y * numberOfBGs;
			Vector3 pos = collider.transform.position;
			pos.y += backgroundHeight;
			collider.transform.position = pos;
		}else if ( collider.tag == "Bricks"){
			// Handle the bricks
			collider.gameObject.GetComponent<Bricks>().RandomBricks(level, numberOfLevelsToIncreaseOpenBrickSize);
			level++;
			Vector3 pos = collider.transform.position;
			pos.y += 48;
			collider.transform.position = pos;
		}
	}
}

using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	private bool hit;

	void OnMouseDown(){
		hit = true;
	}

	void FixedUpdate(){
		if ( hit){
			hit = false;
			if (IsOn())
				SetOff();
			else
				SetOn();
		}
		
	}

	public void SetOn(){
		gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
		gameObject.GetComponent<SpriteRenderer>().color = Color.black;
	}

	public void SetOff(){
		gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
		gameObject.GetComponent<SpriteRenderer>().color = Color.clear;
	}

	public bool IsOn(){
		return !gameObject.GetComponent<BoxCollider2D>().isTrigger;
	}

}

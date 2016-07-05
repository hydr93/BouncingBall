using UnityEngine;
using System.Collections.Generic;

public class Bricks : MonoBehaviour {
	
	private List<Brick> brickList = new List<Brick> ();

	public void Start(){
	}

	public void Awake(){
		foreach ( Transform child in transform){
			if ( child != null && child.gameObject != null && child.gameObject.tag == "Brick"){
				brickList.Add(child.gameObject.GetComponent<Brick>());
			}
		}
	}

	public void RandomBricks(int level, int numberOfLevelsToIncreaseOpenBrickSize){
		int openBricks = (level / numberOfLevelsToIncreaseOpenBrickSize) + 1;
		for ( int i = 0 ; i < brickList.Count; i++){
			if ( openBricks == 0){
					brickList[i].SetOff();
			}else{
				float probability = openBricks * (((float)1.0)/(6-i));
				float rand = Random.Range((float)0.0,(float)1.0);
				Debug.Log(gameObject+" Rand: "+rand+" Probability: "+probability);
				if ( rand < probability ){
					brickList[i].SetOn();
					openBricks--;
				}else{
					brickList[i].SetOff();
				}
			}
			
		}
	}

}

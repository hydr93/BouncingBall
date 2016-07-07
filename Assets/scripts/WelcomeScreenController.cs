using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class WelcomeScreenController : MonoBehaviour {
	public void StartGame(){
		SceneManager.LoadScene("game");
	}

	public void MusicOnOff(){
		MusicController.Instance.MusicOnOff(null,null,null);
	}

}

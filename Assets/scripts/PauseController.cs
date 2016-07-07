using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseController :MonoBehaviour {

	public Transform canvas;
	public Transform pauseScreen;
	public Transform gameOverScreen;
	public GameObject musicImage;
	public Sprite musicOnSprite;
	public Sprite musicOffSprite;
	
	void OnMouseDown(){
		Pause(false);
	}

	// Pauses the game.
	// If gameOver is true, then the gameOver screen is shown to the user
	public void Pause(bool gameOver){
		Time.timeScale = (Time.timeScale == 1) ? 0 : 1;
		pauseScreen.gameObject.SetActive(!canvas.gameObject.activeInHierarchy && !gameOver);
		gameOverScreen.gameObject.SetActive(!canvas.gameObject.activeInHierarchy && gameOver);
		canvas.gameObject.SetActive(!canvas.gameObject.activeInHierarchy);
		gameObject.SetActive(!gameObject.activeInHierarchy);
	}

	// Sets Music On or Off
	public void MusicOnOff(){
		MusicController.Instance.MusicOnOff(musicImage,musicOnSprite,musicOffSprite);
	}

	public void Quit(){
		Application.Quit();
	}

	public void Restart(){
		Pause(true);
		StartGame();
	}

	public void Resume(){
		Pause(false);
	}

	public void StartGame(){
		SceneManager.LoadScene("game");
	}

}

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

	private bool musicOn = true;
	
	void OnMouseDown(){
		Pause(false);
	}

	public void Pause(bool gameOver){
		Time.timeScale = (Time.timeScale == 1) ? 0 : 1;
		pauseScreen.gameObject.SetActive(!canvas.gameObject.activeInHierarchy && !gameOver);
		gameOverScreen.gameObject.SetActive(!canvas.gameObject.activeInHierarchy && gameOver);
		canvas.gameObject.SetActive(!canvas.gameObject.activeInHierarchy);
		gameObject.SetActive(!gameObject.activeInHierarchy);
	}

	public void Quit(){
		Application.Quit();
	}

	public void MusicOnOff(){
		if ( musicOn ){
			musicOn = false;
			musicImage.GetComponent<Image>().sprite = musicOffSprite;
			musicImage.GetComponent<Image>().color = Color.gray;
		}else{
			musicOn = true;
			musicImage.GetComponent<Image>().color = Color.black;
			musicImage.GetComponent<Image>().sprite = musicOnSprite;
		}
		
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

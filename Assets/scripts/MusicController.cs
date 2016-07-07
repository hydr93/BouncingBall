using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MusicController : MonoBehaviour {

	private static MusicController instance;
	public static MusicController Instance{
		get{ return instance;}
	}
	private bool musicOn = true;


	void Awake (){
		if (instance != null && instance != this){
        	Destroy(this.gameObject);
         	return;
    	}else{
        	instance = this;
     	}
    	DontDestroyOnLoad(this.gameObject);
	}

	public void MusicOnOff(GameObject musicImage, Sprite musicOnSprite, Sprite musicOffSprite){
		if ( musicOn ){
			SetMusicOff();
			if (musicImage.gameObject != null){
				musicImage.GetComponent<Image>().sprite = musicOffSprite;
				musicImage.GetComponent<Image>().color = Color.gray;
			}
		}else{
			SetMusicOn();
			if (musicImage.gameObject != null){
				musicImage.GetComponent<Image>().color = Color.black;
				musicImage.GetComponent<Image>().sprite = musicOnSprite;
			}
		}
	}

	private void SetMusicOn(){
		AudioListener.volume = 1;
		musicOn = true;
	}

	private void SetMusicOff(){
		AudioListener.volume = 0;
		musicOn = false;
	}

}

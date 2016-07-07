using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MusicButton : MonoBehaviour {
	public void MusicOnOff(){
		MusicController.Instance.MusicOnOff(null,null,null);
	}
}

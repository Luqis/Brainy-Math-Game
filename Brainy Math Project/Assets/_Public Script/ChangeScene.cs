using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ChangeScene : MonoBehaviour {
	

	public void changeScene(string sceneName)
	{
		SceneManager.LoadScene (sceneName);
	}

	public void stopMusic () {
		Destroy(GameObject.Find("MUSIC"));	
	}

	public void Logout(string sceneName){
		Destroy (GameObject.Find ("prefManager"));
		SceneManager.LoadScene (sceneName);
	}

}

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

}

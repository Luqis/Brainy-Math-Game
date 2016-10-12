using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ChangeScene : MonoBehaviour {
	

	public void changeScene(string sceneName)
	{
		SceneManager.LoadScene (sceneName);

	}

	void Update () {
		
	}

}

using UnityEngine;
using System.Collections;

public class star : MonoBehaviour {



	string starUrl = "lrgs.ftsm.ukm.my/users/a150737/game/startE1.php";

	IEnumerator Start(){
		WWW starwww = new WWW (starUrl);
		yield return questionData;
		string questionDataString = questionData.text;
		//Debug.Log (questionDataString);
		questions = questionDataString.Split (';');
		//Debug.Log (questions.Length);
}

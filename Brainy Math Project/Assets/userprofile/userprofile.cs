using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class userprofile : MonoBehaviour {



	public string profileUrl = "";

	public Text username;
	public Text E1;
	public Text E2;
	public Text M1;
	public Text M2;
	public Text H1;
	public Text H2;
	public string score;

	IEnumerator Start(){

		GameObject thePlayer2 = GameObject.Find("prefManager");
		prefmanager playerScript2 = thePlayer2.GetComponent<prefmanager>();
		username.text = playerScript2.userID;


		WWWForm userform = new WWWForm();

		userform.AddField("usernamePost", username.text);

		WWW userData = new WWW (profileUrl,userform);
		yield return userData;
		score =userData.text;
		Debug.Log (score);
		Show ();
	}



	public void Show(){

		E1.text = GetDataValue (score, "ScoreE1:");			
		E2.text = GetDataValue (score, "ScoreE2:");
		M1.text = GetDataValue (score, "ScoreM1:");
		M2.text = GetDataValue (score, "ScoreM2:");
		H1.text = GetDataValue (score, "ScoreH1:");
		H2.text = GetDataValue (score, "ScoreH2:");

	}

	string GetDataValue (string data, string index){
		string value = data.Substring (data.IndexOf(index)+index.Length);
		if (value.Contains ("|")) {
			value = value.Remove(value.IndexOf("|"));
		}

		return value;
	}









}

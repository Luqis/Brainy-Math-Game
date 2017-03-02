using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class rank : MonoBehaviour {



	public string profileUrl = "";

	public Text username1;
	public Text Score1;
	public Text username2;
	public Text Score2;
	public Text username3;
	public Text Score3;
	public Text username4;
	public Text Score4;
	public Text username5;
	public Text Score5;
	public GameObject window;
	public string score;

	IEnumerator Start(){





		WWW userData = new WWW (profileUrl);
		yield return userData;
		score =userData.text;
		Debug.Log (score);
		Show ();
	}



	public void Show(){

		username1.text = GetDataValue (score, "name1:");			
		Score1.text = GetDataValue (score, "Score1:");
		username2.text = GetDataValue (score, "name2:");
		Score2.text = GetDataValue (score, "Score2:");
		username3.text = GetDataValue (score, "name3:");
		Score3.text = GetDataValue (score, "Score3:");
		username4.text = GetDataValue (score, "name4:");
		Score4.text = GetDataValue (score, "Score4:");
		username5.text = GetDataValue (score, "name5:");
		Score5.text = GetDataValue (score, "Score5:");


	}

	string GetDataValue (string data, string index){
		string value = data.Substring (data.IndexOf(index)+index.Length);
		if (value.Contains ("|")) {
			value = value.Remove(value.IndexOf("|"));
		}

		return value;
	}

	public void Hide(){
		window.SetActive (false);
	}
	public void Showmsg(){
		
			window.SetActive (true);
		}
	}










using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class Question : MonoBehaviour {

	[SerializeField]
	private Stat health;

	[SerializeField]
	private Stat2 player_health;

	List<int> randomNumbers = new List<int>();
	public string questionUrl = "http://localhost/game/upload.php";
	public string[] questions;
	public string titleID;
	public Text title;
	public Text Choice1;
	public Text Choice2;
	public Text Choice3;
	public Text Choice4;
	public string Answer;
	public int i = 0;
	public Button btn1;
	public float score=0;
	public Text total_score;
	public Text username;



	IEnumerator Start(){
		WWW questionData = new WWW (questionUrl);
		yield return questionData;
		string questionDataString = questionData.text;
		//Debug.Log (questionDataString);
		questions = questionDataString.Split (';');
		//Debug.Log (questions.Length);

		for (int x = 0; x < (questions.Length-1); x++){
			randomNumbers.Add (x);
	}
		GameObject thePlayer2 = GameObject.Find("prefManager");
		prefmanager playerScript2 = thePlayer2.GetComponent<prefmanager>();
		username.text = playerScript2.userID;



	}

	public void Hide(){
		health.Initialize ();
		player_health.Initialize ();
		getRandomQuestion ();
		btn1.gameObject.SetActive(false);	
	}




	void getRandomQuestion(){

		if (randomNumbers.Count <= 0) {
			Debug.Log ("No more Question");
			Debug.Log ("Correct Answer: " + score);
			Debug.Log ("total ques: " + (questions.Length-1));
			Debug.Log("Total_score: " + (score/(questions.Length-1))*100);
		} else {

		
			int randomIndex = Random.Range (0, (randomNumbers.Count));
			int value = randomNumbers [randomIndex];
			randomNumbers.RemoveAt (randomIndex);

			Show (value);


		}



	}



	public void Show(int num){
		
		title.text = GetDataValue (questions [num], "title:");			
		Choice1.text = GetDataValue (questions [num], "C1:");
		Choice2.text = GetDataValue (questions [num], "C2:");
		Choice3.text = GetDataValue (questions [num], "C3:");
		Choice4.text = GetDataValue (questions [num], "C4:");
		Answer = GetDataValue (questions [num], "ans:");
		titleID =GetDataValue (questions [num], "TitleID:");
	}



	string GetDataValue (string data, string index){
		string value = data.Substring (data.IndexOf(index)+index.Length);
		if (value.Contains ("|")) {
			value = value.Remove(value.IndexOf("|"));
		}

		return value;
	}

	public void checkAns(string ans){
		if (ans == Answer) {
			Debug.Log ("CORRECT");
			health.CurrentVal -= 10;
			score++;
			getRandomQuestion ();

		} else {
			Debug.Log ("Wrong");
			player_health.CurrentVal -= 20;
			if (player_health.CurrentVal <= 0) {
				Debug.Log ("GAME OVER");
			}
			getRandomQuestion ();


		
		}
	}







}

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
	public string questionUrl = "";
	public string Url = "";
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
	public GameObject Gameover;
	public GameObject Gameover_lose;
	public Text messagescore;
	public string tablescore;
	public Text time;

	float timeLeft = 60.0f;
	bool startTime = false;

	IEnumerator Start(){
		WWWForm table_form = new WWWForm();
		table_form.AddField("questPost", tablescore);
		WWW questionData = new WWW (questionUrl,table_form);
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

		InvokeRepeating ("minusTime", 1.0f, 1.0f);

	}

	void Update(){
		time.text = "Timer: " + timeLeft;
	}

	void minusTime (){
		if(startTime == true)
		timeLeft--;
	}

	public void Hide(){
		health.Initialize ();
		player_health.Initialize ();
		getRandomQuestion ();
		btn1.gameObject.SetActive(false);
		startTime = true;
	}

	public void gobackmenu(){
		SceneManager.LoadScene ("SubLevelE", LoadSceneMode.Single);
	}



	void getRandomQuestion(){

		if (randomNumbers.Count <= 0) {
			//Debug.Log ("No more Question");
			//Debug.Log ("Correct Answer: " + score);
			//Debug.Log ("total ques: " + (questions.Length-1));
			//Debug.Log("Total_score: " + (score/(questions.Length-1))*100);

			StartCoroutine ("updatescore");


		} else {

		
			int randomIndex = Random.Range (0, (randomNumbers.Count));
			int value = randomNumbers [randomIndex];
			randomNumbers.RemoveAt (randomIndex);

			Show (value);


		}
	}
		IEnumerator updatescore()
		{
			WWWForm form2 = new WWWForm();
			double total_score = (score/(questions.Length-1))*100;
			string totalscore = total_score.ToString ();
			form2.AddField("username", username.text);
			form2.AddField("score", totalscore);
			Debug.Log(username.text);
			Debug.Log(totalscore);

			WWW download2 = new WWW(Url, form2);
		yield return download2;
		Debug.Log (download2.text);

			Gameover.SetActive (true);
			messagescore.text = totalscore;

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
			timeLeft += 2;
			getRandomQuestion ();

		} else {
			Debug.Log ("Wrong");
			player_health.CurrentVal -= 20;
			timeLeft -= 5;
			if (player_health.CurrentVal <= 0) {
				Debug.Log ("GAME OVER");
				Gameover_lose.SetActive (true);

			}
			getRandomQuestion ();


		
		}
	}







}

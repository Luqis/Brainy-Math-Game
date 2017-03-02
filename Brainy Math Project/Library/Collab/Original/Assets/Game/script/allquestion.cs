using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class allquestion : MonoBehaviour {

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
	public Text messagescore;
	public GameObject Gameover_lose;
	public string tablescore;
	public GameObject HeroPrefab;
	public Animator HeroAnim;

	private void Start(){
		StartCoroutine ("Mula");
		HeroPrefab = Resources.Load<GameObject>("HeroF");
		GameObject thePlayer4 = GameObject.Find("prefManager");
		prefmanager playerScript4 = thePlayer4.GetComponent<prefmanager>();
		username.text = playerScript4.userID;
	}

	IEnumerator Mula(){

		WWWForm table_form = new WWWForm();

		table_form.AddField("questPost", tablescore);

		WWW questionData = new WWW (questionUrl,table_form);
		yield return questionData;
		string questionDataString = questionData.text;

		questions = questionDataString.Split (';');

		for (int x = 0; x < (questions.Length-1); x++){
			randomNumbers.Add (x);
		}

	}

	public void Hide(){
		GameObject Hero = Instantiate (HeroPrefab, GameObject.Find ("Canvas").transform, false) as GameObject;
		Hero.name = "Hero";
		HeroAnim = GameObject.Find ("Hero").GetComponent<Animator>();
		health.Initialize ();
		player_health.Initialize ();
		getRandomQuestion ();
		btn1.gameObject.SetActive(false);
	}

	public void gobackmenu(){
		SceneManager.LoadScene ("SubLevelE", LoadSceneMode.Single);
	}

	void getRandomQuestion(){
		if (randomNumbers.Count <= 0) {

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
			
			Destroy (GameObject.Find("Hero"));
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

			HeroAnim.SetTrigger("attack");

			getRandomQuestion ();

		} else {
			Debug.Log ("Wrong");
			player_health.CurrentVal -= 20;

			HeroAnim.SetTrigger("hurt");

			if (player_health.CurrentVal <= 0) {
				Debug.Log ("GAME OVER");
				StartCoroutine ("updatescore");
				Gameover_lose.SetActive (true);
			}

			getRandomQuestion ();
		}
	}







}

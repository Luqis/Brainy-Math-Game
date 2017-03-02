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

	public AudioClip Hatt;
	public AudioClip Zatt;
	public AudioClip win;
	public AudioClip lose;
	AudioSource sound;

	List<int> randomNumbers = new List<int>();
	public string questionUrl = "";
	public string genderUrl = "http://lrgs.ftsm.ukm.my/users/a150737/game/checkgender.php";
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
	public GameObject ZombiPrefab;
	public Animator ZombiAnim;
	int jantina;

	private void Start(){
		sound = GetComponent<AudioSource>();
		StartCoroutine ("Mula");

		GameObject thePlayer4 = GameObject.Find("prefManager");
		prefmanager playerScript4 = thePlayer4.GetComponent<prefmanager>();
		username.text = playerScript4.userID;

		StartCoroutine ("gender");

	}
	void ZombiAttack() {
		sound.PlayOneShot(Zatt, 0.7F);
	}

	void HeroAttack() {
		sound.PlayOneShot(Hatt, 0.7F);
	}

	void winsound() {
		sound.PlayOneShot(win, 0.7F);
	}

	void losesound() {
		sound.PlayOneShot(lose, 0.7F);
	}

	IEnumerator gender(){
		WWWForm gender_form = new WWWForm();
		gender_form.AddField("usernamePost", username.text);
		WWW genderData = new WWW (genderUrl,gender_form);
		yield return genderData;
		jantina =  int.Parse(genderData.text);
		Debug.Log (jantina);
		if (jantina == 0) {			
			HeroPrefab = Resources.Load<GameObject> ("HeroF");
			ZombiPrefab = Resources.Load<GameObject> ("ZombieF");
		} else if (jantina == 1) {
			HeroPrefab = Resources.Load<GameObject> ("HeroM");
			ZombiPrefab = Resources.Load<GameObject> ("ZombieM");
		}

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
		ShowCharacter ();
		health.Initialize ();
		player_health.Initialize ();
		getRandomQuestion ();
		btn1.gameObject.SetActive(false);
	}

	private void ShowCharacter (){
		GameObject Hero = Instantiate (HeroPrefab, GameObject.Find ("Canvas").transform, false) as GameObject;
		Hero.name = "Hero";
		HeroAnim = GameObject.Find ("Hero").GetComponent<Animator>();

		GameObject Zombi = Instantiate (ZombiPrefab, GameObject.Find ("Canvas").transform, false) as GameObject;
		Zombi.name = "Zombi";
		ZombiAnim = GameObject.Find ("Zombi").GetComponent<Animator>();
	}

	public void gobackmenu(){
		SceneManager.LoadScene ("SubLevelE", LoadSceneMode.Single);
	}

	void getRandomQuestion(){
		if (randomNumbers.Count <= 0) {
			winsound ();
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
			
			yield return new WaitForSeconds (1);
			Destroy (GameObject.Find ("Zombi").GetComponent<Animator>());
			Destroy (GameObject.Find ("Hero").GetComponent<Animator>());
			Destroy (GameObject.Find("Hero"));
			Destroy (GameObject.Find("Zombi"));
			
			
			yield return new WaitForSeconds (0.7f);
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

	IEnumerator Zhurt (){
		yield return new WaitForSeconds (0.5f);
		ZombiAnim.SetTrigger("hurt");
	}

	IEnumerator Hhurt (){
		yield return new WaitForSeconds (0.7f);
		HeroAnim.SetTrigger("hurt");
	}

	public void checkAns(string ans){
		if (ans == Answer) {
			Debug.Log ("CORRECT");
			health.CurrentVal -= 10;
			score++;

			HeroAttack ();
			HeroAnim.SetTrigger("attack");
			StartCoroutine ("Zhurt");

			getRandomQuestion ();

		} else {
			Debug.Log ("Wrong");
			player_health.CurrentVal -= 20;

			ZombiAttack ();
			ZombiAnim.SetTrigger("attack");
			StartCoroutine ("Hhurt");

			if (player_health.CurrentVal <= 0) {
				Debug.Log ("GAME OVER");
				StartCoroutine ("updatescore");
				Gameover_lose.SetActive (true);
				losesound ();
			}

			getRandomQuestion ();
		}
	}







}

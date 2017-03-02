using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class star : MonoBehaviour {

	public GameObject star1;
	public GameObject star2;
	public GameObject star3;
	public Text score1;

	public GameObject star4;
	public GameObject star5;
	public GameObject star6;
	public Text score2;

	public string scoredb1;
	public string scoredb2;
	public Text username;
	string starUrl = "lrgs.ftsm.ukm.my/users/a150737/game/startE1.php";

	IEnumerator Start(){

		GameObject thePlayer2 = GameObject.Find("prefManager");
		prefmanager playerScript2 = thePlayer2.GetComponent<prefmanager>();
		username.text = playerScript2.userID;

		//1st button
		WWWForm form = new WWWForm ();
		form.AddField ("usernamePost", username.text);
		form.AddField ("scorePost", scoredb1);
		WWW	www = new WWW (starUrl, form);

		yield return www;
		Debug.Log (www.text);

		int userscore = int.Parse(www.text);

		if ( userscore == 100) {
			star1.SetActive (true);
			star2.SetActive (true);
			star3.SetActive (true);
		}else if( userscore >=70 &&  userscore < 100){
			star1.SetActive (true);
			star2.SetActive (true);
		}else if (userscore >=40 &&  userscore < 70){
			star1.SetActive (true);
		}

		score1.text = www.text;

	//2nd button
	WWWForm form2= new WWWForm ();
	form2.AddField ("usernamePost", username.text);
		form2.AddField ("scorePost",scoredb2);
	WWW	www2 = new WWW (starUrl, form2);

	yield return www2;
	Debug.Log (www2.text);

	int userscore2 = int.Parse(www2.text);

	if ( userscore2 == 100) {
		star4.SetActive (true);
		star6.SetActive (true);
		star5.SetActive (true);
	}else if( userscore2 >=70 &&  userscore2 < 100){
		star4.SetActive (true);
		star5.SetActive (true);
	}else if (userscore2 >=40 &&  userscore2 < 70){
		star4.SetActive (true);
	}

	score2.text = www2.text;
}
}
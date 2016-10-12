using UnityEngine;
using System.Collections;

public class Login : MonoBehaviour {

	public static string username = "";
	public static string password = "";

	string userUrl = "http://localhost/game/login.php";

	public void getUsername (string getname){
		username = getname;
	}

	public void getPassword (string getpass){
		password= getpass;
}

	public void Mula (){

		StartCoroutine ("login");
	}
		

		IEnumerator login(){

			WWWForm form = new WWWForm ();
			form.AddField ("usernamePost", username);
			form.AddField ("passwordPost", password);
			WWW	www = new WWW (userUrl, form);

			yield return www;
			Debug.Log (www.text);

}
	}	
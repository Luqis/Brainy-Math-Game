using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Login : MonoBehaviour {

	public static string username = "";
	public static string password = "";

	string userUrl = "http://localhost/game/login.php";

	public GameObject window;
	public Text messageField;
	private bool msg = false;

	public void Show(string message){
		if (msg == true) {
			messageField.text = message;
			window.SetActive (true);
		}
	}

	public void Hide(){
		window.SetActive (false);
	}


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
			
			string x = www.text;

		if (x == "X") {
			msg = true;

			Show ("Wrong username and password!");


		}
		else if(x =="OK"){
			msg = true;

			Show ("(GO MAIN MENU)");
		}

		else if(x =="No this username"){
			msg = true;

			Show ("No This Username, please register!");
		}

}
	}	
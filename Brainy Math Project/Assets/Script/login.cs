using UnityEngine;
using System.Collections;

public class loginscript : MonoBehaviour {

	public static string username = "";
	public static string password = "";

	string userUrl = "http://localhost/math/user.php";

	public void getUsername (string getname){
		username = getname;
	}

	public void getPassword (string getpass){
		password= getpass;
}

	public void Login (){



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
using UnityEngine;
using System.Collections;

public class Login1 : MonoBehaviour {

	public string inputUsername;
	private bool done = false;
	public static string username = "";
	public static string password = "";

	private string cusername ="";
	private string cpassword = "";
	public string Confirmpassword="";



	string userUrl = "http://localhost/math/insert.php";

	public void changeScene(string sceneName)
	{
		if (done == true) {
			Application.LoadLevel (sceneName);
		}


	}

	public void getUsername (string getname){
		username = getname;
	}

	public void getPassword (string getpass){
		password= getpass;
	}

	public void getcPassword (string getpass){
		cpassword= getpass;
	}

	public void Create (){
		
		if (password == cpassword) {
			
			StartCoroutine ("x");
		}



		}

	IEnumerator x ()
	{
		
		WWWForm form = new WWWForm ();
		form.AddField ("usernamePost", username);
		form.AddField ("passwordPost", password);
		WWW	www = new WWW (userUrl, form);

		 yield return www;
		Debug.Log (www.text);

		if (www.text == "OK") {
			done = true;
			Debug.Log ("Back Login");
			changeScene("Login");
		}


	}









}

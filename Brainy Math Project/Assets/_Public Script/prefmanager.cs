using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class prefmanager : MonoBehaviour {

	public string userID;

	void Awake() {
		DontDestroyOnLoad(transform.gameObject);
	}

}
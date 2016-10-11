using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ClickSound1 : MonoBehaviour {
	public AudioClip sound1;
	private Button button { get { return GetComponent<Button> (); } }
	private AudioSource source{get { return GetComponent<AudioSource> ();}}
	// Use this for initialization
	void Start () {

		gameObject.AddComponent<AudioSource>();
		source.clip=sound1;
		source.playOnAwake = false;

		button.onClick.AddListener (() => PlaySound ());
	}
	
	// Update is called once per frame
	void PlaySound () {
		source.PlayOneShot (sound1);
	}
}

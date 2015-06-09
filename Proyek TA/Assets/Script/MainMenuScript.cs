using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour {

	GameObject userManager;

	void Start () {
		userManager = GameObject.Find("UserManager");
		this.GetComponent<Text>().text = "Welcome : " + userManager.GetComponent<UserDataScript>().nama_user; 
	}

	public void b_play() {
		Application.LoadLevel ("test");
	}

	public void b_deckEdit() {
		Application.LoadLevel ("DeckEditor");
	}

	public void b_exit() {
		Application.Quit();
	}
}

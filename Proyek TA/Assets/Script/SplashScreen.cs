using UnityEngine;
using System.Collections;

public class SplashScreen : MonoBehaviour {

	void Start () {
		StartCoroutine(firstScr());
	}

	IEnumerator firstScr () {
		yield return new WaitForSeconds(2f);
		Application.LoadLevel("Login");
	}
}

using UnityEngine;
using System.Collections;

public class ExitScript : MonoBehaviour {

	public void exit () {
		Application.Quit();
	}

	public void create() {
		Application.LoadLevel("CreateID1");
	}

}

using UnityEngine;
using System.Collections;

public class UserDataScript : MonoBehaviour {

	public string idUser;
	public string password;
	public string nama_user;
	public int exp;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(this.gameObject);
	}

}

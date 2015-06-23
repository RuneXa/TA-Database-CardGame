using UnityEngine;
using System.Collections;

public class UserDataScript : MonoBehaviour {

	public string idUser;
	public string password;
	public string nama_user;
	public int exp;
	public string phpPath;
	public int gameNum;

	void Start () {
		phpPath = "http://localhost/card.php";
		DontDestroyOnLoad(this.gameObject);
	}

}


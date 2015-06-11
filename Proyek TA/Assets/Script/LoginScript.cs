using UnityEngine;
using System.Collections;
using SimpleJSON;
using UnityEngine.UI;

public class  LoginScript : MonoBehaviour {

	UserDataScript userData; 

	void Start(){
		userData = GameObject.Find ("UserManager").GetComponent<UserDataScript>() as UserDataScript;
	}

	public void login()
	{
		userData.idUser = GameObject.Find("UserName").GetComponent<InputField>().text;
		userData.password = GameObject.Find("Password").GetComponent<InputField>().text;

		Debug.Log ("Id : " + userData.idUser + "\n Password : " + userData.password);
		char[] escape = new char[3] {'\'','"','#'};
		userData.idUser = userData.idUser.Split(escape)[0];

		StartCoroutine(fetchUrlLogin());
	}


	IEnumerator fetchUrlLogin()
	{
		string jsonString="";
		WWWForm postData= new WWWForm();
		postData.AddField ("username", "root");
		postData.AddField ("password", "");
		postData.AddField ("query", "select * from tb_user where id_user = '" + userData.idUser + "' and password = '" + userData.password + "'");
		
		WWW www = new WWW (userData.phpPath,postData); //ganti path ke php-nya kalo perlu
		yield return www.isDone;
		for (int i=0; i<www.bytesDownloaded; i++) {
			jsonString+=(char)www.bytes [i]; //append char ke jsonString
		}
		JSONNode jsonNode = JSON.Parse (jsonString); //parsing JSON
		
		if (jsonNode[0]["id_user"] != null)
		{
			userData.nama_user = jsonNode[0]["nama"];
			userData.exp = jsonNode[0]["exp"].AsInt;
			Application.LoadLevel("MainMenu");
		}
		else
		{
			GameObject.Find("TextLoginGagal").gameObject.SetActive(true);
		}
	}
}

using UnityEngine;
using System.Collections;
using SimpleJSON;
using UnityEngine.UI;

public class  LoginScript : MonoBehaviour {

	public string idUser;
	public string password;

	public void login()
	{

		idUser = this.transform.parent.Find("UserName").FindChild("Text").GetComponent<Text>().text;
		password = this.transform.parent.Find("Password").FindChild("Text").GetComponent<Text>().text;

		Debug.Log ("Id : " + idUser + "\n Password : " + password);

		StartCoroutine(fetchUrlLogin());

	}

	IEnumerator fetchUrlLogin()
	{
		string jsonString="";
		WWWForm postData= new WWWForm();
		postData.AddField ("username", "root");
		postData.AddField ("password", "");
		postData.AddField ("query", "select * from tb_user where id_user = '" + idUser + "' and passworrd = '" + password + "'");
		
		string phpPath = "http://localhost/Xrune/TA_database/card.php";
		WWW www = new WWW (phpPath,postData); //ganti path ke php-nya kalo perlu
		yield return www.isDone;
		for (int i=0; i<www.bytesDownloaded; i++) {
			jsonString+=(char)www.bytes [i]; //append char ke jsonString
		}
		JSONNode jsonNode = JSON.Parse (jsonString); //parsing JSON
		
		if (jsonNode[0]["id_user"] != null)
		{
			Application.LoadLevel("test");
		}
		else
		{
			this.transform.parent.FindChild("TextLoginGagal").gameObject.SetActive(true);
		}
	}
}

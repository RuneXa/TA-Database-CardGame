using UnityEngine;
using System.Collections;
using SimpleJSON;

public class NewBehaviourScript : MonoBehaviour {

	//buat nyari tau udah kebaca semua apa belum



	UserDataScript userManager;
	//JSONNode jsonNode;

	// Use this for initialization
	void Start () {
		userManager = GameObject.Find("UserManager").GetComponent<UserDataScript>() as UserDataScript;
		StartCoroutine(fetchUrl());
	}

	IEnumerator fetchUrl()
	{
		string jsonString="";
		WWWForm postData= new WWWForm();
		postData.AddField ("username", "root");
		postData.AddField ("password", "");
		postData.AddField ("query", "select * from tb_kartu");
		
		
		WWW www = new WWW (userManager.phpPath,postData); //ganti path ke php-nya kalo perlu
		yield return www.isDone;

		for (int i=0; i<www.bytesDownloaded; i++) {
			jsonString+=(char)www.bytes [i]; //append char ke jsonString
		}
		JSONNode jsonNode = JSON.Parse (jsonString); //parsing JSON

		foreach (JSONNode N in jsonNode.Children)
		{
			Debug.Log (N);
		}
		
	}
}

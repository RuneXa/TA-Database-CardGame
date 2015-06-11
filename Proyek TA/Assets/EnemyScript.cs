using UnityEngine;
using System.Collections;
using SimpleJSON;

public class EnemyScript : MonoBehaviour {

	UserDataScript userManager;
	JSONNode jsonNode;
	// Use this for initialization
	void Start () {
		StartCoroutine (fetchUrl());
		userManager = GameObject.Find ("UserManager").GetComponent<UserDataScript> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator fetchUrl()
	{
		string jsonString="";
		WWWForm postData= new WWWForm();
		postData.AddField ("username", "root");
		postData.AddField ("password", "");
		//postData.AddField ("query", "select * from tb_kartu");
		postData.AddField ("query", "select * from tb_datamusuh order by rand() limit 1");
		
		WWW www = new WWW (userManager.phpPath,postData); //ganti path ke php-nya kalo perlu
		yield return www.isDone;
		for (int i=0; i<www.bytesDownloaded; i++) {
			jsonString+=(char)www.bytes [i]; //append char ke jsonString
		}
		jsonNode = JSON.Parse (jsonString); //parsing JSON
		
		foreach (JSONNode N in jsonNode.Children)
		{
			//Debug.Log(N["
			Debug.Log("Nama: " + N["nama"] + "\n");
		}
		
	}
}

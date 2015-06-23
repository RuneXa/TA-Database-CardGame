using UnityEngine;
using System.Collections;
using SimpleJSON;
public class ReportScript : MonoBehaviour {

	///Script untuk me-return sebuah node yang berisi laporan menang/kalah setiap user dalam database serta rata-ratanya dsb. /// 

	UserDataScript userData; 
	
	void Start(){
		userData = GameObject.Find ("UserManager").GetComponent<UserDataScript>() as UserDataScript;
		StartCoroutine(fetchUrl());
	}
	
	// Update is called once per frame
	IEnumerator fetchUrl(){
			string jsonString="";
			WWWForm postData= new WWWForm();
			postData.AddField ("username", "root");
			postData.AddField ("password", "");
			postData.AddField ("query", "select id_user, win/(win+loss)*100 winrate from tb_winrate");
			
			WWW www = new WWW (userData.phpPath,postData); //ganti path ke php-nya kalo perlu
			yield return www.isDone;
			for (int i=0; i<www.bytesDownloaded; i++) {
				jsonString+=(char)www.bytes [i]; //append char ke jsonString
			}
			JSONNode jsonNode = JSON.Parse (jsonString); //parsing JSON

	}
}

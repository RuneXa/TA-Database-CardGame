using UnityEngine;
using System.Collections;
using SimpleJSON;
using UnityEngine.UI;

public class ReportScript : MonoBehaviour {

	///Script untuk me-return sebuah node yang berisi laporan menang/kalah setiap user dalam database serta rata-ratanya dsb. /// 

	UserDataScript userData; 
	Text textReport;
	
	void Start(){
		userData = GameObject.Find ("UserManager").GetComponent<UserDataScript>() as UserDataScript;
		textReport = GameObject.Find ("Text").GetComponent<Text>();
		StartCoroutine(fetchUrl());
	}

	IEnumerator fetchUrl(){
			string jsonString="";
			WWWForm postData= new WWWForm();

			postData.AddField ("query", "select id_user, win/(win+loss)*100 as winrate from tb_winrate");
			
			WWW www = new WWW (userData.phpPath,postData); //ganti path ke php-nya kalo perlu
			yield return www.isDone;
			for (int i=0; i<www.bytesDownloaded; i++) {
				jsonString+=(char)www.bytes [i]; //append char ke jsonString
			}
			JSONNode jsonNode = JSON.Parse (jsonString); //parsing JSON
			foreach(JSONNode N in jsonNode.Children)
			{
				textReport.text = textReport.text + "\n" + N["id_user"] + " : " + N["winrate"] +"%";
			}
		Debug.Log (textReport.text);
			
	}

	public void Back(){
		Application.LoadLevel("Login");
	}
}

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

	}

	public void winrate(){
		StopAllCoroutines();
		StartCoroutine(fetchUrlWinRate());
	}

	public void top5card(){
		StopAllCoroutines();
		StartCoroutine(fetchUrlMostUsedCard());
	}

	public void top5player(){
		StopAllCoroutines();
		StartCoroutine(fetchUrlTopPlayer());
	}

	IEnumerator fetchUrlWinRate(){
			textReport.text = "Processing...";

			string jsonString="";
			WWWForm postData= new WWWForm();

			postData.AddField ("query", "select id_user, win/(win+loss)*100 as winrate from tb_winrate");
			
			WWW www = new WWW (userData.phpPath,postData); //ganti path ke php-nya kalo perlu
			yield return www.isDone;
			for (int i=0; i<www.bytesDownloaded; i++) {
				jsonString+=(char)www.bytes [i]; //append char ke jsonString
			}
			JSONNode jsonNode = JSON.Parse (jsonString); //parsing JSON
			textReport.text = "Winrate :\n";
			foreach(JSONNode N in jsonNode.Children)
			{
				textReport.text = textReport.text + "\n" + N["id_user"] + " : " + N["winrate"] +"%";
			}
		Debug.Log (textReport.text);
			
	}

	IEnumerator fetchUrlMostUsedCard(){
		textReport.text = "Processing...";
		
		string jsonString="";
		WWWForm postData= new WWWForm();
		
		postData.AddField ("query", "SELECT tb_deck.kode_kartu, tb_kartu.nama ,Count(tb_deck.kode_kartu) as jumlah FROM `tb_deck` natural join `tb_kartu` group by tb_deck.kode_kartu ORDER by jumlah DESC LIMIT 5");
		
		WWW www = new WWW (userData.phpPath,postData); //ganti path ke php-nya kalo perlu
		yield return www.isDone;
		for (int i=0; i<www.bytesDownloaded; i++) {
			jsonString+=(char)www.bytes [i]; //append char ke jsonString
		}
		JSONNode jsonNode = JSON.Parse (jsonString); //parsing JSON
		textReport.text = "5 Kartu paling sering dimasukkan di deck user :\n";
		foreach(JSONNode N in jsonNode.Children)
		{
			textReport.text = textReport.text + "\n" + N["nama"] + " (" + N["kode_kartu"] + ") : " + N["jumlah"] + "Buah";
		}
		Debug.Log (textReport.text);
		
	}

	IEnumerator fetchUrlTopPlayer(){
		textReport.text = "Processing...";
		
		string jsonString="";
		WWWForm postData= new WWWForm();
		
		postData.AddField ("query", "SELECT id_user, nama, exp FROM `tb_user` ORDER by exp DESC LIMIT 5");
		
		WWW www = new WWW (userData.phpPath,postData); //ganti path ke php-nya kalo perlu
		yield return www.isDone;
		for (int i=0; i<www.bytesDownloaded; i++) {
			jsonString+=(char)www.bytes [i]; //append char ke jsonString
		}
		JSONNode jsonNode = JSON.Parse (jsonString); //parsing JSON
		textReport.text = "5 Pemain dengan exp terbanyak :\n";
		foreach(JSONNode N in jsonNode.Children)
		{
			textReport.text = textReport.text + "\n" + N["nama"] + " (" + N["id_user"] + ") : " + N["exp"] + "exp";
		}
		Debug.Log (textReport.text);
		
	}

	public void Back(){
		Application.LoadLevel("Login");
	}
}

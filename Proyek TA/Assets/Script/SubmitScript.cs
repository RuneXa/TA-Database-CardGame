using UnityEngine;
using System.Collections;
using SimpleJSON;

public class SubmitScript : MonoBehaviour {

	UserDataScript userManager;

	public void submitDeck() {
		userManager = GameObject.Find("UserManager").GetComponent<UserDataScript>() as UserDataScript;
		StartCoroutine("fetchUrlSubmitKartu");
	}
	

	IEnumerator fetchUrlSubmitKartu()
	{
		string query="";
		WWWForm postData= new WWWForm();
		postData.AddField ("username", "root");
		postData.AddField ("password", "");
		postData.AddField("multi","1");

		//truncate dulu baru dimasukkin lagi
		query = "delete from tb_deck where id_user = '" + userManager.idUser + "';";
		//-----

		Transform deckZone = this.transform.parent.Find("DeckCanvas").Find ("DeckZone").transform;
		foreach(Transform kartu in deckZone)
		{
			CardScript cardScript = kartu.GetComponent<CardScript>() as CardScript;
			query = query + "insert into tb_deck(`id_user`,`kode_kartu`) values " + "('" + userManager.idUser + "','" + cardScript.kode + "'); ";
		}
		postData.AddField ("query",query);
		string phpPath = "http://localhost/Xrune/TA_database/card.php";
		WWW www = new WWW (phpPath,postData); //ganti path ke php-nya kalo perlu
		yield return www.isDone;
		Application.LoadLevel("MainMenu");
	}

}

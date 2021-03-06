﻿using UnityEngine;
using System.Collections;
using SimpleJSON;
using UnityEngine.UI;

public class SubmitScript : MonoBehaviour {

	UserDataScript userManager;

	void Start(){
		userManager = GameObject.Find("UserManager").GetComponent<UserDataScript>() as UserDataScript;
		this.transform.parent.Find ("profile").GetComponent<Text>().text = userManager.nama_user + "'s Deck";
	}

	public void submitDeck() {
		StartCoroutine(fetchUrlSubmitKartu());
	}
	

	IEnumerator fetchUrlSubmitKartu()
	{
		GameObject.Find ("Canvas").transform.Find("saveTxt").gameObject.SetActive(true);
		string query="";
		WWWForm postData= new WWWForm();
		 
		 
		postData.AddField("multi","1");

		//truncate dulu baru dimasukkin lagi
		query = "delete from tb_deck where id_user = '" + userManager.idUser + "';";
		//-----

		Transform deckZone = this.transform.parent.Find("DeckCanvas").Find ("MaskDeck").Find ("DeckZone").transform;
		foreach(Transform kartu in deckZone)
		{
			CardScript cardScript = kartu.GetComponent<CardScript>() as CardScript;
			query = query + "insert into tb_deck(`id_user`,`kode_kartu`) values " + "('" + userManager.idUser + "','" + cardScript.kode + "'); ";
		}
		postData.AddField ("query",query);
		
		WWW www = new WWW (userManager.phpPath,postData); //ganti path ke php-nya kalo perlu
		yield return www.isDone;
		yield return new WaitForSeconds(2f);
		Application.LoadLevel("MainMenu");
	}

}

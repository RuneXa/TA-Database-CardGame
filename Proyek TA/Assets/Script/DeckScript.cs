using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using SimpleJSON;
using System.Collections.Generic;

public class DeckScript : MonoBehaviour {

	public GameObject card;
	GameObject cardCpy;
	UserDataScript userManager;
	JSONNode jsonNode;
	int drawIndex;

	public void Start(){
		drawIndex = 0;
		userManager = GameObject.Find("UserManager").GetComponent("UserDataScript") as UserDataScript;
		StartCoroutine (fetchUrl());
	}

	
	public void Draw () {

		if(drawIndex < jsonNode.Count && GameObject.Find("Hand").transform.childCount < 10 ){
			InstantiateCard();
			drawIndex++;
		}
		else if(GameObject.Find("Hand").transform.childCount == 0) //kalau pas draw, terus kartunya abis
		{ 
			GameObject.Find("TurnManager").GetComponent<TurnHandlerScript>().turnPhase = TurnHandlerScript.Turn.LOSE;
			GameObject.Find("TurnManager").GetComponent<TurnHandlerScript>().resolvePhase();
		}

	}

	public void InstantiateCard(){

		cardCpy = GameObject.Instantiate(card,new Vector3(Input.mousePosition.x,Input.mousePosition.y,Input.mousePosition.z),card.transform.rotation) as GameObject;
		cardCpy.transform.SetParent(GameObject.Find("Hand").transform,false);
		
		// pasang atribut kartu ke script yang ada di kartu yang baru di spawn
		CardScript scriptCard = cardCpy.GetComponent("CardScript") as CardScript;
		scriptCard.kode = jsonNode[drawIndex]["kode_kartu"];
		scriptCard.nama = jsonNode[drawIndex]["nama"];
		scriptCard.attack = jsonNode[drawIndex]["attack"].AsInt;
		scriptCard.cost = jsonNode[drawIndex]["cost"].AsInt;
		scriptCard.warna = jsonNode[drawIndex]["warna"];
		scriptCard.img = jsonNode[drawIndex]["image"];
		scriptCard.card_init();

	}

	public IEnumerator fetchUrl()
	{
		string jsonString="";
		WWWForm postData= new WWWForm();
		 
		 
		//postData.AddField ("query", "select * from tb_kartu");
		postData.AddField ("query", "select * from tb_deck natural join tb_kartu where id_user = " + userManager.idUser + " order by rand()");

		WWW www = new WWW (userManager.phpPath,postData); //ganti path ke php-nya kalo perlu
		yield return www.isDone;
		for (int i=0; i<www.bytesDownloaded; i++) {
			jsonString+=(char)www.bytes [i]; //append char ke jsonString
		}
		jsonNode = JSON.Parse (jsonString); //parsing JSON

		//foreach (JSONNode N in jsonNode.Children)
		//{
		//	Debug.Log("Kode Kartu: " + N["kode_kartu"] + "\n" + "Efek: " + N["efek"]);
		//}

		//pas start scene, kalau data sudah ke fetch, langsung suruh draw 5;
		GameObject.Find("TurnManager").GetComponent<TurnHandlerScript>().turnPhase = TurnHandlerScript.Turn.START;
		GameObject.Find("TurnManager").GetComponent<TurnHandlerScript>().resolvePhase();
	}

}


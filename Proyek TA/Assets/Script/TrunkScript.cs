using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using SimpleJSON;

public class TrunkScript : MonoBehaviour  {

	public GameObject card;
	GameObject cardCpy;
	JSONNode jsonNode;

	public void Start(){
		StartCoroutine (fetchUrl());
	}

	IEnumerator fetchUrl()
	{
		string jsonString="";
		WWWForm postData= new WWWForm();
		postData.AddField ("username", "root");
		postData.AddField ("password", "");
		postData.AddField ("query", "select * from tb_kartu");
		
		
		string phpPath = "http://localhost/Xrune/TA_database/card.php";
		WWW www = new WWW (phpPath,postData); //ganti path ke php-nya kalo perlu
		yield return www.isDone;
		for (int i=0; i<www.bytesDownloaded; i++) {
			jsonString+=(char)www.bytes [i]; //append char ke jsonString
		}
		jsonNode = JSON.Parse (jsonString); //parsing JSON
		
		foreach (JSONNode N in jsonNode.Children)
		{
			cardCpy = Transform.Instantiate(card,new Vector3(0,0,0),card.transform.rotation) as GameObject; 

			// pasang atribut kartu ke script yang ada di kartu yang baru di spawn
			CardScript scriptCard = cardCpy.GetComponent("CardScript") as CardScript;
			scriptCard.kode = N["kode_kartu"];
			scriptCard.nama = N["nama"];
			scriptCard.attack = N["attack"].AsInt;
			scriptCard.cost = N["cost"].AsInt;
			scriptCard.warna = N["warna"];
			scriptCard.card_init();

			cardCpy.AddComponent<CardInEditorScript>();
			cardCpy.transform.SetParent(GameObject.Find("Canvas").transform.Find("TrunkCanvas").Find("TrunkZone"),false);
		
			if(this.transform.FindChild("TrunkZone").childCount % 9 == 0 && this.transform.FindChild("TrunkZone").childCount != 0)
			{
				this.transform.Find("TrunkZone").GetComponent<RectTransform>().sizeDelta = new Vector2(this.transform.FindChild("TrunkZone").GetComponent<RectTransform>().sizeDelta.x ,this.transform.FindChild("TrunkZone").GetComponent<RectTransform>().sizeDelta.y + 350);
			}

		}

	}

}

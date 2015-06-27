using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using SimpleJSON;

public class DeckZoneScript : MonoBehaviour {

	public GameObject card;
	GameObject cardCpy;
	UserDataScript userManager;
	JSONNode jsonNode;
	
	public void Start(){
		userManager = GameObject.Find("UserManager").GetComponent<UserDataScript>() as UserDataScript;
		StartCoroutine (fetchUrl());
	}
	
	IEnumerator fetchUrl()
	{
		string jsonString="";
		WWWForm postData= new WWWForm();
		 
		 
		postData.AddField ("query", "select * from tb_deck natural join tb_kartu where id_user = " + userManager.idUser);

		
		WWW www = new WWW (userManager.phpPath,postData); //ganti path ke php-nya kalo perlu
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
			scriptCard.img = N["image"];
			scriptCard.card_init();

			cardCpy.transform.SetParent(GameObject.Find("Canvas").transform.Find("DeckCanvas").Find ("MaskDeck").Find("DeckZone"),false);
			
			if(this.transform.Find("MaskDeck").FindChild("DeckZone").childCount % 15 == 0 && this.transform.Find("MaskDeck").FindChild("DeckZone").childCount != 0)
			{
				this.transform.Find("MaskDeck").Find("DeckZone").GetComponent<RectTransform>().sizeDelta = new Vector2(this.transform.Find("MaskDeck").FindChild("DeckZone").GetComponent<RectTransform>().sizeDelta.x ,this.transform.Find("MaskDeck").FindChild("DeckZone").GetComponent<RectTransform>().sizeDelta.y + 350);
			}
			
		}
		
	}


}

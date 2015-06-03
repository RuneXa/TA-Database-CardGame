using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using SimpleJSON;
using System.Collections.Generic;

public class DeckScript : MonoBehaviour {

	[SerializeField] public List<GameObject> card = new List<GameObject>(); //bikin list kartu apa aja yang ada berdasarkan prefab kartu di asset
	GameObject cardCpy;
	string randomPick;
	JSONNode jsonNode;

	public void Start(){
		StartCoroutine (fetchUrl());
	}

	
	public void Draw () {
		/*tadinya mau dipake kalo misalnya random query hasilnya nama, maka kartu yang keambil adalah kartu dengan nama yang sama
		for(int i=0; card.Count > i; i++)
		{
			if(card[i].name == randomPick) {
				cardCpy = Transform.Instantiate(card[i],new Vector3(Input.mousePosition.x,Input.mousePosition.y,Input.mousePosition.z),card[i].transform.rotation) as GameObject; 
				cardCpy.transform.SetParent(this.transform.parent.parent.FindChild("Hand"));
			}
		}*/

		//ini metode ambil kartu tanpa database
		int randomNum = (int)Random.Range(1,card.Count+1); //ambil kartu random dari list card
		cardCpy = Transform.Instantiate(card[randomNum-1],new Vector3(Input.mousePosition.x,Input.mousePosition.y,Input.mousePosition.z),card[randomNum-1].transform.rotation) as GameObject; 
		cardCpy.transform.SetParent(this.transform.parent.parent.FindChild("Hand"));

		// pasang atribut kartu ke script yang ada di kartu yang baru di spawn
		CardScript scriptCard = cardCpy.GetComponent("CardScript") as CardScript;
		scriptCard.kode = jsonNode[0]["kode_kartu"];
		scriptCard.warna = jsonNode[0]["warna"];
		scriptCard.attack = jsonNode[0]["att"].AsInt;
		scriptCard.cost = jsonNode[0]["cost"].AsInt;

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
			Debug.Log("Kode Kartu: " + N["kode_kartu"] + "\n" + "Efek: " + N["efek"]);
		}

	}

}


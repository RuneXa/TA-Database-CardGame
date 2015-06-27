using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using SimpleJSON;

public class EnemyScript : MonoBehaviour {
	
	[SerializeField] public string kode;
	[SerializeField] public string nama;
	[SerializeField] public int attack; 
	[SerializeField] public int health; 
	[SerializeField] public string img;
	[SerializeField] public Sprite[] imgSprite;
	JSONNode jsonNode;
	UserDataScript userManager;

	public void Start(){
		userManager = GameObject.Find("UserManager").GetComponent("UserDataScript") as UserDataScript;
		StartCoroutine (fetchUrl());
	}

	public IEnumerator fetchUrl()
	{
		string jsonString="";
		WWWForm postData= new WWWForm();
		 
		 
		postData.AddField ("query", "select * from tb_datamusuh order by rand() limit 1");
		
		WWW www = new WWW (userManager.phpPath,postData); //ganti path ke php-nya kalo perlu
		yield return www.isDone;
		for (int i=0; i<www.bytesDownloaded; i++) {
			jsonString+=(char)www.bytes [i]; //append char ke jsonString
		}
		jsonNode = JSON.Parse (jsonString); //parsing JSON
		kode = jsonNode[0]["id"];
		nama = jsonNode[0]["nama"];
		attack = jsonNode[0]["attack"].AsInt;
		health = jsonNode[0]["health"].AsInt;
		img = jsonNode[0]["image"];

		for(int i =0; i< imgSprite.Length;i++)
		{
			if(imgSprite[i].name == img){
				this.GetComponent<Image>().sprite = imgSprite[i];
				break;
			}
		}
	}
}

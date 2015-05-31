using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using SimpleJSON;

public class DeckScript : MonoBehaviour {

	public GameObject card;
	GameObject cardCpy;
	
	public void Draw () {
		StartCoroutine (fetchUrl());
		cardCpy = Transform.Instantiate(card,new Vector3(Input.mousePosition.x,Input.mousePosition.y,Input.mousePosition.z),card.transform.rotation) as GameObject; 
		cardCpy.GetComponent<Image>().color = RandomColor();
		cardCpy.transform.SetParent(this.transform.parent.parent.FindChild("Hand"));
	}
	


	IEnumerator fetchUrl()
	{
		string jsonString="";
		WWWForm postData= new WWWForm();
		postData.AddField ("username", "root");
		postData.AddField ("password", "");
		postData.AddField ("query", "select * from tb_kartu");
		
		WWW www = new WWW ("http://localhost/card.php",postData);
		yield return www.isDone;
		for (int i=0; i<www.bytesDownloaded; i++) {
			jsonString+=(char)www.bytes [i]; //append char ke jsonString
		}
		JSONNode jsonNode = JSON.Parse (jsonString); //parsing JSON
		foreach (JSONNode N in jsonNode.Children)
		{
			Debug.Log("Kode Kartu: " + N["kode_kartu"] + "\n" + "Efek: " + N["efek"]);
		}

	}

	Color RandomColor() {
		return new Color(Random.value, Random.value, Random.value);
	}

}

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DeckScript : MonoBehaviour {

	public GameObject card;
	GameObject cardCpy;
	
	public void Draw () {
		StartCoroutine (fetchUrl());
		cardCpy = Transform.Instantiate(card,new Vector3(Input.mousePosition.x,Input.mousePosition.y,Input.mousePosition.z),card.transform.rotation) as GameObject; 
		cardCpy.GetComponent<Image>().color = RandomColor();
		cardCpy.transform.SetParent(this.transform.parent.parent.FindChild("Hand"));
	}
	

<<<<<<< HEAD
	IEnumerator fetchUrl()
	{
		WWW www = new WWW("http://localhost/card.php");
		yield return www.isDone;
		for (int i=0; i<www.bytesDownloaded; i++) {
			Debug.Log((char)www.bytes[i]);
		}
=======
	Color RandomColor() {
		return new Color(Random.value, Random.value, Random.value);
	}

>>>>>>> origin/master

	}
}

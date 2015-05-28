using UnityEngine;
using System.Collections;

public class DeckScript : MonoBehaviour {

	public GameObject card;
	GameObject cardCpy;


	public void Draw () {
		cardCpy = Transform.Instantiate(card,new Vector3(Input.mousePosition.x,Input.mousePosition.y,Input.mousePosition.z),card.transform.rotation) as GameObject; 
		cardCpy.transform.SetParent(this.transform.parent.parent.FindChild("Hand"));
	}


}

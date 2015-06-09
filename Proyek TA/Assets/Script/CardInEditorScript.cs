using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public class CardInEditorScript : MonoBehaviour, IPointerClickHandler {

	// Note : Script ini untuk instantiate object card yang diklik dan langsung di taro di canvas DeckZone
	GameObject card;
	GameObject cardCpy;

	void Start () {
		card = this.gameObject;
		this.GetComponent<DragScript>().enabled = false;
	}
	
	public void OnPointerClick (PointerEventData eventData){
		cardCpy = Transform.Instantiate(card,new Vector3(0,0,0),card.transform.rotation) as GameObject; 
		cardCpy.transform.SetParent(GameObject.Find("DeckZone").transform,false);
		cekSizeDeckZone();
		Destroy(cardCpy.GetComponent<CardInEditorScript>());
	}

	void OnDestroy(){
		this.GetComponent<DragScript>().enabled = true;
	}

	void cekSizeDeckZone(){

		if(this.transform.parent.parent.parent.Find("DeckCanvas").Find("DeckZone").childCount % 15 == 0 && this.transform.parent.parent.parent.Find("DeckCanvas").Find("DeckZone").childCount !=0)
		{
			this.transform.parent.parent.parent.Find("DeckCanvas").Find("DeckZone").GetComponent<RectTransform>().sizeDelta = new Vector2(this.transform.parent.parent.parent.Find("DeckCanvas").Find("DeckZone").GetComponent<RectTransform>().sizeDelta.x ,this.transform.parent.parent.parent.Find("DeckCanvas").Find("DeckZone").GetComponent<RectTransform>().sizeDelta.y + 350);
		}
		/*
		else if(this.transform.parent.parent.parent.Find("DeckCanvas").Find("DeckZone").childCount == 14)
		{
			this.transform.parent.parent.parent.Find("DeckCanvas").Find("DeckZone").GetComponent<RectTransform>().sizeDelta = new Vector2(this.transform.parent.parent.parent.Find("DeckCanvas").Find("DeckZone").GetComponent<RectTransform>().sizeDelta.x ,350);
		}
		*/
		
	}




}

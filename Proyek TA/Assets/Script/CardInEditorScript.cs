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
		if(GameObject.Find ("DeckZone").transform.childCount < 60){
			GameObject.Find ("Canvas").transform.Find ("cardMaxTxt").gameObject.SetActive(false);
			cardCpy = Transform.Instantiate(card,new Vector3(0,0,0),card.transform.rotation) as GameObject; 
			cardCpy.transform.SetParent(GameObject.Find("DeckZone").transform,false);
			cekSizeDeckZone();
			Destroy(cardCpy.GetComponent<CardInEditorScript>());
		}
		else
		{
			Debug.Log ("Jumlah Maksimal Deck = 60");
			GameObject.Find ("Canvas").transform.Find ("cardMaxTxt").gameObject.SetActive(true);
		}
	}

	void OnDestroy(){
		this.GetComponent<DragScript>().enabled = true;
	}

	void cekSizeDeckZone(){

		RectTransform sizeCanvas = this.transform.parent.parent.parent.parent.Find("DeckCanvas").Find("MaskDeck").Find("DeckZone").GetComponent<RectTransform>();

		switch(this.transform.parent.parent.parent.parent.Find("DeckCanvas").Find("MaskDeck").Find("DeckZone").childCount){
		case 0 : sizeCanvas.sizeDelta = new Vector2(sizeCanvas.sizeDelta.x,250); break;
		case 15 : sizeCanvas.sizeDelta = new Vector2(sizeCanvas.sizeDelta.x,500); break;
		case 30 : sizeCanvas.sizeDelta = new Vector2(sizeCanvas.sizeDelta.x,750); break;
		case 45 : sizeCanvas.sizeDelta = new Vector2(sizeCanvas.sizeDelta.x,1000); break;
		case 50 : sizeCanvas.sizeDelta = new Vector2(sizeCanvas.sizeDelta.x,1100); break;
		}

		//if(this.transform.parent.parent.parent.parent.Find("DeckCanvas").Find("MaskDeck").Find("DeckZone").childCount % 15 == 0 && this.transform.parent.parent.parent.parent.Find("DeckCanvas").Find("MaskDeck").Find("DeckZone").childCount !=0)
		//{
			//this.transform.parent.parent.parent.parent.Find("DeckCanvas").Find("MaskDeck").Find("DeckZone").GetComponent<RectTransform>().sizeDelta = new Vector2(this.transform.parent.parent.parent.parent.Find("DeckCanvas").Find("MaskDeck").Find("DeckZone").GetComponent<RectTransform>().sizeDelta.x ,this.transform.parent.parent.parent.parent.Find("DeckCanvas").Find("MaskDeck").Find("DeckZone").GetComponent<RectTransform>().sizeDelta.y + 350);
		//}
		/*
		else if(this.transform.parent.parent.parent.Find("DeckCanvas").Find("DeckZone").childCount == 14)
		{
			this.transform.parent.parent.parent.Find("DeckCanvas").Find("DeckZone").GetComponent<RectTransform>().sizeDelta = new Vector2(this.transform.parent.parent.parent.Find("DeckCanvas").Find("DeckZone").GetComponent<RectTransform>().sizeDelta.x ,350);
		}
		*/
		
	}




}

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;
public class DragScript : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerClickHandler, IPointerEnterHandler {
	
	public Transform parentToReturnTo = null;
	public Transform placeholderParent = null;

	GameObject placeholder = null;


	public void OnBeginDrag(PointerEventData eventData) {

		//Bikin object baru di hirarki untuk layout element
		placeholder = new GameObject();
		placeholder.transform.SetParent( this.transform.parent );
		LayoutElement le = placeholder.AddComponent<LayoutElement>();
		le.preferredWidth = this.GetComponent<LayoutElement>().preferredWidth;
		le.preferredHeight = this.GetComponent<LayoutElement>().preferredHeight;
		le.flexibleWidth = 0;
		le.flexibleHeight = 0;

		placeholder.transform.SetSiblingIndex( this.transform.GetSiblingIndex() );
		
		parentToReturnTo = this.transform.parent;
		placeholderParent = parentToReturnTo;
		this.transform.SetParent( this.transform.parent.parent );
		
		GetComponent<CanvasGroup>().blocksRaycasts = false;

	}
	
	public void OnDrag(PointerEventData eventData) {

		//set posisi object = posisi cursor dan urutkan posisinya
		this.transform.position = eventData.position;
		if(placeholder.transform.parent != placeholderParent)
			placeholder.transform.SetParent(placeholderParent);
		int newSiblingIndex = placeholderParent.childCount;
		for(int i=0; i < placeholderParent.childCount; i++) {
			if(this.transform.position.x < placeholderParent.GetChild(i).position.x) {
				newSiblingIndex = i;
				if(placeholder.transform.GetSiblingIndex() < newSiblingIndex)
					newSiblingIndex--;
				break;
			}
		}
		placeholder.transform.SetSiblingIndex(newSiblingIndex);


	}
	
	public void OnEndDrag(PointerEventData eventData) {

		//pasang parent object untuk ditempatkan pada canvas
		this.transform.SetParent( parentToReturnTo );
		this.transform.SetSiblingIndex( placeholder.transform.GetSiblingIndex() );
		GetComponent<CanvasGroup>().blocksRaycasts = true;

		Destroy(placeholder);


		//ini dijalanin kalau kartunya lagi di Deck Editor
		if(this.transform.parent.name == "TrunkZone" )
		{
			GameObject.Destroy(this.gameObject);
		}

	}
	
	#region IPointerClickHandler implementation
	public void OnPointerClick (PointerEventData eventData)
	{
		if (eventData.button == PointerEventData.InputButton.Right) {
			if(Application.loadedLevelName=="DeckEditor")
			{
				Destroy(this.gameObject);
			}
		}
	}
	#endregion

	#region IPointerEnter implementation
	public void OnPointerEnter (PointerEventData eventData)
	{
		if(Application.loadedLevelName == "PlayScene")
		{
			if(eventData.pointerEnter != null)
			{
				Text nameTxt = GameObject.Find ("Canvas").transform.Find("CardDetail").FindChild("CardName").GetComponent<Text>();
				Text descTxt = GameObject.Find ("Canvas").transform.Find("CardDetail").FindChild("CardDesc").GetComponent<Text>();
				CardScript detailCard = this.GetComponent<CardScript>() as CardScript;
				nameTxt.text = detailCard.nama;
				descTxt.text = ("Attack\t= " + detailCard.attack + "\nCost\t= " + detailCard.cost) ;
			}
		}
	}

	#endregion

}

using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler {

	public void OnPointerEnter(PointerEventData eventData) {

		if(eventData.pointerDrag == null){
			return;
		}

		DragScript d = eventData.pointerDrag.GetComponent<DragScript>();
		if(d != null) {
			d.placeholderParent = this.transform;
		}
	}
	
	public void OnPointerExit(PointerEventData eventData) {

		if(eventData.pointerDrag == null)
			return;

		DragScript d = eventData.pointerDrag.GetComponent<DragScript>();
		if(d != null && d.placeholderParent==this.transform) {
			d.placeholderParent = d.parentToReturnTo;
		}
	}
	
	public void OnDrop(PointerEventData eventData) {

		DragScript d = eventData.pointerDrag.GetComponent<DragScript>();
		if(d != null) {
			d.parentToReturnTo = this.transform;
		}

	}
}

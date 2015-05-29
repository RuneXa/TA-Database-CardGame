using UnityEngine;
using System.Collections;

public class ResolveScript : MonoBehaviour {

	public void putCardtoGrave(){

		Transform field = this.transform.parent.parent.FindChild("Field");

			while(field.childCount > 0){
				field.GetChild(0).SetParent(field.parent.FindChild("Graveyard"));
			}


	}
}

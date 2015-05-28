using UnityEngine;
using System.Collections;

public class GraveScript : MonoBehaviour {

	public void Update(){
		if(this.transform.childCount > 0){
			for(int i = 0; i < this.transform.childCount; i++){
				this.transform.GetChild(i).position = this.transform.position;
			}
		}
	}

}

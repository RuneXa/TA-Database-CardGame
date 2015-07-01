using UnityEngine;
using System.Collections;

public class ResolveScript : MonoBehaviour {

	public void resolveCard(){
		if(GameObject.Find("TurnManager").GetComponent<TurnHandlerScript>().turnPhase == TurnHandlerScript.Turn.MAINPLAYER){
			GameObject.Find("TurnManager").GetComponent<TurnHandlerScript>().turnPhase++;
			GameObject.Find("TurnManager").GetComponent<TurnHandlerScript>().resolvePhase();
		}
	}

	public void forfeit(){
		if(GameObject.Find("TurnManager").GetComponent<TurnHandlerScript>().turnPhase == TurnHandlerScript.Turn.MAINPLAYER){
			GameObject.Find("TurnManager").GetComponent<TurnHandlerScript>().turnPhase = TurnHandlerScript.Turn.LOSE;
			GameObject.Find("TurnManager").GetComponent<TurnHandlerScript>().resolvePhase();
		}
	}
}

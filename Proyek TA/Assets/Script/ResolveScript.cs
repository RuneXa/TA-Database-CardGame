using UnityEngine;
using System.Collections;

public class ResolveScript : MonoBehaviour {

	public void resolveCard(){

		GameObject.Find("TurnManager").GetComponent<TurnHandlerScript>().turnPhase = TurnHandlerScript.Turn.RESOLVEPLAYER;
		GameObject.Find("TurnManager").GetComponent<TurnHandlerScript>().resolvePhase();

	}
}

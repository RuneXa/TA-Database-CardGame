using UnityEngine;
using System.Collections;

public class ResolveScript : MonoBehaviour {

	public void resolveCard(){

		GameObject.Find("TurnManager").GetComponent<TurnHandlerScript>().turnPhase++;
		GameObject.Find("TurnManager").GetComponent<TurnHandlerScript>().resolvePhase();

	}
}

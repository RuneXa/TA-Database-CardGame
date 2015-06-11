using UnityEngine;
using System.Collections;

public class TurnHandlerScript : MonoBehaviour {

	public enum Turn{
		NULL,
		START,
		DRAW,
		MAINPLAYER,
		RESOLVEPLAYER,
		MAINENEMY,
		RESOLVEENEMY,
		END,
		WIN,
		LOSE
	}

	public Turn turnPhase;

	void Start () {
		turnPhase = Turn.NULL;
		resolvePhase();
	}

	public void resolvePhase () {
		switch(turnPhase){
			case (Turn.START):
			StartCoroutine(turnStart());
				break;
			case (Turn.DRAW):
			StartCoroutine(turnDraw());
				break;
			case (Turn.MAINPLAYER):
			StartCoroutine(turnMainPlayer());
				break;
			case (Turn.RESOLVEPLAYER):
			StartCoroutine(turnResolvePlayer());
				break;
			case (Turn.MAINENEMY):
			//turnMainEnemy();
				break;
			case (Turn.RESOLVEENEMY):
			//turnResolveEnemy();
				break;
			case (Turn.END):
			//turnEnd();
				break;
		}
	}

	IEnumerator turnStart()
	{
		for(int i = 0; i<5;i++){
			GameObject.Find("b_draw").GetComponent<DeckScript>().Draw();
			yield return new WaitForSeconds(0.3f);
		}
		turnPhase++;
		resolvePhase();
	}

	IEnumerator turnDraw()
	{
		yield return new WaitForSeconds(0.5f);
		GameObject.Find("b_draw").GetComponent<DeckScript>().Draw();
		turnPhase++;
		resolvePhase();
	}

	IEnumerator turnMainPlayer()
	{
		yield return null;
	}

	IEnumerator turnResolvePlayer()
	{
		int jumlahAtk = 0;

		foreach(Transform cardInField in GameObject.Find("Field").transform)
		{
			jumlahAtk += cardInField.GetComponent<CardScript>().attack;
		}

		Debug.Log (jumlahAtk); // hp musuh -= jumlahAtk

		while(GameObject.Find ("Field").transform.childCount > 0){
			GameObject.Find ("Field").transform.GetChild(0).SetParent(GameObject.Find ("Field").transform.parent.FindChild("Graveyard"));
			yield return new WaitForSeconds(0.2f);
		}

		// if hp musuh == 0 turn phase = win, else turnphase++
		turnPhase++;
		resolvePhase();
	}

}

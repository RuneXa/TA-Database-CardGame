using UnityEngine;
using System.Collections;

public class TurnHandlerScript : MonoBehaviour {

	public enum Turn{
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
		turnPhase = Turn.START;
	}

	void resolvePhase () {
		switch(turnPhase){
			case (Turn.START):
			//turnStart();
				break;
			case (Turn.DRAW):
			//turnDraw();
				break;
			case (Turn.MAINPLAYER):
			//turnMainPlayer();
				break;
			case (Turn.RESOLVEPLAYER):
			//turnResolvePlayer();
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


}

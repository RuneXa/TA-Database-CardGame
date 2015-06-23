using UnityEngine;
using System.Collections;
using UnityEngine.UI;

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
	public EnemyScript enemyData;
	public UserDataScript userData;
	public int playerHealth;
	public int playerResources; 
	public Text playerHP;
	public Text playerCT;
	public Text enemyHP;

	void Start () {
		turnPhase = Turn.NULL;
		playerHealth = 100;
		playerResources = 3;
		userData = GameObject.Find ("UserManager").GetComponent<UserDataScript>();
		enemyData = GameObject.Find("Canvas").transform.Find("Enemy").GetComponent<EnemyScript>();
		playerHP = GameObject.Find ("texts").transform.Find ("t_playerHealth").GetComponent<Text>();
		enemyHP = GameObject.Find ("texts").transform.Find ("t_enemyHealth").GetComponent<Text>();
		playerCT = GameObject.Find ("texts").transform.Find ("t_playerResources").GetComponent<Text>();
		editParamValue();
		resolvePhase();
	}

	public void resolvePhase () {
		Debug.Log (turnPhase);
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
			StartCoroutine(turnMainEnemy());
				break;
			case (Turn.RESOLVEENEMY):
			Debug.Log ("oioi");
			StartCoroutine(turnResolveEnemy());
				break;
			case (Turn.END):
			StartCoroutine(turnEnd());
				break;
		}
	}

	public void editParamValue(){
		playerHP.text = userData.nama_user+"'s Health : "+ playerHealth.ToString();
		playerCT.text = userData.nama_user+"'s Resources : "+ playerResources.ToString();
		enemyHP.text = enemyData.nama + "'s Health : "+ enemyData.health.ToString();
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
		playerResources++;
		editParamValue();
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

		enemyData.health -= jumlahAtk;
		editParamValue();

		Debug.Log ("Jumlah serangan : "+jumlahAtk+"\nNyawa Musuh : "+enemyData.health); // hp musuh -= jumlahAtk

		while(GameObject.Find ("Field").transform.childCount > 0){
			GameObject.Find ("Field").transform.GetChild(0).SetParent(GameObject.Find ("Field").transform.parent.FindChild("Graveyard"));
			yield return new WaitForSeconds(0.2f);
		}

		// if hp musuh == 0 turn phase = win, else turnphase++
		turnPhase++;
		resolvePhase();
	}

	IEnumerator turnMainEnemy()
	{
		yield return null;
		turnPhase++;
		resolvePhase();
	}

	IEnumerator turnResolveEnemy()
	{
		int jumlahAtk = 0;
		jumlahAtk = (int) (enemyData.attack * Random.value);
		
		playerHealth -= jumlahAtk;
		editParamValue();
		
		Debug.Log ("Jumlah serangan : "+jumlahAtk+"\nNyawa Player : "+playerHealth); // hp player -= jumlahAtk

		yield return new WaitForSeconds(0.3f);

		// if hp player == 0 turn phase = lose, else turnphase++
		turnPhase++;
		resolvePhase();
	}

	IEnumerator turnEnd()
	{
		yield return new WaitForSeconds(0.3f);
		turnPhase = Turn.DRAW;
		resolvePhase();
	}
}

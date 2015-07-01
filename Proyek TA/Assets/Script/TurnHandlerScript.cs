using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using SimpleJSON;

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
	int jumlahAtk;
	int jumlahDef;
	int jumlahHeal;
	int jumlahRsc;


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
			StartCoroutine(turnResolveEnemy());
				break;
			case (Turn.END):
			StartCoroutine(turnEnd());
				break;
			case (Turn.WIN):
			StartCoroutine(win());
				break;
			case (Turn.LOSE):
				StartCoroutine(lose());
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
			this.GetComponent<DeckScript>().Draw();
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
		this.GetComponent<DeckScript>().Draw();
		turnPhase++;
		resolvePhase();
	}

	IEnumerator turnMainPlayer()
	{
		yield return null;
	}

	IEnumerator turnResolvePlayer()
	{

		jumlahAtk = 0;
		jumlahDef = 0;
		jumlahHeal = 0;
		jumlahRsc = 0;

		foreach(Transform cardInField in GameObject.Find("RField").transform)
		{
			playerResources += cardInField.GetComponent<CardScript>().cost;
		}

		foreach(Transform cardInField in GameObject.Find("Field").transform)
		{
			jumlahAtk += cardInField.GetComponent<CardScript>().attack;
			jumlahDef += cardInField.GetComponent<CardScript>().defend;
			jumlahHeal += cardInField.GetComponent<CardScript>().heal;
			jumlahRsc += cardInField.GetComponent<CardScript>().cost;
		}

		if(jumlahRsc <= playerResources){
			GameObject.Find("Canvas").transform.Find("texts").transform.Find("t_resourceKurang").gameObject.SetActive(false);
			enemyData.health -= jumlahAtk;
			playerHealth += jumlahHeal;
			playerResources -= jumlahRsc;
			editParamValue();

			Debug.Log ("Jumlah serangan : "+jumlahAtk+"\nNyawa Musuh : "+enemyData.health); // hp musuh -= jumlahAtk

			while(GameObject.Find ("RField").transform.childCount > 0){
				GameObject.Find ("RField").transform.GetChild(0).SetParent(GameObject.Find ("RField").transform.parent.FindChild("Graveyard"));
				yield return new WaitForSeconds(0.2f);
			}

			while(GameObject.Find ("Field").transform.childCount > 0){
				GameObject.Find ("Field").transform.GetChild(0).SetParent(GameObject.Find ("Field").transform.parent.FindChild("Graveyard"));
				yield return new WaitForSeconds(0.2f);
			}

			if(enemyData.health <= 0)
			{
				turnPhase = Turn.WIN;
				resolvePhase();
			}
				else
			{
				turnPhase++;
				resolvePhase();
			}
		}
		else
		{
			GameObject.Find("Canvas").transform.Find("texts").transform.Find("t_resourceKurang").gameObject.SetActive(true);
			Debug.Log ("Player Resource Tidak Cukup");
			turnPhase = Turn.MAINPLAYER;
			resolvePhase();
		}
	}

	IEnumerator turnMainEnemy()
	{
		yield return null;
		turnPhase++;
		resolvePhase();
	}

	IEnumerator turnResolveEnemy()
	{
		jumlahAtk = 0;
		jumlahAtk = (int) (enemyData.attack * Random.value) - jumlahDef;
		if(jumlahAtk < 0)
		{
			jumlahAtk = 0;
		}

		playerHealth -= jumlahAtk;
		editParamValue();
		
		Debug.Log ("Jumlah serangan : "+jumlahAtk+"\nNyawa Player : "+playerHealth); // hp player -= jumlahAtk

		yield return new WaitForSeconds(0.3f);

		if(playerHealth <= 0)
		{
			turnPhase = Turn.LOSE;
			resolvePhase();
		}
		else
		{
			turnPhase++;
			resolvePhase();
		}
	}

	IEnumerator turnEnd()
	{
		yield return new WaitForSeconds(0.3f);
		turnPhase = Turn.DRAW;
		resolvePhase();
	}

	IEnumerator win(){

		GameObject.Find("Canvas").transform.Find("Enemy").gameObject.SetActive(false);
		GameObject.Find("Canvas").transform.Find("texts").transform.Find("t_win").gameObject.SetActive(true);
		string jsonString="";
		WWWForm postData= new WWWForm();

		postData.AddField ("query", 
		                   "update tb_winrate set win =+ 1 where id_user = '" + userData.idUser + "'; " +
		                   "update tb_user set exp =+ (select expVar from tb_datamusuh where id = '" + enemyData.kode + "') where id_user = '" + userData.idUser + "';" );
		
		WWW www = new WWW (userData.phpPath,postData);
		yield return www.isDone;
		for (int i=0; i<www.bytesDownloaded; i++) {
			jsonString+=(char)www.bytes [i]; //append char ke jsonString
		}
		//JSONNode jsonNode = JSON.Parse (jsonString); //parsing JSON

		yield return new WaitForSeconds(2f);
		Application.LoadLevel("MainMenu");
	}

	IEnumerator lose(){

		GameObject.Find("Canvas").transform.Find("texts").transform.Find("t_lose").gameObject.SetActive(true);
		string jsonString="";
		WWWForm postData= new WWWForm();
		
		postData.AddField ("query", "update tb_winrate set loss =+ 1 where id_user = '" + userData.idUser + "'");

		WWW www = new WWW (userData.phpPath,postData);
		yield return www.isDone;
		for (int i=0; i<www.bytesDownloaded; i++) {
			jsonString+=(char)www.bytes [i]; //append char ke jsonString
		}
		//JSONNode jsonNode = JSON.Parse (jsonString); //parsing JSON
		
		yield return new WaitForSeconds(2f);
		Application.LoadLevel("MainMenu");
	}
}

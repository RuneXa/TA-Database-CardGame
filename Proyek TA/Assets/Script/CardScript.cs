using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CardScript : MonoBehaviour {

	public TurnHandlerScript turnHandler;

	[SerializeField] public string kode; //kode kartu
	[SerializeField] public string nama; //nama kartu
	[SerializeField] public int attack; //attack kartu
	[SerializeField] public int defend; //def kartu
	[SerializeField] public int heal; //nilai heal kartu
	[SerializeField] public int cost; //biaya untuk pakai kartu
	[SerializeField] public string warna;
	[SerializeField] public string img;
	[SerializeField] public Sprite[] imgSprite;

	//public Image img; //gambar kartu, ga dipake dulu karena udah dibikinin duluan di prefab.

	void Start(){
		if(Application.loadedLevelName == "PlayScene")
		{
			turnHandler = GameObject.Find("TurnManager").GetComponent<TurnHandlerScript>();
		}
	}

	void Update(){
		if(Application.loadedLevelName == "PlayScene")
		{	
			if(turnHandler.turnPhase == TurnHandlerScript.Turn.MAINPLAYER)
			{
				this.GetComponent<DragScript>().enabled = true;
			}
			else
			{
				this.GetComponent<DragScript>().enabled = false;
			}
		}
	}


	public void card_init(){

		Color tempWarna = new Color();
		if(warna == "red")
		{
			tempWarna=Color.red;
			this.transform.FindChild("Label_Value").FindChild("Text").GetComponent<Text>().text = attack.ToString();
		}
		if(warna == "blue")
		{
			tempWarna=Color.blue;
			this.transform.FindChild("Label_Value").FindChild("Text").GetComponent<Text>().text = defend.ToString();
		}
		if(warna == "green")
		{
			tempWarna=Color.green;
			this.transform.FindChild("Label_Value").FindChild("Text").GetComponent<Text>().text = heal.ToString();
		}

		this.gameObject.GetComponent<Image>().color = tempWarna; //set warna dasar
		this.transform.FindChild("Label_Cost").FindChild("Text").GetComponent<Text>().text = cost.ToString();
		//this.transform.FindChild("Label_Nama").FindChild("Text").GetComponent<Text>().text = nama;

		if(img != null){
			StartCoroutine(setImage ());
		}

	}

	IEnumerator setImage()
	{
		for(int i =0; i< imgSprite.Length;i++)
		{
			if(imgSprite[i].name == img){
				this.transform.FindChild("Label_Gambar").GetComponent<Image>().sprite = imgSprite[i];
				break;
			}
		}

		yield return null;
	}

}

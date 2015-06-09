using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CardScript : MonoBehaviour {

	[SerializeField] public string kode; //kode kartu
	[SerializeField] public string nama; //nama kartu
	[SerializeField] public int attack; //attack kartu
	[SerializeField] public int cost; //biaya untuk pakai kartu
	[SerializeField] public string warna;

	//public Image img; //gambar kartu, ga dipake dulu karena udah dibikinin duluan di prefab.

	public void card_init(){

		Color tempWarna = new Color();
		if(warna == "red")
		{
			tempWarna=Color.red;
		}
		if(warna == "blue")
		{
			tempWarna=Color.blue;
		}
		if(warna == "green")
		{
			tempWarna=Color.green;
		}

		this.gameObject.GetComponent<Image>().color = tempWarna; //set warna dasar
		this.transform.FindChild("Label_Cost").FindChild("Text").GetComponent<Text>().text = cost.ToString();
		this.transform.FindChild("Label_Attack").FindChild("Text").GetComponent<Text>().text = attack.ToString();
		//this.transform.FindChild("Label_Nama").FindChild("Text").GetComponent<Text>().text = nama;
		//this.transform.FindChild("Label_Gambar").GetComponent<Image>().sprite = img;
	}

}

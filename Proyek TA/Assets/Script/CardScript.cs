using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CardScript : MonoBehaviour {

	[SerializeField] public string kode; //kode kartu
	[SerializeField] public string warna; //warna/tipe kartu
	[SerializeField] public int attack; //attack kartu
	[SerializeField] public int cost; //biaya untuk pakai kartu

	//public Image img; //gambar kartu, ga dipake dulu karena udah dibikinin duluan di prefab.
}

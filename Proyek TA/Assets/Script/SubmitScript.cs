using UnityEngine;
using System.Collections;

public class SubmitScript : MonoBehaviour {

	public void onClick()
	{
		Transform deckZone = this.transform.parent.parent.FindChild ("DeckZone");
		foreach (Transform kartu in deckZone)
		{
			Debug.Log(kartu.GetComponent<CardScript>().kode);
		}
	}
}

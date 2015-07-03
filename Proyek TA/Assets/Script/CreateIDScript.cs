using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using SimpleJSON;

public class CreateIDScript : MonoBehaviour {

	UserDataScript userManager;
	Text idInput;
	InputField passInput;
	Text namaInput;
	JSONNode jsonNode;
	GameObject txtGagal;

	void Start () {  
		if(Application.loadedLevelName == "CreateID1"){
			txtGagal = GameObject.Find("Canvas").transform.Find ("LabelGagal").gameObject;
			txtGagal.SetActive(false);
		}
		userManager = GameObject.Find("UserManager").GetComponent<UserDataScript>();
		if(Application.loadedLevelName == "CreateID1"){
			idInput = GameObject.Find ("InputID").transform.Find("Text").GetComponent<Text>();
			passInput = GameObject.Find ("InputPass").GetComponent<InputField>();
		}
		else if(Application.loadedLevelName == "CreateID2"){
			namaInput = GameObject.Find ("InputNama").transform.Find("Text").GetComponent<Text>();
		}
	}

	public void Lanjut1() {
		if(!idInput.text.Equals("admin"))
		{
			StartCoroutine(cekUser());
		}
	}

	public void Lanjut2(){
		StartCoroutine(insertData());
	}

	public IEnumerator cekUser()
	{
		string jsonString="";
		WWWForm postData= new WWWForm();
		postData.AddField ("query", "select id_user from tb_user where id_user = '" + idInput.text + "'");
		
		WWW www = new WWW (userManager.phpPath,postData); //ganti path ke php-nya kalo perlu
		yield return www.isDone;
		for (int i=0; i<www.bytesDownloaded; i++) {
			jsonString+=(char)www.bytes [i]; //append char ke jsonString
		}
		jsonNode = JSON.Parse (jsonString); //parsing JSON
		if(jsonNode[0] == null)
		{
			userManager.idUser = idInput.text;
			userManager.password = passInput.text;
			Application.LoadLevel("CreateID2");
		}
		else
		{
			txtGagal.SetActive(true);
		}
	}

	public IEnumerator insertData()
	{
		userManager.nama_user = namaInput.text;

		string jsonString="";
		WWWForm postData= new WWWForm();
		postData.AddField ("query", "insert into tb_user (id_user,password,nama,exp) values ('"+userManager.idUser+"','"+userManager.password+"','"+userManager.nama_user+"','0');");

		WWW www = new WWW (userManager.phpPath,postData); //ganti path ke php-nya kalo perlu
		yield return www.isDone;
		for (int i=0; i<www.bytesDownloaded; i++) {
			jsonString+=(char)www.bytes [i]; //append char ke jsonString
		}

		userManager.idUser = "";
		userManager.nama_user="";
		userManager.password="";
		Application.LoadLevel("Login");

	}


	public void Back(){
		Application.LoadLevel("Login");
	}

	public void Back1(){
		Application.LoadLevel("CreateID1");
	}
}

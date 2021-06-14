using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Gamerules : Photon.MonoBehaviour
{
	public static Gamerules Instance;
	public Text Res;
	public Text score1;
	public Text score2;
	public PhotonView ph;
    public GameObject spawn1;
	public GameObject spawn2;
    public GameObject pref1;
	public GameObject pref2;
	public GameObject pref3;    
	[HideInInspector] public GameObject localPlayer;
	public GameObject RespawnMenu;
	private float TimerAmount = 5f;
	private float TimerAmount1 = 5f;
	private float TimerAmount2 = 5f;
	private bool RunSpawnTimer = false;
	private bool RunTimer1 = false;
	private bool RunTimer2 = false;
	
	void Awake() {
	Instance = this;
	}	
	
void Start()
    {
		PhotonNetwork.automaticallySyncScene = true;
		int num = PhotonNetwork.countOfPlayers;
		num--;
		Debug.Log(num);
        if(num==0) {
        PhotonNetwork.Instantiate(pref2.name,
            new Vector2(spawn2.transform.position.x , spawn2.transform.position.y ), Quaternion.identity,
            0);
	}
	else {
		PhotonNetwork.Instantiate(pref1.name,
            new Vector2(spawn1.transform.position.x , spawn1.transform.position.y ), Quaternion.identity,
            0);
}
    }	

    void Update()
    {
		    ph.RPC("CheckScores", PhotonTargets.AllBuffered);
			if (RunSpawnTimer) {
			StartRespawn();
	}
			if (RunTimer1) {
			ShowMessage1();
}    
			if (RunTimer2) {
			ShowMessage2();
}   
    }
	
	[PunRPC]
	private void CheckScores() {
	score1.text = Globals.score1.ToString();
	score2.text = Globals.score2.ToString();
	if (Globals.score1==5 || Globals.score2 == 5) {
	if (Globals.score1==5) {
	RunTimer1 = true;	
    Res.text = "Player 1 wins!";
}
	if (Globals.score2==5) {
	RunTimer2 = true;	
	Res.text = "Player 2 wins!";
}
	ph.RPC("Endgame", PhotonTargets.AllBuffered);
}
	
}
	private void ShowMessage1() {
	TimerAmount1 -= Time.deltaTime;
	if (TimerAmount1<=0) {
	ph.RPC("Endgame", PhotonTargets.AllBuffered);
}
}
	private void ShowMessage2() {
	TimerAmount2 -= Time.deltaTime;
	if (TimerAmount2<=0) {
	ph.RPC("Endgame", PhotonTargets.AllBuffered);
}
}
	[PunRPC]
	private void Endgame() {
	Cursor.visible = true;
	SceneManager.LoadScene("_Menu");
	PhotonNetwork.LeaveRoom();
}

	public void EnableRespawn() {
	TimerAmount = 5f;
	RunSpawnTimer = true;
	RespawnMenu.SetActive(true);
}

	private void StartRespawn() {
	TimerAmount -= Time.deltaTime;
	if (TimerAmount <= 0) {
	string ttag = localPlayer.tag;
	ph.RPC("ChangeScore", PhotonTargets.AllBuffered, ttag);
	localPlayer.GetComponent<PhotonView>().RPC("Respawn", PhotonTargets.AllBuffered);
	RespawnLocation();
	RespawnMenu.SetActive(false);
	RunSpawnTimer = false;
}
}
	public void RespawnLocation() {
	int RandomValue = Random.Range(1, 3);
	Debug.Log(RandomValue);
	if (RandomValue == 1)
	localPlayer.transform.position = spawn1.transform.position;
	
	else if (RandomValue == 2)
	localPlayer.transform.position = spawn2.transform.position;
	
	else 
	localPlayer.transform.position = spawn1.transform.position;
}
	[PunRPC]
	private void ChangeScore(string tag) {
	Debug.Log(tag);
	if (tag[6] == '1')
	Globals.score2=Globals.score2+1;

	else if (tag[6] == '2')
	Globals.score1=Globals.score1+1;

	else {
	Debug.Log("Error");
	return;
}
}	
 }

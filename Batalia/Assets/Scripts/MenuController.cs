using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : Photon.MonoBehaviour
{
   [SerializeField] private string Versioname = "0.1";
   [SerializeField] private InputField createroomname;
   [SerializeField] private InputField joinroomname;
   [SerializeField] private Text  mestext;

   [SerializeField] private string themap;
   
   private void Awake()
   {
      PhotonNetwork.ConnectUsingSettings(Versioname);
   }

   private void OnConnectedToMaster()
   {
      PhotonNetwork.JoinLobby(TypedLobby.Default);
      Debug.Log("Cinnected");
   }

   public void JoinGame()
   {
      Debug.Log("NICE");
      RoomOptions rmop = new RoomOptions();
      rmop.maxPlayers = 2;
      PhotonNetwork.JoinOrCreateRoom(joinroomname.text, rmop, TypedLobby.Default);
   }

   public void CreateGame()
   {
      PhotonNetwork.CreateRoom(createroomname.text, new RoomOptions() {maxPlayers = 2}, null);
   }

   private void OnJoinedRoom()
   {
      PhotonNetwork.LoadLevel(themap);
   }

   public void setMap(string map)
   {
      themap = map;
   }
   
}

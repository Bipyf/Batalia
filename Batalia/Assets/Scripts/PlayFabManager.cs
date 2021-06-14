using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayFabManager : MonoBehaviour
{
    public GameObject rowPrefab;
    public Text mestexxt;
    public Transform rowsParent;
    public Text messageText;
    public string savetext; 
    public InputField usernameInput;
    public InputField passwordInput;
    public void RegisterButton()
    {
        var request = new RegisterPlayFabUserRequest
        {
            Username = usernameInput.text,
            Password = passwordInput.text,
            RequireBothUsernameAndEmail = false

        };
        PlayFabClientAPI.RegisterPlayFabUser(request, OnRegSuccsess, OnError);
        
    }

    public void LoginButton()
    {
        var request = new LoginWithPlayFabRequest
        {
            Username = usernameInput.text,
            Password = passwordInput.text
        };
        PlayFabClientAPI.LoginWithPlayFab(request, Onloginsuccess, OnError);
    }

    void Onloginsuccess(LoginResult res)
    {
        Debug.Log("Logged IN!");
        Globals.username = usernameInput.text;
        SceneManager.LoadScene("_Menu");
    }
    
    void OnRegSuccsess(RegisterPlayFabUserResult res)
    {
        mestexxt.text = "Registered! Now press LOGIN!";
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Login()
    {
        var request = new LoginWithCustomIDRequest
        {
            CustomId = SystemInfo.deviceUniqueIdentifier,
            CreateAccount = true

        };
        PlayFabClientAPI.LoginWithCustomID(request, Onsuccess, OnError);
    }

    void Onsuccess(LoginResult result)
    {
        mestexxt.text = "Logged IN! Wait...";
        Debug.Log("Successful login");
        
    }

    void OnError(PlayFabError error)
    {
        mestexxt.text = "Error! Invalid Password or username!";
        Debug.Log("Error");
        Debug.Log(error.GenerateErrorReport());
    }

    public void SendLeaderboard()
    {
        var request = new UpdatePlayerStatisticsRequest
        {
            Statistics = new List<StatisticUpdate>
            {
                new StatisticUpdate
                {
                    StatisticName = "PlayerStatistics",
                    Value = Random.Range(1, 10)
                }
            }
        };
        PlayFabClientAPI.UpdatePlayerStatistics(request, OnLeaderboardUpdate, OnError);
    }

    void OnLeaderboardUpdate(UpdatePlayerStatisticsResult result)
    {
        Debug.Log("Success send");
    }

    public void GetLeaderBoard()
    {
        var request = new GetLeaderboardRequest
        {
            StatisticName = "PlayerStatistics",
            StartPosition = 0,
            MaxResultsCount = 3
        };
        PlayFabClientAPI.GetLeaderboard(request, OnLeaderboardGet, OnError);
    }

    void OnLeaderboardGet(GetLeaderboardResult result)
    {
        
        foreach (var item in result.Leaderboard)
        {
            GameObject newGo = Instantiate(rowPrefab, rowsParent);
            Text[] texts = newGo.GetComponentsInChildren<Text>();
            texts[0].text = item.Position.ToString();
            texts[1].text = item.PlayFabId;
            texts[2].text = item.StatValue.ToString();
            Debug.Log(item.Position + " " + item.PlayFabId + " " + item.StatValue);
        }
    }
}

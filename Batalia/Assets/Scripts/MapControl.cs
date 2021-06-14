using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapControl : MonoBehaviour
{
    public GameObject JoinCreate;

    public void Map1()
    {
        string map = "Map1";
        JoinCreate.GetComponent<MenuController>().setMap(map);
        JoinCreate.SetActive(true);
    }
    public void Map2()
    {
        string map = "Map2";
        JoinCreate.GetComponent<MenuController>().setMap(map);
        JoinCreate.SetActive(true);
    }
    
    public void Map3()
    {
        string map = "Map3";
        JoinCreate.GetComponent<MenuController>().setMap(map);
        JoinCreate.SetActive(true);
    }
}

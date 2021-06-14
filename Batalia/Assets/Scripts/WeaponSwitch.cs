using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitch : Photon.MonoBehaviour
{
    public GameObject gun;
    public GameObject mstick;

    public PhotonView ph;

    void Update()
    {
        if (ph.isMine)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                if (gun.activeInHierarchy == true)
                {
                    gun.SetActive(false);
                    mstick.SetActive(true);
                }
                else if (mstick.activeInHierarchy == true)
                {
                    mstick.SetActive(false);
                    gun.SetActive(true);
                }
            }
        }
    }
}

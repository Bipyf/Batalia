using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Luk : Photon.MonoBehaviour
{
    public float offset;
    public GameObject bullet;
    public Transform shotPoint;
    public PhotonView photonview;

    private float timeBtwShots;
    public float startTimeBtwShots;
    public GameObject shotSound;

    void Update()
    {
        if (photonView.isMine)
        {
            Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);

            if (timeBtwShots <= 0)
            {
                if (Input.GetMouseButton(0))
                {
                    PhotonNetwork.Instantiate(bullet.name, shotPoint.position, transform.rotation, 0);
                    PhotonNetwork.Instantiate(shotSound.name, transform.position, Quaternion.identity, 0);
                    timeBtwShots = startTimeBtwShots;
                }
            }
            else
            {
                timeBtwShots -= Time.deltaTime;
            }
        }
    }
}

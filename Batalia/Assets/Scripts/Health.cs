using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : Photon.MonoBehaviour
{
    public int health;
	public PhotonView ph;
    public int maxHealth;
	public GameObject gm;
	public CircleCollider2D bc;
	public SpriteRenderer sr;
	public GameObject luk;
	public GameObject mst;
	public GameObject PlayerCanvas;
	
	void Awake() {
	if (ph.isMine) {
	Gamerules.Instance.localPlayer = this.gameObject;
}
}
	
    public void TakeHit(int damage)
    {	
		string ttag = gameObject.tag;
        health -= damage; 
        if (health <= 0 && ph.isMine)
        {
			Gamerules.Instance.EnableRespawn();
            this.GetComponent<PhotonView>().RPC("Death", PhotonTargets.AllBuffered);
        }
    }
	[PunRPC]
	private void Death() {
	bc.enabled = false;
	sr.enabled = false;
	luk.GetComponent<SpriteRenderer>().enabled = false;
	mst.GetComponent<SpriteRenderer>().enabled = false;
}

[PunRPC]
	private void Respawn() {
	bc.enabled = true;
	sr.enabled = true;
	luk.GetComponent<SpriteRenderer>().enabled = true;
	mst.GetComponent<SpriteRenderer>().enabled = true;
	health = 100;
}

    public void SetHealth(int bonusHealth)
    {
		if (ph.isMine) {
        health += bonusHealth;
        if (health > maxHealth)
        {
            health = maxHealth;
        }
}
    }
    

}

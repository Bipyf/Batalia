using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHealth : MonoBehaviour
{
    
    
    public int collisionHealth = 20;
    public string collisionTag;
    private void OnCollisionEnter2D(Collision2D coll){
        if(coll.gameObject.tag=="Player1")
        {
            Health health = coll.gameObject.GetComponent<Health>();
            health.SetHealth(collisionHealth);
            Destroy(gameObject);
        }
        if(coll.gameObject.tag=="Player2")
        {
            Health health = coll.gameObject.GetComponent<Health>();
            health.SetHealth(collisionHealth);
            Destroy(gameObject);
        }
    }
    
    
}
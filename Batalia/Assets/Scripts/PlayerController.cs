using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerController : Photon.MonoBehaviour
{
    public SpriteRenderer sr;
    public PhotonView photonview;
    public int playerId = 0;
    public Animator animator;
    public Rigidbody2D rb;
    public GameObject Mycamera;

    private void Awake()
    {
        if (photonview.isMine)
        {
            Mycamera.SetActive(true);
        }
        else
        {
            Mycamera.SetActive(false);
        }
    }
    void Update()
    {
        if (photonview.isMine)
        {
            CheckInput();
            Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0.0f);
            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);
            animator.SetFloat("Magnitude", movement.magnitude);

            transform.position = transform.position + movement * Time.deltaTime;

            CheckInput();

            rb.velocity = new Vector2(movement.x, movement.y);
        }
    }
    private void CheckInput()
    {

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.W) ||
            Input.GetKeyDown(KeyCode.S))
        {
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }
    }
    
}


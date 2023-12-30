using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class PlayerController : MonoBehaviour
{
    public float jumpPower = 10.0f;
    private Rigidbody player;
    public bool onGround = true;
    public float gravityModifier = 2.0f;
    private Animator playerAnim;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public bool gameOver = false;
    private AudioSource playerAudio;
    public AudioClip jumpSound;
    public AudioClip crashSound;

    public Canvas gameOverLayer;
    void Start()
    {
        playerAudio = GetComponent<AudioSource>();
        playerAnim = GetComponent<Animator>();
        player = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            onGround = true;
            dirtParticle.Play();
        }

        else if(collision.gameObject.CompareTag("Obstacle"))
        {
            explosionParticle.Play();
            gameOver = true;
            playerAudio.PlayOneShot(crashSound, 1.0f);
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 2);
            dirtParticle.Stop();
            gameOverLayer.gameObject.SetActive(true);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(onGround && !gameOver && Input.GetKeyDown(KeyCode.Space))
        {
            onGround = false;
            player.AddForce(Vector3.up * jumpPower,ForceMode.Impulse);
            playerAudio.PlayOneShot(jumpSound, 1.0f);
            playerAnim.SetTrigger("Jump_trig");
            dirtParticle.Stop();
        }
    }
}

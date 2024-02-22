using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] GameManager gameManager;
    [SerializeField] private Animator anim;
    [SerializeField] private ParticleSystem explosionParticle;
    [SerializeField] private ParticleSystem dirtParticle;
    [SerializeField] private AudioClip jumpSound;
    [SerializeField] private AudioClip crashSound;
    [SerializeField] private AudioSource audioSrc;
    private float jumpForce = 12f;
    private bool grounded = true;
    private bool dead = false;

    // Start is called before the first frame update
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && grounded && !dead)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            grounded = false;
            anim.SetTrigger("Jump_trig");
            audioSrc.PlayOneShot(jumpSound);
            dirtParticle.Stop();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
            dirtParticle.Play();
        }
        else if (collision.gameObject.tag == "Obstacle")
        {
            explosionParticle.Play();
            audioSrc.PlayOneShot(crashSound);
            gameManager.EndGame();
            anim.SetBool("Death_b", true);
            anim.SetInteger("DeathType_int", 1);
            dead = true;
        }
    }

    public void Reset()
    {
        anim.SetBool("Death_b", false);
        anim.SetInteger("DeathType_int", 0); // not sure if needed
        dead = false;
        dirtParticle.Play();
        anim.Play("Alive", anim.GetLayerIndex("Alive"));
    }
}

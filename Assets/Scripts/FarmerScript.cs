using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmerScript : MonoBehaviour
{
    // Start is called before the first frame update
    private float animSpeed;

    private Animator animator;

    private Rigidbody rb;

    public float jump;

    private Master master;

    public GameObject explosionPS;
    void Start()
    {

        animSpeed = 6f;

        animator = GetComponent<Animator>();

        rb = GetComponent<Rigidbody>();

        animator.SetFloat("Speed_f", animSpeed);

        master = GameObject.Find("Master").GetComponent<Master>();

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && !master.gameOver){
            
            rb.AddForce(Vector3.up * jump, ForceMode.Impulse);
            animator.SetTrigger("Jump_trig");

        }
    }

    public void OnCollisionEnter(Collision colision){

        if(colision.gameObject.tag == "Barrera"){

            Debug.Log("Plonk, me golpié con uno barrero");

            master.gameOver=true;

            GameObject explosion = Instantiate(explosionPS, transform.position, Quaternion.identity);

            explosion.GetComponent<ParticleSystem>().Play();

            animator.SetBool("Death_b", true);

            animator.SetInteger("DeathType_int", 1);

            rb.velocity = Vector3.zero;

        }
    }
}

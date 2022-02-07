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
    void Start()
    {

        animSpeed = 6f;

        animator = GetComponent<Animator>();

        rb = GetComponent<Rigidbody>();

        animator.SetFloat("Speed_f", animSpeed);

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            
            rb.AddForce(Vector3.up * jump, ForceMode.Impulse);
            animator.SetTrigger("Jump_trig");

        }
    }
}

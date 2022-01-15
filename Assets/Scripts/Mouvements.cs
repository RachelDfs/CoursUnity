using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouvements : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        if(rb != null)
        {
            /*if (Input.GetButton("Z"))
                rb.AddForce(transform.forward * 30);

            if (Input.GetButton("S"))
                rb.AddForce(transform. * 30);

            if (Input.GetButton("D"))
                rb.AddTorque(transform. * 30);

            if (Input.GetButton("Q"))
                rb.AddTorque(transform. * 30);*/
        }

        Animator anim = GetComponent<Animator>();
        if(anim != null)
        {
            //anim.SetFloat("Speed", rb.velocity.magnitude);
        }
    }
}

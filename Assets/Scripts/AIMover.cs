using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMover : MonoBehaviour
{

    [Tooltip("Vitesse de déplacement"), Range(0, 15)]
    public float linearSpeed = 6;
    [Tooltip("Vitesse de rotation")]
    public float angularSpeed = 1;

    public Transform player;
    public float rangeAngle;
    // Start is called before the first frame update
    void Start()
    {
        GameObject goPlayer = GameObject.FindGameObjectWithTag("Player");
        player = goPlayer.transform;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            /*if (Input.GetButton("Fire1") && rb.velocity.magnitude < 6)
                rb.AddForce(transform.forward * 30);*/

            /*if (Input.GetButton("Fire2") && rb.angularVelocity.magnitude < 1)
                rb.AddTorque(transform.up * 30);*/

            /*if (Input.GetAxis("Horizontal") > 0)
             {
                 rb.AddForce(transform.forward * 30);
             }

             if (rb.angularVelocity.magnitude < angularSpeed)
             {
                 //Le fait tourner
                 rb.AddTorque(transform.up * 30);
             }*/
            Vector3 dir =(player.position - transform.position);
            float angle = Vector3.SignedAngle(transform.forward, dir.normalized,Vector3.up);
            if (Mathf.Abs(angle)<rangeAngle)
            {
                rb.AddForce(transform.forward * 30);
            }
            else
            {
                rb.velocity = new Vector3(0,rb.velocity.y,0);
                float sign = angle / Mathf.Abs(angle);
                rb.AddTorque(Vector3.up * sign * 1);
            }

            /*Animator anim = GetComponent<Animator>();
            if (anim != null)
            {
                anim.SetFloat("Speed", rb.velocity.magnitude);

            }*/


        }
    }
}
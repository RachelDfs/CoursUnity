using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Transform playerCam;
    [SerializeField] private float jumpforce;

    void OnApplicationFocus(bool hasFocus)
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Start is called before the first frame update
    void Start()
    {
        if (playerCam == null)
        {
            Camera cam = transform.GetComponentInChildren<Camera>();
            playerCam = cam.transform;
        }
    }
    public bool OnGrounded()
    {
        return Physics.CheckSphere(transform.position + Vector3.down * GetComponent<Collider>().bounds.extents.y, 0.1f, LayerMask.GetMask("Level"));
    }

    private void Update()
    {
        //Pour declock la souris
        if (Input.GetKey(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
        }

        Rigidbody rb = GetComponent<Rigidbody>();

        if (Input.GetKeyDown(KeyCode.Space) && OnGrounded())
        {
            rb.AddForce(Vector3.up * jumpforce);
        }

        //Sauve la rotation
        Quaternion lastRotation = playerCam.rotation;

        //Baisse / leve la tete
        float rot = Input.GetAxis("Mouse Y") * -10;
        Quaternion q = Quaternion.AngleAxis(rot, playerCam.right);
        playerCam.rotation = q * playerCam.rotation;

        //Est ce qu'on a la tete à l'envers ?
        Vector3 forwardCam = playerCam.forward;
        Vector3 forwardPlayer = transform.forward;
        float regardeDevant = Vector3.Dot(forwardCam, forwardPlayer);
        if (regardeDevant < 0.0f)
            playerCam.rotation = lastRotation;

        rot = Input.GetAxis("Mouse X") * 10;
        q = Quaternion.AngleAxis(rot, transform.up);
        transform.rotation = q * transform.rotation;


    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Rigidbody rb;
        rb = GetComponent<Rigidbody>();

        float vert = Input.GetAxis("Vertical");
        float hori = Input.GetAxis("Horizontal");

        rb.AddForce(vert * transform.forward * 30);
        rb.AddForce(hori * transform.right * 30);

        float rot = Input.GetAxis("Mouse X") * 10;
        rb.AddTorque(Vector3.up * rot);
    }
}

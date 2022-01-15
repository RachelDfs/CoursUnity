using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreamTrigger : MonoBehaviour
{

    public AudioSource scream1;
    public AudioSource scream2;
    public AudioSource scream3;
    // Start is called before the first frame update
    void Start()
    {

    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ball")
        {
            int indexRandom = Random.Range(1, 3);
            if (indexRandom == 1)
                scream1.Play();
            if (indexRandom == 2)
                scream2.Play();
            if (indexRandom == 3)
                scream3.Play();
        }

    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTxt : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.tag == "StartTxt")
            Destroy(gameObject, 10f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLancer : MonoBehaviour
{
    [Tooltip("prefab a spawn")]
    public Transform prefabAI;
    [Tooltip("point de spawn du projectile")]
    public Transform spawnPoint;



    // Start is called before the first frame update
    void Start()
    {

    }

    Transform SpawnBoulette()
    {
        //le game object spawn a chaque démarrage du jeu
        Transform boulette = GameObject.Instantiate<Transform>(prefabAI);
        //Prend la position de l'obG parent(transform.position) et la met sur le projectile
        boulette.position = spawnPoint.position;
        boulette.rotation = spawnPoint.rotation;

        return boulette;
    }

    void AddPichenette(Transform boulette, Vector3 pichenette)
    {
        Rigidbody rb = boulette.GetComponent<Rigidbody>();
        rb.AddForce(pichenette, ForceMode.Impulse);
    }

    public float time = 0;
    [Range(0, 15)]
    public float timeMax = 0;

    private Vector3 lastPichenette;

    // Update is called once per frame
    void Update() { 
    
            
        //Met un setting de temps
        time = time + Time.deltaTime;
        if (time >= timeMax && Input.GetMouseButtonDown(0))
        {
            Transform boulette = SpawnBoulette();
            AddPichenette(boulette, transform.forward * 400);

            time = 0;
        }
    }
}
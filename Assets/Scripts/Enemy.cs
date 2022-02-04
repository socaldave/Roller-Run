using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/**
   * Enemy Component for the enemy objects
   */
public class Enemy : MonoBehaviour
{
    private Level manager;


    // Start is called before the first frame update
    void Start()
    {
        manager = FindObjectOfType<Level>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.name == "Player")
        {
            manager.respawnPlayer();
        }
    }
}

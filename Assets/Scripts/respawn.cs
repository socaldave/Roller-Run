using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class respawn : MonoBehaviour
{
    private Level gm;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindObjectOfType<Level>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if(other.transform.gameObject.name == "Player")
        {
            gm.respawnPlayer();
        }
        else
        {
            Destroy(other.transform.gameObject);
        }
        
    }
}

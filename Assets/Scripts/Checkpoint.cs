using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private Level gm;
    public bool active;
    public bool alreadyCollected;
    

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindObjectOfType<Level>();
    }

    // Update is called once per frame
    void Update()
    {
        if (alreadyCollected)
        {
            Destroy(this.GetComponent<Checkpoint>());
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (active)
        {
            if(gm != null)
            {
               
                gm.onCollected(other.gameObject);
                
                Collect();
            }
        }
        
    }

    void Collect()
    {
        Transform thisTransform = gameObject.transform;
        Debug.Log(thisTransform.position);
        gm.addCheckPoint(gameObject.transform.position);
        Debug.Log(thisTransform.position);
        alreadyCollected = true;
    }
}

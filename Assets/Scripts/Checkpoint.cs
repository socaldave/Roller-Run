using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 /**
    *Checkpoint class used to save user position at specific locations.
    */
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



    //  if Active call onCollected on GameObjected
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

    //save position and pass to the game manager
    void Collect()
    {
        Transform thisTransform = gameObject.transform;
        Debug.Log(thisTransform.position);
        gm.addCheckPoint(gameObject.transform.position);
        Debug.Log(thisTransform.position);
        alreadyCollected = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/**
   * Follow player component for the camera to follow the player
   */
public class Follow_Player : MonoBehaviour
{
   
    public Transform player;

    //Camera offsets
    public float x;
    public float y;
    public float z;

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + new Vector3(x, y, z);
        
    }
    
}

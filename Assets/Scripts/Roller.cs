using System.Collections;
using System.Collections.Generic;
using UnityEngine;


  /**
   * Movement class. Uses physics to give the player rolling motion. 
   */
[RequireComponent(typeof(Rigidbody))]
public class Roller : MonoBehaviour
{
        //Force Variables 
        public float xForce = 0;
        public float zForce = 0;
        public float yForce = 0;

        //use this for initialization  
        void Start()
        {
        
        }
    //Update is called once per frame  
    private void Update()
    {
        float y = 0.0f;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            y = yForce;
        }
        GetComponent<Rigidbody>().AddForce(0, y, 0);
    }

    //x and y axis movement   
    void FixedUpdate()
        {
        //this is for x axis' movement  

        float x = 0.0f;
        if (Input.GetKey(KeyCode.A))
        {
            x = x - xForce;
        }

        if (Input.GetKey(KeyCode.D))
        {
            x = x + xForce;
        }

        //this is for z axis' movement  

        float z = 0.0f;
        if (Input.GetKey(KeyCode.S))
        {
            z = z - zForce;
        }

        if (Input.GetKey(KeyCode.W))
        {
            z = z + zForce;
        }
        //this is for z axis' movement  

      
        GetComponent<Rigidbody>().AddForce(x, 0, z);
        }
    

}



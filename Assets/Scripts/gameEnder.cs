using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class gameEnder : MonoBehaviour
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

    public void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Reached the end");
        gm.onGameOver();
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{

    //List of all collectables
    public List<GameObject> collectibles;
    
    //Player GameObject    
    private GameObject player;

    //MenuCanvas
    public GameObject Canvas;
    //Next Level Button
    public GameObject nextLevel;
    //Main Menu Button
    public GameObject mainMenu;

    //Current Level Number
    public int level;

    //List of projectile Launchers
    public List<GameObject> cannons;

    public List<Vector3> checkPoints;

    //Pause state
    public Boolean Paused;


    // Start is called before the first frame update
    void Start()
    {

        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //Pause Logic if user presses escape
        if (Input.GetKeyDown("escape"))
        {
            if (Paused == true)
            {
                Time.timeScale = 1.0f;
                nextLevel.gameObject.SetActive(false);
                mainMenu.gameObject.SetActive(false);
                Paused = false;
            }
            else
            {
                Time.timeScale = 0.0f;              
                mainMenu.gameObject.SetActive(true);
                Paused = true;
            }
        }

        //GameOverLogic
        if (collectibles[0] == null)
            onGameOver();
    }


    /**
    * Freeze all player motion and activate menu canvas
    */
    public void onGameOver()
    {
        
        player.GetComponent<Rigidbody>().isKinematic = true;
        mainMenu.SetActive(true);
        nextLevel.SetActive(true);

        if(cannons.Count != 0)
        {
            foreach(GameObject cannon in cannons)
            {
                CannonFire fire = cannon.GetComponent<CannonFire>();
                fire.fire = false;
            }
        }
        
    }

    public void onCollected(GameObject collectable) {

        
    }

    /**
    * Load Given Level
    */
    public void onLoadNextLevel(int level)
    {     
        SceneManager.LoadScene("Level " +level);
    }


    /**
    * Load Main Menu
    */
    public void onLoadMenu()
    {
        Debug.Log("loading main menu");
        SceneManager.LoadScene("MainMenu");
    }

    /**
    * Respawn player at spawn if no checkpoints are stored or spawn at last checkpoint
    */
    public void respawnPlayer()
    {
        player.GetComponent<Rigidbody>().isKinematic = true;

        if(checkPoints.Count != 0)
        {
            Debug.Log("Checkpoint count not 0");
            player.transform.position = checkPoints[checkPoints.Count - 1];
        }           
        else
        {
            Debug.Log("Checkpoint count equal to  0");
            player.transform.position = new Vector3(0, 0, 0);
        }    
            

        player.GetComponent<Rigidbody>().isKinematic = false;
    }

    /**
    * Add Checkpoint to Checkpoints 
    */
    public void addCheckPoint(Vector3 checkpoint)
    {
        Debug.Log("GameManager  " + checkpoint);
        checkPoints.Add(checkpoint);
    }
}

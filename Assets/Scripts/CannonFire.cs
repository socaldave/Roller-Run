using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonFire : MonoBehaviour
{

    public GameObject projectileSpawnPoint;
    public GameObject projectile;
    public float launchVelocity = 700f;
   

    private float time = 0.0f;
    public float fireRate = 1.5f;

    public bool fire;

    // Start is called before the first frame update
    void Start()
    {
        
    }


    /**
    * Fire a ball at set intercval 
    */
    void Update()
    {
        time += Time.deltaTime;

        if (time >= fireRate)
        {
            if (fire)
            {
                time = 0.0f;
                FireBall();
            }
            return;
            // execute block of code here
        }
    }

    /**
    * Instantiate cannonball and fire using physics force
    */
    void FireBall()
    {
        GameObject ball = Instantiate(projectile, projectileSpawnPoint.transform.position,
                                                     projectileSpawnPoint.transform.rotation);
        ball.transform.localScale = transform.localScale;

        ball.GetComponent<Rigidbody>().AddRelativeForce(new Vector3
                                             (0, launchVelocity, -9.8f));
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraBall : BasePowerUp //MonoBehaviour
{
    //BallPrefab instantiated when the powerup is picked up
    public GameObject BallPrefab;

    //Make the min and max speed to be configurable in the editor
    public float MinSpeed = 10;
    public float MaxSpeed = 20;

    //To prevent the ball from keep bouncing horizontally we enforce a minimum vertical movement
    public float MinVerticalMovement = 0.5F;

    //Override of the OnPickup method of the base class
    protected override void OnPickup()
    {
        //Call the default behaviour of the base class first
        base.OnPickup();
        print("On pickup Call!");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("Extra Collision");

        if (collision.gameObject.tag == "Paddle")
        {
            print("Extra Collision Paddle");
            launchBall();
        }
    }

    public void launchBall()
    {
        //Get current speed and direction
        Vector2 direction = GetComponent<Rigidbody2D>().velocity;
        //float speed = 20f;
        float speed = direction.magnitude;
        direction.Normalize();

        //Make sure the ball never goes straight horizontal else it could never come down to the paddle.
        if (direction.x > -MinVerticalMovement && direction.x < MinVerticalMovement)
        {
            //Adjust the x, make sure it goes in a direction within the range limit set
            direction.x = direction.x < 0 ? -MinVerticalMovement : MinVerticalMovement;

            //Adjust the y, make sure it keeps going into the direction it was going (up or down)
            direction.y = direction.y < 0 ? -1 + MinVerticalMovement : 1 - MinVerticalMovement;

            //Apply it back to the ball
            GetComponent<Rigidbody2D>().velocity = direction * speed;
        }
        if (speed < MinSpeed || speed > MaxSpeed)
        {
            //Limit the speed so it always above min en below max
            speed = Mathf.Clamp(speed, MinSpeed, MaxSpeed);

            //Apply the limit
            //Note that we dont use * Time.deltaTime here since we set the velocity once, not every frame.
            GetComponent<Rigidbody2D>().velocity = direction * speed;
        }
    }
}

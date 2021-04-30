using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePaddleSize : BasePowerUp //MonoBehaviour
{
    //How much units should the paddle change when this powerup is picked up?
    //Can also be negative to shrink the paddle!
    public Vector3 SizeIncrease = Vector3.zero;

    public Vector3 MinPaddleSize = new Vector3(0.1F, 0.1F, 0.4F);

    //Notice how we override the OnPickup method of the base class
    protected override void OnPickup()
    {
        //Call the default behaviour of the base class first
        base.OnPickup();

        //Then do the powerup specific behaviour, changing the size in this case
        Paddle p = FindObjectOfType(typeof(Paddle)) as Paddle;
        p.transform.localScale += SizeIncrease;

        //Limit the minimal size of the paddle
        Vector3 size = p.transform.localScale;
        if (size.x < MinPaddleSize.x)
        {
            size.x = MinPaddleSize.x;
        }
        if (size.y < MinPaddleSize.y)
        {
            size.y = MinPaddleSize.y;
        }
        if (size.z < MinPaddleSize.z)
        {
            size.z = MinPaddleSize.z;
        }

        p.transform.localScale = size;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

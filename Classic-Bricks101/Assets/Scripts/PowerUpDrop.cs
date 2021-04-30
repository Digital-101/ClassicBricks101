using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]

public class PowerUpDrop : MonoBehaviour
{
    public BasePowerUp PowerUpPrefab;

    //OnCollision create the powerup
    private void OnCollisionEnter2D(Collision2D c)
    {
        GameObject.Instantiate(PowerUpPrefab, this.transform.position, Quaternion.identity);
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

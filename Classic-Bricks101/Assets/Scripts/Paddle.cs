using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Paddle : MonoBehaviour
{
    public int i = 0;

    public AudioClip Sound;

    // Start is called before the first frame update
    void Start()
    {
        print("First Arcade Game");
    }

    // Update is called once per frame
    void Update()
    {
        //print(Input.mousePosition);

        ////Set variable for current position
        Vector3 paddlePos = new Vector3(8f, this.transform.position.y, 0f);

        ////Get mouse position
        float mousePos = Input.mousePosition.x / Screen.width * 16;

        ////Set new mouse X position
        paddlePos.x = Mathf.Clamp(mousePos-7, -7f, 7f);

        ////Change paddle to match new X position
        this.transform.position = paddlePos;
    }

    //OnCollisionEnter will only be called when one of the colliders has a rigidbody
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Change the sound pitch if a slowdown powerup has been picked up
        GetComponent<AudioSource>().pitch = Time.timeScale;

        //Play it once for this collision hit
        GetComponent<AudioSource>().PlayOneShot(Sound);
    }
}

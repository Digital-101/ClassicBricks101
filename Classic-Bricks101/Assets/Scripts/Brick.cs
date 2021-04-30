using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Make sure an AudioSource component on the GameObject where the script is added
[RequireComponent(typeof(AudioSource), typeof(Animation))]

public class Brick : MonoBehaviour
{
    public int maxHits;
    public int timeHit;
    private bool BrickIsDestroyed = false;

    //Define the AudioClip and Pitch
    public AudioClip Sound;
    public float PitchStep = 0.05f;
    public float MaxPitch = 1.3f;

    //Make the current pitch value global
    public static float pitch = 1;

    //Falling variables
    public bool FallDown = false;

    [HideInInspector]
    public bool BlockIsDestroyed = false;

    private Vector2 velocity = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
        timeHit = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (FallDown && velocity != Vector2.zero)
        {
            Vector2 pos = (Vector2)transform.position;
            pos += velocity * Time.deltaTime;
        }
    }

    private void OnBecameInvisible()
    {
        BlockIsDestroyed = true;
        Destroy(gameObject);
    }

    private IEnumerator OnCollisionExit2D(Collision2D c)
    {
        if (timeHit == maxHits)
        {
            print("Destroyed on Exit!");

            print("Play Woggle!");
            GetComponent<Collider2D>().enabled = false;

            //Play the Woggle animation
            GetComponent<Animation>().Play();

            //Wait here for the length of the Woggle animation
            //yield return new WaitForSeconds(GetComponent<Animation>()["Woggle"].length);
            yield return new WaitForSeconds(0);

            //Animation Woggle has finished, now decide what to do, falldown or just dissappear
            if (FallDown)
            {
                print("Falling");
                //Falldown to the direction the ball hit it, with a random speed and plus a little downwards "gravity"
                velocity = new Vector2(0, Random.Range(1, 12.0F) * -1);
            }
            else
            {
                GetComponent<Renderer>().enabled = false;
            }
            Destroy(gameObject);
        }
        else
        {
            print("Max hits not reached");
        }
        //return;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        timeHit++;
        print("Ouch you hit me this many times: "+timeHit);

        print("Playing brick sound!");
        //Increase pitch
        pitch += PitchStep;

        //Limit pitch
        if (pitch > MaxPitch)
        {
            pitch = 1; //Reset pitch to one so it starts over with the lower tone
        }

        //Apply pitch
        GetComponent<AudioSource>().pitch = pitch;

        //Play it once for this collision hit
        GetComponent<AudioSource>().PlayOneShot(Sound);

        StartCoroutine(OnCollisionExit2D(collision));

        //if (timeHit == maxHits)
        //{
        //    print("Destroyed");
        //    Destroy(gameObject);
        //}
    }
}

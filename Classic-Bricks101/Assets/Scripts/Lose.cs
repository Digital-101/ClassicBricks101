using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lose : MonoBehaviour
{
    private Ball ball;
    private GameManager gameManager;
    public GameObject[] players;
    public GameObject[] extras;

    IEnumerator Pause()
    {
        print("Before Waiting 2 seconds");
        //Switch GameManager State
        gameManager = GameObject.FindObjectOfType<GameManager>();
        gameManager.SwitchState(GameState.Failed);
        gameManager.ChangeText("You Lose :(");

        //enable the restart and main menu buttons
        gameManager.EnableButtons();

        yield return new WaitForSeconds(2);

        //Find the ball and reset game start
        //ball = GameObject.FindObjectOfType<Ball>();
        //ball.gameStarted = false;

        //Reload level
        //Application.LoadLevel(Application.loadedLevel);

        print("After Waiting 2 Seconds");
    }

    private void OnTriggerEnter2D(Collider2D trigger)
    {
        if (trigger.name == "ball")
        {
            print("Lost Triggered!");

            //Wait before restarting level
            StartCoroutine(Pause());
        }
       
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

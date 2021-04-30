using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    public GameObject quitButton;

    //Basic function for loading level
    public void LoadScene(int level)
    {
        Application.LoadLevel(level);
    }

    public void QuitGame()
    {
        if (Application.isEditor)
        {
            Debug.Log("Attempted to quit from the Editor.");
        }
        else if (Application.platform == RuntimePlatform.WebGLPlayer)
        {
            quitButton = GameObject.FindGameObjectWithTag("Quit");
            quitButton.SetActive(false);
            Debug.Log("Attempted to quit from the WebGL Player");
        }
        else
        {
            //For other platforms
            Application.Quit();
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

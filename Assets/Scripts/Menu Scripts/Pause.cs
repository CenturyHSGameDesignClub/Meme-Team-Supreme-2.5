using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour
{
    bool paused = false;


    void Update()
    {
        if (Input.GetKeyDown("p"))
        {
            gamePaused();
        }
    }

    void OnGUI()
    {
        if (paused == true)
        {
            GUILayout.Label("Game is Paused!");
            if (GUILayout.Button("Click me to unpause"))
            {
                gamePaused();
            }
        }
    }

    void gamePaused()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
            paused = true;
        }

        else
        {
            Time.timeScale = 1;
            paused = false;
        }
    }
}

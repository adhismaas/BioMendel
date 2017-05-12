using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMenuBehavior : MonoBehaviour {
    public void triggerLevelMenuBehavior(int i)
    {
        switch (i)
        {
            default:

            case (1):
                SceneManager.LoadScene("Level");
                break;

            case(2):
                SceneManager.LoadScene("Level2");
                break;

            case (3):
                SceneManager.LoadScene("Level3");
                break;

            case (4):
                SceneManager.LoadScene("Level4");
                break;

            case (5):
                SceneManager.LoadScene("Level5");
                break;

            case (6):
                SceneManager.LoadScene("Level6");
                break;

            case (0):
                Application.Quit();
                break;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) { SceneManager.LoadScene("Main Menu"); }
    }
}

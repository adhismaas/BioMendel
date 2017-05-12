using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuBehavior : MonoBehaviour
{
    public void triggerMenuBehavior(int i)
    {
        switch (i)
        {
            default:

            case (1):
                SceneManager.LoadScene("AR_Scene");
                break;

            case (2):
                SceneManager.LoadScene("Screen Level");
                break;

            case (0):
                Application.Quit();
                break;
        }
    }

    void Updae()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) { SceneManager.LoadScene("Screen Level"); }
    }
}
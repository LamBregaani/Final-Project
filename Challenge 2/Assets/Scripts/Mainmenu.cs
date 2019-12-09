using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mainmenu : MonoBehaviour
{
    public void OnePlayer()
    {
        SceneManager.LoadScene("One player");
    }

    public void Hard()
    {
        SceneManager.LoadScene("Hard Mode");
    }

    public void Hardcore()
    {
        SceneManager.LoadScene("Hardcore Mode");
    }

    public void QuitGame ()

    {
        Application.Quit();
    }

}


﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pausemenu : MonoBehaviour
{
    public static bool gameIsPaused = false;

    public GameObject pauseMenuUI;


    void Update()
    {
        if (Input.GetKey("escape"))
        {
            if (gameIsPaused)
            {
                pauseMenuUI.SetActive(false);
                Time.timeScale = 1f;
                gameIsPaused = false;
            }

            else
            {
                pauseMenuUI.SetActive(true);
                Time.timeScale = 0f;
                gameIsPaused = true;
            }
        }
    }
    

}



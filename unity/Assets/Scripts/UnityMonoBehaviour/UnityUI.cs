﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UnityUI : MonoBehaviour
{
    public void exitGame()
    {
        SceneManager.LoadScene("titlescreen");
    }
}
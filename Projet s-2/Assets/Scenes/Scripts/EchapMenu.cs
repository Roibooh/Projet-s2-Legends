﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EchapMenu : MonoBehaviour
{

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !transform.GetChild(0).gameObject.activeSelf)
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }
        else if(Input.GetKeyDown(KeyCode.Escape))
        {
            transform.GetChild(0).gameObject.SetActive(false);
        }
    }
    public void RetourMenu(int i)
    {
        SceneManager.LoadScene(0);
    }
}

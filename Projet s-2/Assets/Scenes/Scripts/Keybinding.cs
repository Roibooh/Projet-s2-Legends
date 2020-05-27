using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

public class Keybinding : MonoBehaviour
{
    public int joueur = 1;
    private Transform menu;
    private Text text;
    private Event keyEvent;
    private string newKey;
    private bool waitingKey;
    private string[] listp;
    private int keynum;
    // Start is called before the first frame update
    void OnEnable()
    {
        menu = transform;
        waitingKey = false;
        if (joueur == 1)
        {
            listp = Personnages.Personnages.perso1.keys;
        }
        else
        {
            listp = Personnages.Personnages.perso2.keys;
        }
        for (int i = 2; i < 9; i++)
        {
            menu.GetChild(i).GetComponentInChildren<Text>().text = listp[i - 2];
        }
    }

    // Update is called once per frame

    private void OnGUI()
    {
        keyEvent = Event.current;
        if (keyEvent.isKey && waitingKey )
        {
            newKey = keyEvent.keyCode.ToString().ToLower();
            waitingKey = false;
        }
    }

    public void sendName(Text sendedText)
    {
        text = sendedText;
    }
    public void setJoueur(int joueur)
    {
        this.joueur = joueur;
    }
    
    public void changeTouche(int keynumb)
    {
        waitingKey = true;
        this.keynum = keynumb;
    }

    private void FixedUpdate()
    {
        if (newKey != "" )
        {
            listp[keynum] = newKey;
            text.text = listp[keynum];
            newKey = "";
        }
    }
}

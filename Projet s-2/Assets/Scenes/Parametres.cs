﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class Parametres : MonoBehaviour
{
    public AudioMixer audioMixer;
    public void SetVolume(float num)
    {
        audioMixer.SetFloat("volume",num);
    }
}

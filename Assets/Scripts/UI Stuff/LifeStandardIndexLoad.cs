﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LifeStandardIndexLoad : MonoBehaviour
{
    private Text textBox;

    private void Start()
    {
        textBox = this.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        textBox.text = "Living Standard Index: " + Mathf.Round(GameManager.livingStandIndex);

    }
}

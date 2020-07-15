using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnNumberLoad : MonoBehaviour
{
    private Text textBox;

    private void Start()
    {
        textBox = this.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        textBox.text = "Turn: " + TurnCounter.turnNumber;


    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScoreLoad : MonoBehaviour
{
    private Text textBox;

    private void Start()
    {
        textBox = this.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        textBox.text = "Evilness: " + Mathf.Round(GameManager.evilScore);

    }

}

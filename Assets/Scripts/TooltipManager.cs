using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TooltipManager : MonoBehaviour
{

    public GameObject tooltipBox;

    public Text textBox;

    private void Start()
    {

        textBox = tooltipBox.GetComponentInChildren<Text>();

    }


}

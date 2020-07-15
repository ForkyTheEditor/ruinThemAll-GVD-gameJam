using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MachineIntegration : MonoBehaviour
{

    public bool bought;
    public Machines thisMachine;

    private TooltipManager tooltipManager;

    private bool nextTurn = false;
    private int lastTurn;

    private int turnsLeft;

    public BoardOccupied tileToOccupy;
    

    private void Start()
    {

        tooltipManager = GameObject.FindGameObjectWithTag("UIManager").GetComponent<TooltipManager>();
        turnsLeft = thisMachine.duration;
    }

    private void LateUpdate()
    {

        if (TurnCounter.turnNumber > lastTurn )
        {
            nextTurn = true;
            lastTurn = TurnCounter.turnNumber;
        }

        if (nextTurn)
        {
            //aici scazi indexurile in fiecare tura
            if (bought == true)
            {
                GameManager.equalityIndex -= thisMachine.equalityIndex;
                GameManager.educationIndex -= thisMachine.educationIndex;
                GameManager.healthcareIndex -= thisMachine.healthcareIndex;
                GameManager.livingStandIndex -= thisMachine.livingStandardIndex;
                GameManager.playerMoney += thisMachine.bonusMoney;


                turnsLeft--;
            }


            nextTurn = false;

            if (turnsLeft <= 0)
            {
                tileToOccupy.occupied = false;
                
                Destroy(this.gameObject);
            }

        }

    }

    private void OnMouseEnter()
    {

        tooltipManager.textBox.text = thisMachine.machineName +  "\nCost: " + thisMachine.cost + "\nDuration: " + thisMachine.duration + "\nBonus money: " + thisMachine.bonusMoney + "\n Inequality: " + thisMachine.equalityIndex + "\n Stupidity: " + thisMachine.educationIndex + "\n Disease: " + thisMachine.healthcareIndex
                                        + "\n Life-crapping: " + thisMachine.livingStandardIndex ;
        tooltipManager.tooltipBox.SetActive(true);

        
    }

    private void OnMouseExit()
    {

        tooltipManager.tooltipBox.SetActive(false);
        
    }

}

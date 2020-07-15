using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnCounter : MonoBehaviour
{

    public static int turnNumber;

    private int turnCost = 1;

    public void NextTurn()
    {

        if(GameManager.playerMoney >= turnCost)
        {
            GameManager.playerMoney -= turnCost;
            turnNumber++;
        }
        
        

    }


}

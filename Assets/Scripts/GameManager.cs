using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static int playerMoney;
    public static float evilScore;

    public static bool gameOver = false;

    [SerializeField]
    private GameObject winText;

    [SerializeField]
    private GameObject pauseMenu;

    private bool pauseActive = false;

    [SerializeField]
    private int baseEvil;
    
    public static float equalityIndex;
    public static float educationIndex;
    public static float healthcareIndex;
    public static float livingStandIndex;

    private void Start()
    {

        playerMoney = 25;

        equalityIndex = Random.Range((int)185, (int)220);
        educationIndex = Random.Range((int)185, (int)225);
        healthcareIndex = Random.Range((int)185, (int)230);
        livingStandIndex = Random.Range((int)180, (int)220);


    }

    private void Update()
    {
        evilScore = baseEvil / ((equalityIndex + educationIndex + healthcareIndex + livingStandIndex) / 100);


        playerMoney = Mathf.Clamp(playerMoney, 0, 2500);
        equalityIndex = Mathf.Clamp(equalityIndex, 1, 1000);
        educationIndex = Mathf.Clamp(educationIndex, 1, 1000);
        healthcareIndex = Mathf.Clamp(healthcareIndex, 1, 1000);
        livingStandIndex = Mathf.Clamp(livingStandIndex, 1, 1000);

        if (evilScore >= 150)
        {

            gameOver = true;

        }

        if(gameOver == true)
        {
            winText.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseActive = !pauseActive;
            pauseMenu.SetActive(pauseActive);
        }


    }

    
}

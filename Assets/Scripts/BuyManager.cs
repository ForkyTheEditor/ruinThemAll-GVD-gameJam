using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyManager : MonoBehaviour
{

    public static GameObject selectedUpgrade;

    public Material defaultMat;
    public Material selectedMat;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hitinfo;

            if (selectedUpgrade != null)
            {
                selectedUpgrade.GetComponent<MeshRenderer>().material = defaultMat;
            }
            selectedUpgrade = null;


            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitinfo, Mathf.Infinity))
            {
                
                if (hitinfo.collider.GetComponent<MachineIntegration>() != null && hitinfo.collider.GetComponent<MachineIntegration>().bought == false)
                {

                    hitinfo.collider.GetComponent<MeshRenderer>().material = selectedMat;
                    selectedUpgrade = hitinfo.collider.gameObject;

                    if (BoardSelector.selectedTile != null && BoardSelector.selectedTile.GetComponent<BoardOccupied>().occupied == false)
                    {
                        Buy();
                    }

                    
                }
            }
        }

    }

    bool Buy()
    {
        MachineIntegration mi = selectedUpgrade.GetComponent<MachineIntegration>();

        if (GameManager.playerMoney >= mi.thisMachine.cost)
        {
            GameManager.playerMoney -= mi.thisMachine.cost;

            mi.bought = true;
            selectedUpgrade.transform.position = BoardSelector.selectedTile.transform.position;
            selectedUpgrade.GetComponent<MeshRenderer>().material = defaultMat;
            mi.tileToOccupy = BoardSelector.selectedTile.GetComponent<BoardOccupied>();

            audioSource.Play();

            BoardSelector.selectedTile.GetComponent<BoardOccupied>().occupied = true;

            return true;
        }
        else
        {
            return false;
        }
        
    }
}

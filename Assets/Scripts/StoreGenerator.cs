using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreGenerator : MonoBehaviour
{
    [SerializeField]
    private GameObject machinePrefab;
    [SerializeField]
    private Transform[] spawnLocations;
    [SerializeField]
    private Vector3 offset;

    private Machines[] allMachines;

    private int lastTurn;
    private bool nextTurn;

    // Start is called before the first frame update
    void Start()
    {
        allMachines = Resources.LoadAll<Machines>("StockMachines");

        if(allMachines != null && spawnLocations != null)
        {
            foreach(Transform t in spawnLocations)
            {

                GameObject go = Instantiate(machinePrefab, t.position + offset, t.rotation);
                go.GetComponent<MachineIntegration>().thisMachine = allMachines[Random.Range(0, allMachines.Length)];
                
            }
        }
        

    }

    // Update is called once per frame
    void Update()
    {
        if(TurnCounter.turnNumber > lastTurn)
        {

            nextTurn = true;
            lastTurn = TurnCounter.turnNumber;

        }

        if (nextTurn)
        {
            GameObject[] toDestroy = GameObject.FindGameObjectsWithTag("Machine");
            foreach(GameObject g in toDestroy)
            {
                if(g.GetComponent<MachineIntegration>().bought == false)
                {
                    Destroy(g);
                }
            }

            if (allMachines != null && spawnLocations != null)
            {
                foreach (Transform t in spawnLocations)
                {

                    GameObject go = Instantiate(machinePrefab, t.position + offset, t.rotation);
                    go.GetComponent<MachineIntegration>().thisMachine = allMachines[Random.Range(0, allMachines.Length)];

                }
            }

            nextTurn = false;

        }


    }
}

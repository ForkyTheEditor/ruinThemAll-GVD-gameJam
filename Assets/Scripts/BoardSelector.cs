using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardSelector : MonoBehaviour
{
    public static GameObject selectedTile;
    [SerializeField]
    private List<GameObject> tiles;


    [SerializeField]
    private Material defaultMaterial;
    [SerializeField]
    private Material selectedMaterial;

    // Update is called once per frame
    void LateUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hitInfo;

            if (selectedTile != null)
            {
                selectedTile.GetComponent<MeshRenderer>().material = defaultMaterial;
            }
            selectedTile = null;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo, Mathf.Infinity))
            {
                if (tiles.Contains(hitInfo.collider.gameObject) && hitInfo.collider.GetComponent<BoardOccupied>().occupied == false)
                { 

                    hitInfo.collider.GetComponent<MeshRenderer>().material = selectedMaterial;
                    selectedTile = hitInfo.collider.gameObject;
                    
                }
            }

        }


    }
}

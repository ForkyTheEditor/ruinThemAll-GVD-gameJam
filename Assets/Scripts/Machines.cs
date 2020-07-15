using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Machine", menuName = "Machine")]
public class Machines : ScriptableObject
{

    public string machineName;

    public MeshRenderer meshRend;
    public MeshFilter meshFilt;

    public int duration = 1;

    public int cost;
    public int bonusMoney;



    public float equalityIndex;
    public float educationIndex;
    public float healthcareIndex;
    public float livingStandardIndex;


}

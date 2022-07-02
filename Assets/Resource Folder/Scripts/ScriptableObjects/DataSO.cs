using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DataSO", menuName = "SO/DataSO")]
public class DataSO : ScriptableObject
{
    //Static Data
    [SerializeField] private int _level;
    [SerializeField] private int _coin;
    //New Data
    
    public int Level => _level;

    public int Coin => _coin;
    
}

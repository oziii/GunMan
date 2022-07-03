using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AmmoSO", menuName = "SO/AmmoSO")]
public class AmmoSO : ScriptableObject
{
    [SerializeField] private float _firePower;

    public float FirePower => _firePower;
} 

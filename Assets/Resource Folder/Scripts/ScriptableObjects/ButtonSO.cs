using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "ButtonSO", menuName = "SO/ButtonSO")]
public class ButtonSO : ScriptableObject
{
    [SerializeField] private int _maxSpecialPower;

    public int MAXSpecialPower => _maxSpecialPower;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "ButtonSO", menuName = "SO/ButtonSO")]
public class ButtonSO : ScriptableObject
{
    [SerializeField] private int _maxSpecialPower;
    [SerializeField] private Color _buttonSelectedColor;
    [SerializeField] private Color _buttonUnselectedColor;
    public int MAXSpecialPower => _maxSpecialPower;

    public Color ButtonSelectedColor => _buttonSelectedColor;

    public Color ButtonUnselectedColor => _buttonUnselectedColor;
}

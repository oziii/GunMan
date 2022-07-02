using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterSO", menuName = "SO/CharacterSO")]
public class CharacterSO : ScriptableObject
{
    [SerializeField] private float _verticalSpeed;
    [SerializeField] private float _horizontalSensitivity;
    [SerializeField] private float _playerHorizontalClamp;
    
    public float VerticalSpeed => _verticalSpeed;

    public float HorizontalSensitivity => _horizontalSensitivity;

    public float PlayerHorizontalClamp => _playerHorizontalClamp;
}

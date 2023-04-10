using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "_Coin", menuName = "Bonus/Coin", order = 51)]
public class BonusData : ScriptableObject
{
    [SerializeField] private string _name;
    public string Name => _name;

    [SerializeField] public int score;
    public int Score => score;

    [Tooltip("Bonus Sprite")]
    [SerializeField] private Sprite _bonusSprite;
    public Sprite BonusSprite
    {
        get { return _bonusSprite; }
        protected set { }
    }
}

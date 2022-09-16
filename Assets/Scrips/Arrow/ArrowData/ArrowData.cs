using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ArrowData", menuName = "ScriptableObjects/ArrowData", order = 1)]
public class ArrowData : ScriptableObject
{
    public DIRECTION direction;
    public float minAngle;
    public float maxAngle;
    public Sprite photoSprite;
    public string animationString;
}

public enum DIRECTION
{
    LEFT,
    RIGHT,
    UP,
    DOWN
}
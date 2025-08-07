using System;
using UnityEngine;

[Serializable]
public struct BallElement
{
    public Sprite sprite;
    public string name;
}

[CreateAssetMenu(fileName = "BallsConfig", menuName = "Config/Balls Config")]
public class BallsConfig : ScriptableObject
{
    [SerializeField] private BallElement[] _elements;

    public BallElement[] Elements => _elements;
}

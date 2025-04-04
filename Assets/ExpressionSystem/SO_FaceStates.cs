using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FaceStates", menuName = "Scriptable Objects/FaceStates")]
public class SO_FaceStates : ScriptableObject
{

    public enum BasicStates
    {
        Scared,
        Mad,
        Kawaii,
        Dead,
        Bored,
        Shy,
        Dumb,
        Tired,
        Shocked
    }

    public enum Audio
    {
        Pain,
        BigPain,
        Pleasure,
        Drowning
    }
}

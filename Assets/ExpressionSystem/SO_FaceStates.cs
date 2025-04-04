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

    public enum AnimationEffect
    {
        NoTransform,
        ScaleVertical,
        ScaleHorizontal,
        Shake,
    }
}

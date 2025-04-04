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

    public enum AudioStates
    {
        Pain,
        BigPain,
        Pleasure,
        Drowning,
        Surprise,
        Scared,
        Cute
    }

    public enum Items
    {
        Tomato,
        Potato,
        Carrot,
        Egg,
        Steak
    }

    public enum AnimationEffect
    {
        NoTransform,
        ScaleVertical,
        ScaleHorizontal,
        Shake,
    }
}

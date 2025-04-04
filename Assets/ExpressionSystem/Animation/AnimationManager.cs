using UnityEngine;
using System;
using System.Collections.Generic;
using UnityEngine.Animations;

public class AnimationManager : MonoBehaviour
{
    [SerializeField] private List<AnimationClip> AnimationClipsList;

    public void AnimationCommand(SO_FaceStates.AnimationEffect animationIndex)
    {
        SelectMouthAnimation(animationIndex);
        SelectEyesAnimation(animationIndex);
    }

    private void SelectMouthAnimation(SO_FaceStates.AnimationEffect animationEffect)
    {
        int animationIndex = Array.IndexOf(Enum.GetValues(typeof(SO_FaceStates.AnimationEffect)), animationEffect);

        GameObject.Find("Mouth").GetComponent<Animator>().Play((AnimationClipsList[animationIndex]).ToString());

    }
    private void SelectEyesAnimation(SO_FaceStates.AnimationEffect animationEffect)
    {
        int animationIndex = Array.IndexOf(Enum.GetValues(typeof(SO_FaceStates.AnimationEffect)), animationEffect);

        GameObject.Find("Eyes").GetComponent<Animator>().Play((AnimationClipsList[animationIndex]).ToString());

    }

}
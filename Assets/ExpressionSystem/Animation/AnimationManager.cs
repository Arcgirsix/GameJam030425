using UnityEngine;
using System;
using System.Collections.Generic;
using UnityEngine.Animations;

public class AnimationManager : MonoBehaviour
{
    [SerializeField] private List<AnimationClip> AnimationClipsList;

    public void AnimationCommand(SO_FaceStates.AnimationEffect animationIndex)
    {
        SelectAnimation(animationIndex);
    }

    private void SelectAnimation(SO_FaceStates.AnimationEffect animationEffect)
    {
        int animationIndex = Array.IndexOf(Enum.GetValues(typeof(SO_FaceStates.AnimationEffect)), animationEffect);

        GameObject.Find("Mouth").GetComponent<Animator>().Play((AnimationClipsList[animationIndex]).ToString());
    }

    private void StopAnimation(SO_FaceStates.AnimationEffect animationEffect)
    {
        int animationIndex = Array.IndexOf(Enum.GetValues(typeof(SO_FaceStates.AnimationEffect)), animationEffect);

        //GameObject.Find("Mouth").GetComponent<Animator>().;

    }

}
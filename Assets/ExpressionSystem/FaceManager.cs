using System;
using System.Collections.Generic;
using UnityEngine;

public class FaceManager : MonoBehaviour
{
    [SerializeField] private List<Sprite> eyes;
    [SerializeField] private List<Sprite> mouths;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            StateCommand(SO_FaceStates.BasicStates.Scared);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            StateCommand(SO_FaceStates.BasicStates.Mad);
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            StateCommand(SO_FaceStates.BasicStates.Kawaii);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            StateCommand(SO_FaceStates.BasicStates.Dead);
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            StateCommand(SO_FaceStates.BasicStates.Bored);
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            StateCommand(SO_FaceStates.BasicStates.Shy);
        }

    }

    public void StateCommand(SO_FaceStates.BasicStates stateIndex)
    {
        SelectEyes(stateIndex);
        SelectMouths(stateIndex);

    }

    private void SelectEyes(SO_FaceStates.BasicStates eyeState)
    {
        int eyeIndex = Array.IndexOf(Enum.GetValues(typeof(SO_FaceStates.BasicStates)), eyeState);

        GameObject.Find("Eyes").GetComponent<SpriteRenderer>().sprite = eyes[eyeIndex];

    }

    private void SelectMouths(SO_FaceStates.BasicStates mouthState)
    {
        int mouthIndex = Array.IndexOf(Enum.GetValues(typeof(SO_FaceStates.BasicStates)), mouthState);

        GameObject.Find("Mouth").GetComponent<SpriteRenderer>().sprite = mouths[mouthIndex];


    }
}
using System;
using System.Collections.Generic;
using UnityEngine;

public class FaceManager : MonoBehaviour
{
    [SerializeField] private List<Sprite> eyes;
    [SerializeField] private List<Sprite> mouths;

    //[SerializeField] string currentState;

    public void Update()
    {
        #region ###--- D E B U G ---###
        /*if (Input.GetKeyDown(KeyCode.E))
        {
            StateCommand(SO_FaceStates.BasicStates.Scared);

            currentState = SO_FaceStates.BasicStates.Scared.ToString();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            StateCommand(SO_FaceStates.BasicStates.Mad);

            currentState = SO_FaceStates.BasicStates.Mad.ToString();

        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            StateCommand(SO_FaceStates.BasicStates.Kawaii);

            currentState = SO_FaceStates.BasicStates.Kawaii.ToString();

        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            StateCommand(SO_FaceStates.BasicStates.Dead);

            currentState = SO_FaceStates.BasicStates.Dead.ToString();

        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            StateCommand(SO_FaceStates.BasicStates.Bored);

            currentState = SO_FaceStates.BasicStates.Bored.ToString();

        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            StateCommand(SO_FaceStates.BasicStates.Shy);

            currentState = SO_FaceStates.BasicStates.Shy.ToString();

        }*/
        #endregion
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